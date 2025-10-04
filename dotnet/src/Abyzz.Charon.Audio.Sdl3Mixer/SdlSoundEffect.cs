using SDL;

namespace Charon.Audio;

public unsafe class SdlSoundEffect : ISoundEffect, IDisposable
{
    private readonly MIX_Audio* _audio;
    private readonly MIX_Track* _track;
    private readonly MIX_Mixer* _mixer;
    
    public Vector2 Position
    {
        get
        {
            var pos = new MIX_Point3D();
            SDL3_mixer.MIX_GetTrack3DPosition(_track, &pos);
            return new Vector2(pos.x, pos.z);
        }
        set
        {
            var pos = new MIX_Point3D { x = value.X, y = 0, z = value.Y };
            SDL3_mixer.MIX_SetTrack3DPosition(_track, &pos);
        }
    }

    public float Volume
    {
        get
        {
            return SDL3_mixer.MIX_GetTrackGain(_track);
        }
        set
        {
            SDL3_mixer.MIX_SetTrackGain(_track, System.Math.Clamp(value, 0.0f, 1.0f));       
        }
    }

    public SdlSoundEffect(MIX_Mixer* mixer, MIX_Audio* audio)
    {
        _mixer = mixer;
        _audio = audio;
        // _track = SDL3_mixer.MIX_CreateTrack(mixer);
        // SDL3_mixer.MIX_SetTrackAudio(_track, _audio);
    }

    public void Play(int loops = 1)
    {
        var props = new SDL_PropertiesID();
        SDL3.SDL_SetNumberProperty(props, SDL3_mixer.MIX_PROP_PLAY_LOOPS_NUMBER, loops);
        //SDL3_mixer.MIX_PlayTrack(_track, props);
        SDL3_mixer.MIX_PlayAudio(_mixer, _audio);
    }

    public void Stop()
    {
        SDL3_mixer.MIX_StopTrack(_track, 0);
    }

    public void Pause()
    {
        SDL3_mixer.MIX_PauseTrack(_track);
    }

    public void Resume()
    {
        SDL3_mixer.MIX_ResumeTrack(_track);
    }


    public void Dispose()
    {
        //SDL3_mixer.MIX_DestroyTrack(_track);
        SDL3_mixer.MIX_DestroyAudio(_audio);
    }
}
