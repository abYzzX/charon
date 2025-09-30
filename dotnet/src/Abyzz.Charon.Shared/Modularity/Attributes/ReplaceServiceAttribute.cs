namespace Charon.Modularity.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ReplaceServiceAttribute(Type serviceType, bool onlyIfRegistered = false, bool onlySameDependency = false) : Attribute
{
    public Type ServiceType { get; } = serviceType;
    public bool OnlyIfRegistered { get; set; } = false;
    public bool OnlySameDependency { get; set; } = false;
}
