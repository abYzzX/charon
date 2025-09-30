using Charon.Input;
using Charon.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Charon.Sdl3;

public static class GameBuilderSdl3Extensions
{
    public static ICharonGameBuilder UseSdl3(this ICharonGameBuilder builder, Action<Sdl3Settings>? configure = null)
    {
        return builder.ConfigureServices(services =>
        {
            if (configure != null)
            {
                services.Configure(configure);
            }
            services.AddAssembly(typeof(CharonSdl3Module).Assembly);            
        });
    }
}
