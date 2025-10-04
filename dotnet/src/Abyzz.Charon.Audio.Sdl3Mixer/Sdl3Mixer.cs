using Microsoft.Extensions.Options;
using SDL;

namespace Charon.Audio;

internal unsafe class Sdl3Mixer : IDisposable
{
    public MIX_Mixer* Mixer { get; }
    
    public Sdl3Mixer(IOptions<Sdl3MixerSettings> settings)
    {
        if (!SDL3_mixer.MIX_Init())
        {
            throw new CharonSdl3MixerException();       
        }

        var audioSpec = new SDL_AudioSpec();
        // {
        //     channels = settings.Value.Channels,
        //     freq = settings.Value.Frequency,
        //     format = settings.Value.Frequency switch
        //     {
        //         8 => SDL_AudioFormat.SDL_AUDIO_S8,
        //         32 => SDL_AudioFormat.SDL_AUDIO_S32LE,
        //         _ => SDL_AudioFormat.SDL_AUDIO_S16LE,
        //     }
        // };
        
        Mixer = SDL3_mixer.MIX_CreateMixer(&audioSpec);
    }

    public void Dispose()
    {
        SDL3_mixer.MIX_DestroyMixer(Mixer);
        SDL3_mixer.MIX_Quit();       
    }
}
