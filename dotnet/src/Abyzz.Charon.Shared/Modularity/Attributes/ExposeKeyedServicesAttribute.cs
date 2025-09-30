namespace Charon.Modularity.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ExposeKeyedServicesAttribute(Type serviceType, object key) : Attribute
{
    public Type ServiceType { get; } = serviceType;
    public object Key { get; } = key;
}
