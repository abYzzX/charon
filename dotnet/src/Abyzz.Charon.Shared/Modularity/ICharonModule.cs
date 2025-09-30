using Microsoft.Extensions.DependencyInjection;

namespace Charon.Modularity;

public interface ICharonModule
{
    void PreConfigureServices(IServiceCollection services);
    void ConfigureServices(IServiceCollection services);
    void PostConfigureServices(IServiceCollection services);

    void PreGameStart(IServiceProvider serviceProvider);
    void GameStart(IServiceProvider serviceProvider);
}
