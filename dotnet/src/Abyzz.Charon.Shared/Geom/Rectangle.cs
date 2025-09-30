using Charon.Math;

namespace Charon.Geom;

public readonly struct Rectangle(Vector2 position, Vector2 size) : IShape, IEqualityComparer<Rectangle>
{
    public Vector2 Position { get; } = position;
    public Vector2 Size { get; } = size;

    public float X
    {
        get => Position.X;
    }

    public float Y
    {
        get => Position.Y;
    }

    public float Width
    {
        get => Size.X;
    }

    public float Height
    {
        get => Size.Y;
    }

    public Vector2 Center { get; } = position + size / 2f;
    public Vector2 TopLeft { get; } = position;
    public Vector2 TopRight { get; } = position + new Vector2(size.X, 0);
    public Vector2 BottomLeft { get; } = position + new Vector2(0, size.Y);
    public Vector2 BottomRight { get; } = position + size;

    public Rectangle(float x, float y, float width, float height) : this(new Vector2(x, y), new Vector2(width, height))
    {
    }

    public static Rectangle FromCenter(Vector2 center, Vector2 size)
    {
        return new Rectangle(center - size / 2, size);
    }

    public static Rectangle FromCenter(float x, float y, float width, float height)
    {
        return FromCenter(new Vector2(x, y), new Vector2(width, height));
    }

    public static Rectangle FromLTRB(float left, float top, float right, float bottom)
    {
        return new Rectangle(left, top, right - left, bottom - top);
    }

    public bool Equals(Rectangle x, Rectangle y)
    {
        return x.Position.Equals(y.Position) && x.Size.Equals(y.Size);
    }

    public int GetHashCode(Rectangle obj)
    {
        return HashCode.Combine(obj.Position, obj.Size);
    }

    public AABB GetAABB()
    {
        return new AABB(TopLeft, BottomRight);
    }

    public Vector2[] GetPoints()
    {
        return [TopLeft, TopRight, BottomRight, BottomLeft];   
    }
}
