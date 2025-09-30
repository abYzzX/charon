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
        throw new NotImplementedException();
    }

    public IDebugOverlay AddElement<TElement>() where TElement : class, IDebugOverlayElement
    {
        throw new NotImplementedException();
    }

    public void Initialize()
    {
        throw new NotImplementedException();
    }

    public void Update(IGameTime gameTime)
    {
        throw new NotImplementedException();
    }

    public void Render()
    {
        throw new NotImplementedException();
    }

    public IDebugOverlay AddText(string text)
    {
        _stringBuilder.AppendLine(text);
        return this;
    }
}
