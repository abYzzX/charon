namespace Charon.Modularity.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class DependsOnAttribute(params Type[] dependencies) : Attribute
{
    public ITypeList<ICharonModule> Dependencies { get; } = new TypeList<ICharonModule>(dependencies);
}
