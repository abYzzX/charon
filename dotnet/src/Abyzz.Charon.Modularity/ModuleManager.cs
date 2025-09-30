using Charon.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Charon;

public sealed class ModuleManager : IModuleManager
{
    private readonly List<ModuleDescriptor> _descriptors = new();
    public IReadOnlyList<IModuleDescriptor> Modules { get => _descriptors; }
    
    public void InitializeModules<TStartupModule>()
        where TStartupModule : ICharonModule, new()
    {
        InitLogger.LogInformation("Initializing modules...");
        InitLogger.LogInformation("  - StartupModule = {ModuleType}", typeof(TStartupModule).Name);
        LoadModule(typeof(TStartupModule));

        _descriptors.Reverse();
        foreach (var moduleDescriptor in _descriptors)
        {
            InitLogger.LogInformation("  - Instantiate Module: {ModuleType}", moduleDescriptor.ModuleType);
            if (Activator.CreateInstance(moduleDescriptor.ModuleType) is not ICharonModule module)
            {
                throw new CharonInitializationException($"Module could not be instantiated. {moduleDescriptor.ModuleType}");
            }
            
            moduleDescriptor.Instance = module;
        }
    }

    public void PreConfigureModules(IServiceCollection services)
    {
        foreach (var moduleDescriptor in _descriptors)
        {
            (moduleDescriptor.Instance as CharonModule)?.SetServiceCollection(services);
            moduleDescriptor.Instance.PreConfigureServices(services);
            (moduleDescriptor.Instance as CharonModule)?.SetServiceCollection(null);
        }
    }

    public void ConfigureModules(IServiceCollection services)
    {
        foreach (var moduleDescriptor in _descriptors)
        {
            (moduleDescriptor.Instance as CharonModule)?.SetServiceCollection(services);
            moduleDescriptor.Instance.ConfigureServices(services);
            (moduleDescriptor.Instance as CharonModule)?.SetServiceCollection(null);
        }
    }

    public void PostConfigureModules(IServiceCollection services)
    {
        foreach (var moduleDescriptor in _descriptors)
        {
            (moduleDescriptor.Instance as CharonModule)?.SetServiceCollection(services);
            moduleDescriptor.Instance.PostConfigureServices(services);
            (moduleDescriptor.Instance as CharonModule)?.SetServiceCollection(null);
        }
    }

    private void LoadModule(Type moduleType)
    {
        var descriptor = new ModuleDescriptor(moduleType);
        if (!_descriptors.AddIfNotContains(descriptor))
        {
            return;
        }

        foreach (var dependency in descriptor.Dependencies)
        {
            LoadModule(dependency);
        }
    }
}
