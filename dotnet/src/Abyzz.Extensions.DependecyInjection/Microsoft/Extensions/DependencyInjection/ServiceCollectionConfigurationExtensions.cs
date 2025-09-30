// ReSharper disable CheckNamespace

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionConfigurationExtensions
{
    public static IServiceCollection ReplaceConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services.Replace(ServiceDescriptor.Singleton<IConfiguration>(configuration));
    }

    public static IConfiguration GetConfiguration(this IServiceCollection services)
    {
        return services.GetConfigurationOrNull() ??
               throw new InvalidOperationException("Could not find an implementation of " +
                                                   typeof(IConfiguration).AssemblyQualifiedName +
                                                   " in the service collection.");
    }

    public static IConfiguration? GetConfigurationOrNull(this IServiceCollection services)
    {
        return services.GetSingletonInstanceOrNull<IConfiguration>();
    }
}
