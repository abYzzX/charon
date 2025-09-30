namespace Charon.Modularity.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ExposeServicesAttribute(params Type[] serviceTypes) : Attribute
{
    public Type[] ServiceTypes { get; } = serviceTypes;
}
