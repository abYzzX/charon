using Charon.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Charon.Abstractions;

public abstract class CharonModuleBase : ICharonModule
{
    public virtual void PreConfigureServices(IServiceCollection services)
    {
    }

    public virtual void ConfigureServices(IServiceCollection services)
    {
    }

    public virtual void PostConfigureServices(IServiceCollection services)
    {
    }

    public virtual void PreGameStart(IServiceProvider serviceProvider)
    {
    }

    public virtual void GameStart(IServiceProvider serviceProvider)
    {
    }
}
