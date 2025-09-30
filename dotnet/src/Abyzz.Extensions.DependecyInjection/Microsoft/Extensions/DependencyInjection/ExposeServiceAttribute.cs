// ReSharper disable once CheckNamespace

namespace Microsoft.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ExposeServiceAttribute(Type serviceType, object? key = null) : Attribute
{
    public Type ServiceType { get; } = serviceType;
    public object? Key { get; } = key;
}
