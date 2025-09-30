using Autofac.Extensions.DependencyInjection;
using Charon.Debugging;
using Charon.Modularity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Charon;

public class CharonGameBuilder : ICharonGameBuilder
{
    private readonly List<Action<IServiceCollection>> _serviceConfigurations = new();
    private readonly List<Action<ILoggingBuilder>> _loggingBuilderConfigurations = new();
    private readonly List<Action<IConfigurationBuilder>> _configurationConfigurations = new();

    public ICharonGameBuilder ConfigureServices(Action<IServiceCollection> services)
    {
        _serviceConfigurations.Add(services);
        return this;
    }

    public ICharonGameBuilder ConfigureLogging(Action<ILoggingBuilder> loggingBuilder)
    {
        _loggingBuilderConfigurations.Add(loggingBuilder);
        return this;
    }

    public ICharonGameBuilder ConfigureConfiguration(Action<IConfigurationBuilder> configurationBuilder)
    {
        _configurationConfigurations.Add(configurationBuilder);
        return this;
    }


    public ICharonGame Build<TStartupGameModule>()
        where TStartupGameModule : ICharonModule, new()
    {
        var moduleManager = new ModuleManager();
        moduleManager.InitializeModules<TStartupGameModule>();
        var serviceProvider = CreateServiceProvider(moduleManager);

        var game = serviceProvider.GetRequiredService<ICharonGame>();
        return new CharonGameWrapper(game, serviceProvider);
    }

    private IServiceProvider CreateServiceProvider(ModuleManager moduleManager)
    {
        var services = new CharonServiceCollection();

        // logging
        services.AddLogging(b =>
        {
            foreach (var action in _loggingBuilderConfigurations)
            {
                action(b);
            }
        });

        // internal services
        services.AddSingleton(moduleManager);
        AddInternalServices(services);
        // configuration
        var configuration = new ConfigurationBuilder();
        foreach (var action in _configurationConfigurations)
        {
            action(configuration);
        }

        var config = configuration.Build();
        services.AddSingleton(config);
        services.AddSingleton<IConfiguration>(sp => sp.GetRequiredService<IConfiguration>());

        foreach (var serviceConfiguration in _serviceConfigurations)
        {
            serviceConfiguration(services);
        }

        // Module stuff
        moduleManager.PreConfigureModules(services);
        AddModuleAssemblies(services, moduleManager);
        moduleManager.ConfigureModules(services);
        moduleManager.PostConfigureModules(services);

        var spFactory = new AutofacServiceProviderFactory();
        var containerBuilder = spFactory.CreateBuilder(services);

        return spFactory.CreateServiceProvider(containerBuilder);
    }

    private void AddInternalServices(IServiceCollection services)
    {
        services.AddSingleton<IModuleManager>(sp => sp.GetRequiredService<ModuleManager>());
        services.AddSingleton<SceneManager>();
        services.AddSingleton<ISceneManager>(sp => sp.GetRequiredService<SceneManager>());
        services.AddSingleton<IGlobalService, SceneManager>(sp => sp.GetRequiredService<SceneManager>());
        services.AddScoped<ISpriteBatch, SpriteBatch>();
        services.AddSingleton<IDebugOverlay, NullDebugOverlay>();
    }

    private void AddModuleAssemblies(IServiceCollection serviceCollection, IModuleManager moduleManager)
    {
        var assemblies = moduleManager
            .Modules
            .SelectMany(x => x.Dependencies.Select(y => y.Assembly))
            .Distinct().ToArray();

        serviceCollection.AddAssemblies(assemblies);
    }

    private sealed class CharonGameWrapper(ICharonGame inner, IServiceProvider provider) : ICharonGame
    {
        public void Initialize() => inner.Initialize();
        public void Run() => inner.Run();
        public void Dispose() => Shutdown();

        public void Shutdown()
        {
            inner.Dispose();
            (provider as IDisposable)?.Dispose();
        }
    }
}
