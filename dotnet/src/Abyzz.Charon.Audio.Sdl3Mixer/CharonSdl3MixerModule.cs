using Charon.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using SDL;

namespace Charon.Audio;

public class CharonSdl3MixerModule : CharonModuleBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<Sdl3Mixer>();
    }
}
