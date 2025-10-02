using Charon.Debugging;
using Charon.Modularity;
using Charon.Modularity.Attributes;

namespace Charon;

[ExposeServices(typeof(IDebugOverlay))]
public class NullDebugOverlay : IDebugOverlay, ISingletonDependency
{
    public bool Visible { get => false; set { } }

    public IDebugOverlay AddElement(IDebugOverlayElement element)
    {
        return this;
    }

    public IDebugOverlay AddElement<TElement>() where TElement : class, IDebugOverlayElement
    {
        return this;
    }

    public IDebugOverlay AddText(string text, Color? color = null)
    {
        return this;
    }
}
