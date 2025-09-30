using System.ComponentModel;
using System.Reflection;
using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Charon;

public static class ServiceCollectionAssemblyExtensions
{
    public static IServiceCollection AddAssemblies(this IServiceCollection services, params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            AddAssembly(services, assembly);
        }

        return services;
    }

    public static IServiceCollection AddAssembly(this IServiceCollection services, Assembly assembly)
    {
        InitLogger.LogInformation("Register assembly: {Assembly} (Version {Version})", assembly.GetName().Name,
            assembly.GetName().Version);
        var types = assembly.GetTypes();
        foreach (var type in types)
        {
            AddAssemblyType(services, type);
        }

        return services;
    }

    private static void AddAssemblyType(IServiceCollection services, Type type)
    {
        if (type.GetCustomAttribute<DisableAutoRegistrationAttribute>() is not null)
        {
            return;
        }

        if (IsDependency<ITransientDependency>(type))
        {
            AddTransient(services, type);
        }
        else if (IsDependency<IScopedDependency>(type))
        {
            AddScoped(services, type);
        }
        else if (IsDependency<ISingletonDependency>(type))
        {
            AddSingleton(services, type);
        }
    }

    private static bool IsDependency<TDependency>(Type type)
    {
        return type is { IsAbstract: false, IsClass: true, IsGenericType: false }
               && type.IsAssignableTo<TDependency>();
    }

    private static List<Type> GetExposedTypes(Type type)
    {
        if (type.GetCustomAttributes<ExposeServicesAttribute>() is not { } exposedAttributes)
        {
            return [];
        }

        var types = exposedAttributes.SelectMany(x => x.ServiceTypes).Distinct().ToList();
        return !types.All(type.IsAssignableTo)
            ? throw new TypeLoadException(type.FullName)
            : types;
    }


    private static void AddSingleton(IServiceCollection services, Type type)
    {
        InitLogger.LogDebug("  Registering singleton service: {Type}", type.FullName);
        services.AddSingleton(type);
        foreach (var exposedType in GetExposedTypes(type))
        {
            if (type.GetCustomAttribute<ReplaceServiceAttribute>() is { } replaceServiceAttribute)
            {
                InitLogger.LogDebug("    Removing existing singleton service: {Type}", type.FullName);
                services.RemoveAll(x => x.ServiceType == exposedType &&
                                        (!replaceServiceAttribute.OnlySameDependency ||
                                         x.Lifetime == ServiceLifetime.Singleton));
            }

            InitLogger.LogDebug("    Exposed: {Type}", exposedType.FullName);
            services.AddSingleton(exposedType, sp => sp.GetRequiredService(type));
        }
    }

    private static void AddTransient(IServiceCollection services, Type type)
    {
        InitLogger.LogDebug("  Registering transient service: {Type}", type.FullName);
        services.AddTransient(type);
        foreach (var exposedType in GetExposedTypes(type))
        {
            if (type.GetCustomAttribute<ReplaceServiceAttribute>() is { } replaceServiceAttribute)
            {
                InitLogger.LogDebug("    Removing existing transient service: {Type}", type.FullName);
                services.RemoveAll(x => x.ServiceType == exposedType &&
                                        (!replaceServiceAttribute.OnlySameDependency ||
                                         x.Lifetime == ServiceLifetime.Transient));
            }

            InitLogger.LogDebug("    Exposed: {Type}", exposedType.FullName);
            services.AddTransient(exposedType, type);
        }
    }

    private static void AddScoped(IServiceCollection services, Type type)
    {
        InitLogger.LogDebug("  Registering scoped service: {Type}", type.FullName);
        services.AddScoped(type);
        foreach (var exposedType in GetExposedTypes(type))
        {
            if (type.GetCustomAttribute<ReplaceServiceAttribute>() is { } replaceServiceAttribute)
            {
                InitLogger.LogDebug("    Removing existing scoped service: {Type}", type.FullName);
                services.RemoveAll(x => x.ServiceType == exposedType &&
                                        (!replaceServiceAttribute.OnlySameDependency ||
                                         x.Lifetime == ServiceLifetime.Scoped));
            }

            InitLogger.LogDebug("    Exposed: {Type}", exposedType.FullName);
            services.AddScoped(exposedType, type);
        }
    }
}
