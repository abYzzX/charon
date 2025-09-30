using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Charon.Modularity;

public interface ICharonGameBuilder
{
    ICharonGameBuilder ConfigureServices(Action<IServiceCollection> services);
    ICharonGameBuilder ConfigureLogging(Action<ILoggingBuilder> loggingBuilder);
    ICharonGameBuilder ConfigureConfiguration(Action<IConfigurationBuilder> configurationBuilder);

    ICharonGame Build<TStartupGameModule>()
        where TStartupGameModule : ICharonModule, new();
}
