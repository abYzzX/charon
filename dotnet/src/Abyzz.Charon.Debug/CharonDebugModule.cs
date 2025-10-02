using Charon.Abstractions;
using Charon.Font;
using Charon.Modularity.Attributes;

namespace Charon.Debugging;

[DependsOn(
    typeof(CharonFontModule),
    typeof(CharonFontBdfModule)
)]
public class CharonDebugModule : CharonModuleBase
{
    
}
