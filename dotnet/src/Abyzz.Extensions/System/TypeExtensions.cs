﻿// ReSharper disable CheckNamespace

using System.Reflection;

namespace System;

public static class TypeExtensions
{
    public static string GetFullNameWithAssemblyName(this Type type)
    {
        return type.FullName + ", " + type.Assembly.GetName().Name;
    }

    public static bool IsAssignableTo<TTarget>(this Type type)
    {
        Check.NotNull(type, nameof(type));

        return type.IsAssignableTo(typeof(TTarget));
    }

    /// <summary>
    ///     Determines whether an instance of this type can be assigned to
    ///     an instance of the <paramref name="targetType"></paramref>.
    ///     Internally uses <see cref="Type.IsAssignableFrom" /> (as reverse).
    /// </summary>
    /// <param name="type">this type</param>
    /// <param name="targetType">Target type</param>
    public static bool IsAssignableTo(this Type type, Type targetType)
    {
        Check.NotNull(type, nameof(type));
        Check.NotNull(targetType, nameof(targetType));

        return targetType.IsAssignableFrom(type);
    }

    /// <summary>
    ///     Gets all base classes of this type.
    /// </summary>
    /// <param name="type">The type to get its base classes.</param>
    /// <param name="includeObject">True, to include the standard <see cref="object" /> type in the returned array.</param>
    public static Type[] GetBaseClasses(this Type type, bool includeObject = true)
    {
        Check.NotNull(type, nameof(type));

        var types = new List<Type>();
        AddTypeAndBaseTypesRecursively(types, type.BaseType, includeObject);
        return types.ToArray();
    }

    /// <summary>
    ///     Gets all base classes of this type.
    /// </summary>
    /// <param name="type">The type to get its base classes.</param>
    /// <param name="stoppingType">
    ///     A type to stop going to the deeper base classes. This type will be be included in the
    ///     returned array
    /// </param>
    /// <param name="includeObject">True, to include the standard <see cref="object" /> type in the returned array.</param>
    public static Type[] GetBaseClasses(this Type type, Type stoppingType, bool includeObject = true)
    {
        Check.NotNull(type, nameof(type));

        var types = new List<Type>();
        AddTypeAndBaseTypesRecursively(types, type.BaseType, includeObject, stoppingType);
        return types.ToArray();
    }

    private static void AddTypeAndBaseTypesRecursively(
        List<Type> types,
        Type? type,
        bool includeObject,
        Type? stoppingType = null)
    {
        if (type == null || type == stoppingType)
        {
            return;
        }

        if (!includeObject && type == typeof(object))
        {
            return;
        }

        AddTypeAndBaseTypesRecursively(types, type.BaseType, includeObject, stoppingType);
        types.Add(type);
    }

    public static bool IsAssignableToGenericType(this Type type, Type genericType)
    {
        var givenTypeInfo = type.GetTypeInfo();

        if (givenTypeInfo.IsGenericType && type.GetGenericTypeDefinition() == genericType)
        {
            return true;
        }

        foreach (var interfaceType in givenTypeInfo.GetInterfaces())
        {
            if (interfaceType.GetTypeInfo().IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }
        }

        if (givenTypeInfo.BaseType == null)
        {
            return false;
        }

        return IsAssignableToGenericType(givenTypeInfo.BaseType, genericType);
    }
}
