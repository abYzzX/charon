using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using SDL;

namespace Charon.Audio;

internal unsafe class SdlSoundEffect : ISoundEffect, IDisposable
{
    private readonly MIX_Audio* _audio;
    private readonly Sdl3Mixer _mixer;

    private MIX_Track* _currentTrack;
    private float _volume = 1.0f;
    private Vector2 _position;

    public Vector2 Position
    {
        get => _position;
        set
        {
            _position = value;
            if (_currentTrack != null)
            {
                var pos = new MIX_Point3D { x = value.X, y = 0, z = value.Y };
                SDL3_mixer.MIX_SetTrack3DPosition(_currentTrack, &pos);
            }
        }
    }

    public float Volume
    {
        get => _volume;
        set
        {
            _volume = System.Math.Clamp(value, 0.0f, 1.0f);
            if (_currentTrack != null)
            {
                SDL3_mixer.MIX_SetTrackGain(_currentTrack, _volume);
            }
        }
    }

    public SdlSoundEffect(Sdl3Mixer mixer, MIX_Audio* audio)
    {
        _mixer = mixer;
        _audio = audio;
    }

    public void Play(int loops = 1)
    {
        if (!_mixer.AcquireTrack(out var track))
        {
            return;
        }

        _currentTrack = track;

        // Set track properties
        SDL3_mixer.MIX_SetTrackAudio(track, _audio);
        SDL3_mixer.MIX_SetTrackGain(track, _volume);

        var pos = new MIX_Point3D { x = _position.X, y = 0, z = _position.Y };
        SDL3_mixer.MIX_SetTrack3DPosition(track, &pos);

        // Setup properties and play
        var props = SDL3.SDL_CreateProperties();
        SDL3.SDL_SetNumberProperty(props, SDL3_mixer.MIX_PROP_PLAY_LOOPS_NUMBER, loops);

        SDL3_mixer.MIX_PlayTrack(track, props);
        SDL3.SDL_DestroyProperties(props);

        // Set callback to release track when done
        var context = new TrackContext { Mixer = _mixer, Track = track };
        var contextHandle = GCHandle.Alloc(context);
        SDL3_mixer.MIX_SetTrackStoppedCallback(track, &OnTrackFinished, GCHandle.ToIntPtr(contextHandle));
    }

    private class TrackContext
    {
        public required Sdl3Mixer Mixer { get; init; }
        public required MIX_Track* Track { get; init; }
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(System.Runtime.CompilerServices.CallConvCdecl)])]
    private static void OnTrackFinished(IntPtr userdata, MIX_Track* track)
    {
        if (userdata != IntPtr.Zero)
        {
            var handle = GCHandle.FromIntPtr(userdata);
            if (handle.IsAllocated)
            {
                var context = (TrackContext)handle.Target!;
                context.Mixer.ReleaseTrack(context.Track);
                handle.Free();
            }
        }
    }

    public void Stop()
    {
        if (_currentTrack != null)
        {
            SDL3_mixer.MIX_StopTrack(_currentTrack, 0);
            _mixer.ReleaseTrack(_currentTrack);
            _currentTrack = null;
        }
    }

    public void Pause()
    {
        if (_currentTrack != null)
        {
            SDL3_mixer.MIX_PauseTrack(_currentTrack);
        }
    }

    public void Resume()
    {
        if (_currentTrack != null)
        {
            SDL3_mixer.MIX_ResumeTrack(_currentTrack);
        }
    }

    public void Dispose()
    {
        Stop();
        SDL3_mixer.MIX_DestroyAudio(_audio);
    }
}
