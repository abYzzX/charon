using Charon.Abstractions;
using Charon.Modularity.Attributes;

namespace Charon.Font;

[DependsOn(typeof(CharonFontModule))]
public class CharonFontBdfModule : CharonModuleBase
{
    
}
