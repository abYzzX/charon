using Charon.Geom;

namespace Charon.Abstractions;

public abstract class RenderBatchBase: IRenderBatch
{
    public Matrix2D Projection { get; set; } = Matrix2D.Identity;

    public IDisposable UseProjection(Matrix2D projection)
    {
        var oldProjection = Projection;
        Projection = projection;
        return new DisposableAction(() => Projection = oldProjection);  
    }
    
    public abstract IDisposable Begin(ITexture? texture = null, BlendMode? srcBlendMode = null, BlendMode? destBlendMode = null);
    public abstract IRenderBatch DrawVerticies(Vertex[] vertices, int[] indices);
    public abstract IRenderBatch DrawPoint(Vector2 position, Color color);
    public abstract IRenderBatch DrawPoints(Color color, params Vector2[] points);
    public abstract IRenderBatch DrawLines(Color color, params Line[] lines);
    public abstract IRenderBatch DrawShape(IShape shape, Color color);
    public abstract IRenderBatch FillShape(IShape shape, Color color);
    public abstract IRenderBatch FillTexturedShape(IShape shape, Rectangle? sourceRect = null, Color? color = null);
    public abstract void Flush();
}
