using Charon.Abstractions;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Charon.Ecs;

[DependsOn(typeof(CharonEcsAbstractionsModule))]
public class CharonEcsModule : CharonModuleBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IComponentMapper<>), typeof(ComponentMapper<>));
    }
}
