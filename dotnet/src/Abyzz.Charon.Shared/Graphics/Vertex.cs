using Charon.Math;

namespace Charon;

public readonly struct Vertex(Vector2 position, Vector2? textureCoord = null, Color? color = null)
{
    public Vertex(float x, float y, Color? color = null, Vector2? textureCoord = null) : this(new Vector2(x, y), textureCoord, color) { }
    public Vector2 Position { get; } = position;
    public Color Color { get; } = color ?? Color.White;
    public Vector2? TextureCoord { get; } = textureCoord;
}
