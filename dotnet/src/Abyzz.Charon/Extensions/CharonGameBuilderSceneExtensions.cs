using Charon.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Charon.Extensions;

public static class CharonGameBuilderSceneExtensions
{
    public static ICharonGameBuilder UseMainScene<TScene>(this ICharonGameBuilder builder)
        where TScene : class, IScene
    {
        builder.ConfigureServices(s =>
        {
            s.AddScoped<TScene>();
            s.Configure<SceneManagerSettings>(o => o.MainSceneType = typeof(TScene));
        });
        return builder;       
    }
    
}
