namespace Charon;

public readonly struct AABB
{
    public AABB(Vector2 min, Vector2 max)
    {
        Min = min;
        Max = max;
    }

    public Vector2 Min { get; }
    public Vector2 Max { get; }

    public bool Contains(Vector2 point)
    {
        return point.X >= Min.X && point.X <= Max.X &&
               point.Y >= Min.Y && point.Y <= Max.Y;
    }

    public bool Intersects(AABB other)
    {
        return !(other.Max.X < Min.X ||
                 other.Min.X > Max.X ||
                 other.Max.Y < Min.Y ||
                 other.Min.Y > Max.Y);
    }

    public override string ToString()
    {
        return $"AABB(Min={Min}, Max={Max})";
    }

    public static AABB operator -(AABB aabb, Vector2 v)
    {
        return new AABB(aabb.Min - v, aabb.Max - v);   
    }

    public static AABB operator +(AABB aabb, Vector2 v)
    {
        return new AABB(aabb.Min + v, aabb.Max - v);   
    }
}
