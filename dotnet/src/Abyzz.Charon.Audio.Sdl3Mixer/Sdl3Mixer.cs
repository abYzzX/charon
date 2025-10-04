using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.Options;
using SDL;

namespace Charon.Audio;

[ExposeServices(typeof(IAudioMixer))]
internal unsafe class Sdl3Mixer : IAudioMixer, IDisposable, ISingletonDependency
{
    private readonly MIX_Track*[] _trackPool;
    private readonly bool[] _trackInUse;
    private readonly object _lockObject = new();
    private float _masterVolume = 1.0f;
    private float _musicVolume = 1.0f;
    private float _effectVolume = 1.0f;

    public MIX_Mixer* Mixer { get; }

    public float MasterVolume
    {
        get => _masterVolume;
        set
        {
            _masterVolume = System.Math.Clamp(value, 0.0f, 1.0f);
            SDL3_mixer.MIX_SetMasterGain(Mixer, _masterVolume);
        }
    }

    public float MusicVolume
    {
        get => _musicVolume;
        set => _musicVolume = System.Math.Clamp(value, 0.0f, 1.0f);
    }

    public float EffectVolume
    {
        get => _effectVolume;
        set => _effectVolume = System.Math.Clamp(value, 0.0f, 1.0f);
    }

    public Sdl3Mixer(IOptions<Sdl3MixerSettings> settings)
    {
        if (!SDL3_mixer.MIX_Init())
        {
            throw new CharonSdl3MixerException();
        }

        _masterVolume = settings.Value.MasterVolume;
        _musicVolume = settings.Value.MusicVolume;
        _effectVolume = settings.Value.EffectVolume;
        
        var audioSpec = new SDL_AudioSpec
        {
            channels = settings.Value.Channels,
            freq = settings.Value.Frequency,
            format = settings.Value.Bits switch
            {
                8 => SDL_AudioFormat.SDL_AUDIO_S8,
                32 => SDL_AudioFormat.SDL_AUDIO_S32LE,
                _ => SDL_AudioFormat.SDL_AUDIO_S16LE,
            }
        };

        Mixer = SDL3_mixer.MIX_CreateMixerDevice(SDL3.SDL_AUDIO_DEVICE_DEFAULT_PLAYBACK, &audioSpec);

        if (Mixer == null)
        {
            throw new CharonSdl3MixerException("Failed to create mixer");
        }

        SDL3_mixer.MIX_SetMasterGain(Mixer, _masterVolume);

        var poolSize = settings.Value.TrackPoolSize;
        _trackPool = new MIX_Track*[poolSize];
        _trackInUse = new bool[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            _trackPool[i] = SDL3_mixer.MIX_CreateTrack(Mixer);
            if (_trackPool[i] == null)
            {
                throw new CharonSdl3MixerException($"Failed to create track {i}");
            }
            _trackInUse[i] = false;
        }
    }

    public bool AcquireTrack(out MIX_Track* track)
    {
        lock (_lockObject)
        {
            for (int i = 0; i < _trackPool.Length; i++)
            {
                if (!_trackInUse[i])
                {
                    _trackInUse[i] = true;
                    track = _trackPool[i];
                    return true;
                }
            }
        }
        track = null;
        return false; // No free tracks available
    }

    public void ReleaseTrack(MIX_Track* track)
    {
        lock (_lockObject)
        {
            for (int i = 0; i < _trackPool.Length; i++)
            {
                if (_trackPool[i] == track)
                {
                    _trackInUse[i] = false;
                    return;
                }
            }
        }
    }

    public void PlaySound(ISoundEffect sound, int loops = 1)
    {
        if (sound is SdlSoundEffect sdlSound)
        {
            sdlSound.Play(loops, _effectVolume);
        }
        else
        {
            sound.Play(loops);
        }
    }

    public void PlayMusic(IMusicPlayer music, int loops = -1)
    {
        if (music is SdlMusicPlayer sdlMusic)
        {
            sdlMusic.Play(loops, _musicVolume);
        }
        else
        {
            music.Play(loops);
        }
    }

    public void PlayMusicFadeIn(IMusicPlayer music, int fadeMs, int loops = -1)
    {
        if (music is SdlMusicPlayer sdlMusic)
        {
            sdlMusic.FadeIn(fadeMs, loops, _musicVolume);
        }
        else
        {
            music.FadeIn(fadeMs, loops);
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < _trackPool.Length; i++)
        {
            if (_trackPool[i] != null)
            {
                SDL3_mixer.MIX_DestroyTrack(_trackPool[i]);
            }
        }

        SDL3_mixer.MIX_DestroyMixer(Mixer);
        SDL3_mixer.MIX_Quit();
    }
}
