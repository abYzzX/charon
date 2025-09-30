using Charon.Geom;

namespace Charon;

public interface ISpriteBatch
{
    IDisposable UseProjection(Matrix2D projection);
    IDisposable Begin();

    ISpriteBatch DrawSprite(Sprite sprite);
    ISpriteBatch DrawSprite(ITexture texture, Vector2 position, Color color);
    ISpriteBatch DrawSprite(
        ITexture texture, 
        Vector2 position, 
        Color color,
        Rectangle sourceRectangle, 
        Vector2 origin, 
        float rotation, 
        Vector2 scale,
        bool flipHorizontally, 
        bool flipVertically);

    void Flush();
}
