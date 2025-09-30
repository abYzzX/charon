using Charon.Geom;
using Charon.Math;

namespace Charon;

public interface IRenderBatch
{
    Matrix2D Projection { get; set; }
    IDisposable UseProjection(Matrix2D projection);
    IDisposable Begin(ITexture? texture = null, BlendMode? srcBlendMode = null, BlendMode? destBlendMode = null);
    IRenderBatch DrawVerticies(Vertex[] vertices, int[] indices);
    IRenderBatch DrawPoint(Vector2 position, Color color);
    IRenderBatch DrawPoints(Color color, params Vector2[] points);
    IRenderBatch DrawLines(Color color, params Line[] lines);
    IRenderBatch DrawShape(IShape shape, Color color);
    IRenderBatch FillShape(IShape shape, Color color);
    IRenderBatch FillTexturedShape(IShape shape, Rectangle? sourceRect = null, Color? color = null);
    void Flush();
}
