namespace Charon.Debugging;

public interface IDebugOverlay
{
    IDebugOverlay AddElement(IDebugOverlayElement element);
    IDebugOverlay AddElement<TElement>() where TElement : class, IDebugOverlayElement;
    IDebugOverlay AddText(string text);
}

public interface IDebugOverlayElement
{
    void Draw(IRenderBatch renderBatch);
}
