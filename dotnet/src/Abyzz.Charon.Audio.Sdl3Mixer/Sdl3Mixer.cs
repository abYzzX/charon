using Microsoft.Extensions.Options;
using SDL;

namespace Charon.Audio;

internal unsafe class Sdl3Mixer : IDisposable
{
    private readonly MIX_Track*[] _trackPool;
    private readonly bool[] _trackInUse;
    private readonly object _lockObject = new();

    public MIX_Mixer* Mixer { get; }

    public Sdl3Mixer(IOptions<Sdl3MixerSettings> settings)
    {
        if (!SDL3_mixer.MIX_Init())
        {
            throw new CharonSdl3MixerException();
        }

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

        // Create track pool
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
