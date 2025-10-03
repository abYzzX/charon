using Charon;
using Charon.ContentPipeline;
using Charon.Debugging;
using Charon.Ecs;
using Charon.Font;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Abyzz.Charon.Demo;

[DependsOn(
    typeof(CharonFontBdfModule),
    typeof(CharonFontBmfModule),
    typeof(CharonDebugModule),
    typeof(CharonEcsModule)
)]
public class CharonDemoModule : CharonModule
{
    public override void PreConfigureServices(IServiceCollection services)
    {
        ConfigureContentPipeline(services);
        ConfigureSdl3();
        ConfigureEcs();
    }

    private void ConfigureContentPipeline(IServiceCollection services)
    {
        services.AddFileSystemContentPipeline(c => c.RootPath = "./content");
    }
    
    private void ConfigureSdl3()
    {
        Configure<Sdl3Settings>(c =>
        {
            c.Title = "Charon Demo";
            c.IsResizable = true;
            c.LimitFps = false;
            c.TargetFps = 60;
            c.WindowWidth = 1024;
            c.WindowHeight = 768;
        });
    }

    private void ConfigureEcs()
    {
        Configure<EntityManagerOptions>(c =>
        {
            c.MaxEntities = 1024;
        });
    }
    
}
