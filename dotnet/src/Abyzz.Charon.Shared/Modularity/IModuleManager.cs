using Microsoft.Extensions.DependencyInjection;

namespace Charon.Modularity;

public interface IModuleManager
{
    IReadOnlyList<IModuleDescriptor> Modules { get; }

    void InitializeModules<TStartupModule>()
        where TStartupModule : ICharonModule, new();

    void PreConfigureModules(IServiceCollection services);
    void ConfigureModules(IServiceCollection services);
    void PostConfigureModules(IServiceCollection services);
}
