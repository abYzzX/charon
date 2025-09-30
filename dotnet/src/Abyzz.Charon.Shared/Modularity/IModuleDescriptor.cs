using System.Reflection;

namespace Charon.Modularity;

public interface IModuleDescriptor
{
    Type ModuleType { get; }
    Assembly Assembly { get; }
    ITypeList<ICharonModule> Dependencies { get; }
}
