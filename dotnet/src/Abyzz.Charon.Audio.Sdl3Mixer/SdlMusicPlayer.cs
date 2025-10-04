using SDL;

namespace Charon.Audio;

internal unsafe class SdlMusicPlayer : IMusicPlayer, IDisposable
{
    private readonly Sdl3Mixer _mixer;
    private readonly MIX_Track* _track;
    private readonly MIX_Audio* _audio;
    private float _volume = 1.0f;
    private bool _isPlaying;
    private bool _isPaused;

    public float Volume
    {
        get => _volume;
        set
        {
            _volume = System.Math.Clamp(value, 0.0f, 1.0f);
            SDL3_mixer.MIX_SetTrackGain(_track, _volume);
        }
    }

    public bool IsPlaying => _isPlaying;
    public bool IsPaused => _isPaused;

    public SdlMusicPlayer(Sdl3Mixer mixer, MIX_Audio* audio)
    {
        _mixer = mixer;
        _audio = audio;

        _track = SDL3_mixer.MIX_CreateTrack(mixer.Mixer);
        if (_track == null)
        {
            throw new CharonSdl3MixerException("Failed to create music track");
        }

        SDL3_mixer.MIX_SetTrackAudio(_track, _audio);
        SDL3_mixer.MIX_SetTrackGain(_track, _volume);

        // Set stopped callback
        SDL3_mixer.MIX_SetTrackStoppedCallback(_track, &OnTrackStopped, (IntPtr)System.Runtime.InteropServices.GCHandle.ToIntPtr(System.Runtime.InteropServices.GCHandle.Alloc(this)));
    }

    public void Play(int loops = -1)
    {
        Play(loops, 1.0f);
    }

    internal void Play(int loops, float categoryVolume)
    {
        SDL3_mixer.MIX_SetTrackGain(_track, _volume * categoryVolume);

        var props = SDL3.SDL_CreateProperties();
        SDL3.SDL_SetNumberProperty(props, SDL3_mixer.MIX_PROP_PLAY_LOOPS_NUMBER, loops);

        SDL3_mixer.MIX_PlayTrack(_track, props);
        SDL3.SDL_DestroyProperties(props);

        _isPlaying = true;
        _isPaused = false;
    }

    public void FadeIn(int fadeMs, int loops = -1)
    {
        FadeIn(fadeMs, loops, 1.0f);
    }

    internal void FadeIn(int fadeMs, int loops, float categoryVolume)
    {
        SDL3_mixer.MIX_SetTrackGain(_track, _volume * categoryVolume);

        var props = SDL3.SDL_CreateProperties();
        SDL3.SDL_SetNumberProperty(props, SDL3_mixer.MIX_PROP_PLAY_LOOPS_NUMBER, loops);
        SDL3.SDL_SetNumberProperty(props, SDL3_mixer.MIX_PROP_PLAY_FADE_IN_MILLISECONDS_NUMBER, fadeMs);

        SDL3_mixer.MIX_PlayTrack(_track, props);
        SDL3.SDL_DestroyProperties(props);

        _isPlaying = true;
        _isPaused = false;
    }

    public void FadeOut(int fadeMs)
    {
        _isPlaying = false;
        _isPaused = false;
    }

    public void Stop()
    {
        SDL3_mixer.MIX_StopTrack(_track, 0);
        _isPlaying = false;
        _isPaused = false;
    }

    public void Pause()
    {
        if (_isPlaying && !_isPaused)
        {
            SDL3_mixer.MIX_PauseTrack(_track);
            _isPaused = true;
        }
    }

    public void Resume()
    {
        if (_isPlaying && _isPaused)
        {
            SDL3_mixer.MIX_ResumeTrack(_track);
            _isPaused = false;
        }
    }

    [System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void OnTrackStopped(IntPtr userdata, MIX_Track* track)
    {
        if (userdata != IntPtr.Zero)
        {
            var handle = System.Runtime.InteropServices.GCHandle.FromIntPtr(userdata);
            if (handle.IsAllocated && handle.Target is SdlMusicPlayer player)
            {
                player._isPlaying = false;
                player._isPaused = false;
            }
        }
    }

    public void Dispose()
    {
        Stop();
        SDL3_mixer.MIX_DestroyTrack(_track);
        SDL3_mixer.MIX_DestroyAudio(_audio);
    }
}
