using Charon.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Charon;

public abstract class CharonModule : ICharonModule
{
    private IServiceCollection? Services { get; set; }

    public virtual void PreConfigureServices(IServiceCollection services) { }

    public virtual void ConfigureServices(IServiceCollection services) { }

    public virtual void PostConfigureServices(IServiceCollection services) { }

    public virtual void PreGameStart(IServiceProvider serviceProvider) { }

    public virtual void GameStart(IServiceProvider serviceProvider) { }

    protected void Configure<TOptions>(Action<TOptions> configureOptions) where TOptions : class
    {
        if (Services == null)
        {
            throw new CharonInitializationException("Configure only available during PreConfigureServices, ConfigureServices and PostConfigureServices");
        }
        Services.Configure(configureOptions);
    }

    protected void PostConfigure<TOptions>(Action<TOptions> configureOptions) where TOptions : class
    {
        if (Services == null)
        {
            throw new CharonInitializationException("PostConfigure only available during PreConfigureServices, ConfigureServices and PostConfigureServices");
        }

        Services.PostConfigure(configureOptions);
    }
    
    internal void SetServiceCollection(IServiceCollection? services)
    {
        Services = services;
    }
}
