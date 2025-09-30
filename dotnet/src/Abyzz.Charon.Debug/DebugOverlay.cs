using System.Text;
using Charon.Modularity;
using Charon.Modularity.Attributes;

namespace Charon.Debugging;

[ReplaceService(typeof(IDebugOverlay))]
[ExposeServices(typeof(IDebugOverlay), typeof(IGlobalService))]
public class DebugOverlay : IDebugOverlay, IGlobalService, ISingletonDependency
{
    private readonly StringBuilder _stringBuilder = new();
    
    public int Order { get; } = int.MaxValue;
    public IDebugOverlay AddElement(IDebugOverlayElement element)
    {
        return this;
    }

    public IDebugOverlay AddElement<TElement>() where TElement : class, IDebugOverlayElement
    {
        return this;
    }

    public void Initialize()
    {
    }

    public void Update(IGameTime gameTime)
    {
    }

    public void Render()
    {
    }

    public IDebugOverlay AddText(string text)
    {
        _stringBuilder.AppendLine(text);
        return this;
    }
}
