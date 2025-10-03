namespace Charon.Ecs.Components;

public struct SpriteComponent
{
    public Sprite Sprite;
    public bool FlipHorizontally;
    public bool FlipVertically;
    public Color Color;
}

public struct ShapeComponent
{
    public IShape Shape;
}
