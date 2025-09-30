using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static T? GetSingletonInstanceOrNull<T>(this IServiceCollection services)
    {
        return (T?)services
            .FirstOrDefault(d => d.ServiceType == typeof(T))
            ?.NormalizedImplementationInstance();
    }

    public static object? GetSingletonInstanceOrNull(this IServiceCollection services, Type serviceType)
    {
        return services
            .FirstOrDefault(d => d.ServiceType == serviceType)
            ?.NormalizedImplementationInstance();
    }

    public static T GetSingletonInstance<T>(this IServiceCollection services)
    {
        var service = services.GetSingletonInstanceOrNull<T>();
        if (service == null)
        {
            throw new InvalidOperationException("Could not find singleton service: " + typeof(T).AssemblyQualifiedName);
        }

        return service;
    }

    public static object GetSingletonInstance(this IServiceCollection services, Type serviceType)
    {
        var service = services.GetSingletonInstanceOrNull(serviceType);
        if (service == null)
        {
            throw new InvalidOperationException(
                "Could not find singleton service: " + serviceType.AssemblyQualifiedName);
        }

        return service;
    }

    public static IServiceCollection AddAssembly(this IServiceCollection services, Assembly assembly)
    {
        void Register(IEnumerable<Type> types, Action<Type> registerRaw, Action<Type, Type> register,
            Action<Type, object, Type> registerKeyed)
        {
            foreach (var type in types)
            {
                var exposeServiceAttributes = type.GetCustomAttributes<ExposeServiceAttribute>().ToList();
                foreach (var exposeServiceAttribute in exposeServiceAttributes)
                {
                    if (exposeServiceAttribute.Key != null)
                    {
                        registerKeyed(exposeServiceAttribute.ServiceType, exposeServiceAttribute.Key, type);
                    }
                    else
                    {
                        register(exposeServiceAttribute.ServiceType, type);
                    }
                }

                if (exposeServiceAttributes.Count == 0)
                {
                    registerRaw(type);
                }
            }
        }

        var assemblyTypes = assembly.GetTypes();

        Register(assemblyTypes.Where(IsTransient),
            t => services.AddTransient(t),
            (t1, t2) => services.AddTransient(t1, t2),
            (t1, key, t2) => services.AddKeyedTransient(t1, key, t2));

        RegisterSingletons(services, assemblyTypes.Where(IsSingleton));

        Register(assemblyTypes.Where(IsScoped),
            t => services.AddScoped(t),
            (t1, t2) => services.AddScoped(t1, t2),
            (t1, key, t2) => services.AddKeyedScoped(t1, key, t2));

        return services;

        bool IsSingleton(Type type)
        {
            return type.IsAssignableTo(typeof(ISingletonDependency)) &&
                   !(type.IsAbstract || type.IsGenericTypeDefinition || type.IsGenericType ||
                     type.IsInterface);
        }

        bool IsTransient(Type type)
        {
            return type.IsAssignableTo(typeof(ITransientDependency)) &&
                   !(type.IsAbstract || type.IsGenericTypeDefinition || type.IsGenericType ||
                     type.IsInterface);
        }

        bool IsScoped(Type type)
        {
            return type.IsAssignableTo(typeof(IScopeDependency)) &&
                   !(type.IsAbstract || type.IsGenericTypeDefinition || type.IsGenericType ||
                     type.IsInterface);
        }
    }

    private static void RegisterSingletons(IServiceCollection services, IEnumerable<Type> types)
    {
        foreach (var type in types)
        {
            services.AddSingleton(type);
            foreach (var exposeServiceAttribute in type.GetCustomAttributes<ExposeServiceAttribute>())
            {
                if (exposeServiceAttribute.Key != null)
                {
                    services.AddKeyedSingleton(exposeServiceAttribute.ServiceType, exposeServiceAttribute.Key,
                        (x, k) => x.GetRequiredKeyedService(type, k));
                }
                else
                {
                    services.AddSingleton(exposeServiceAttribute.ServiceType, x => x.GetRequiredService(type));
                }
            }
        }
    }
}
