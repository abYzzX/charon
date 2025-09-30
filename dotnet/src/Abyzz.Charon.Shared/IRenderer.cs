using Charon.Math;

namespace Charon;

public interface IRenderer : IDisposable
{
    Color Color { get; set; }
    Matrix2D Projection { get; set; }
    void Clear(Color color);
    void Present();
    IRenderer SetColor(Color color);
    IDisposable SetRenderTarget(ITexture texture);
}
