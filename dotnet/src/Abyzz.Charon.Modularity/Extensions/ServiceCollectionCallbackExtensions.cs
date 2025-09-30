using Microsoft.Extensions.DependencyInjection;

namespace Charon;

public static class ServiceCollectionCallbackExtensions
{
    public static IServiceCollection RegisterServiceAddedCallback(this IServiceCollection services,
        Action<IServiceCollection, ServiceDescriptor> callback)
    {
        if (services is CharonServiceCollection charonServices)
        {
            charonServices.AddServiceAddedCallback(callback);
        }

        return services;
    }

    public static IServiceCollection RegisterServiceRemovedCallback(this IServiceCollection services,
        Action<IServiceCollection, ServiceDescriptor> callback)
    {
        if (services is CharonServiceCollection charonServices)
        {
            charonServices.AddServiceAddedCallback(callback);
        }

        return services;
    }
}
