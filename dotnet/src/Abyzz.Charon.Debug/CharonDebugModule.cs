using Charon.Abstractions;
using Charon.Font;
using Charon.Modularity.Attributes;

namespace Charon.Debugging;

[DependsOn(
    typeof(CharonFontModule)
)]
public class CharonDebugModule : CharonModuleBase
{
    
}
