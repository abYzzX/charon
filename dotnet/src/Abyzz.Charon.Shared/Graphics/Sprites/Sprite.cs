using Charon.Geom;

namespace Charon;

public class Sprite
{
    public ITexture Texture { get; set; }
    public Vector2 Position { get; set; }
    public Rectangle TextureSourceRectangle { get; set; }
    public bool FlipHorizontally { get; set; } = false;
    public bool FlipVertically { get; set; } = false;
    public float Rotation { get; set; } = 0f;
    public Vector2 Scale { get; set; } = Vector2.One;
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public Color Color { get; set; }= Color.White;

    public Sprite(ITexture texture, Vector2 position, Rectangle? textureSourceRect = null)
    {
        Texture = texture;
        Position = position;
        TextureSourceRectangle = textureSourceRect ?? new Rectangle(0, 0, texture.Width, texture.Height);
    }
}
