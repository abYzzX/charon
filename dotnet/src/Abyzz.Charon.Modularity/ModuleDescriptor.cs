using System.Reflection;
using Charon.Modularity;
using Charon.Modularity.Attributes;

namespace Charon;

public class ModuleDescriptor : IEquatable<ModuleDescriptor>, IModuleDescriptor
{
    public Type ModuleType { get; }
    public Assembly Assembly { get; }
    public ITypeList<ICharonModule> Dependencies { get; }
    internal ICharonModule Instance { get; set; }
    
    public ModuleDescriptor(Type moduleType)
    {
        ModuleType = moduleType;
        Assembly = moduleType.Assembly;
        
        Dependencies = moduleType.GetCustomAttribute<DependsOnAttribute>()?.Dependencies
                       ?? new TypeList<ICharonModule>();
    }

    public bool Equals(ModuleDescriptor? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return ModuleType == other.ModuleType;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((ModuleDescriptor)obj);
    }

    public override int GetHashCode()
    {
        return ModuleType.GetHashCode();
    }
}
