using Charon.Math;

namespace Charon.Geom;

public readonly struct Line(Vector2 start, Vector2 end) : IShape, IEquatable<Line>
{
    public Vector2 Start { get; } = start;
    public Vector2 End { get; } = end;

    public Line(float x1, float y1, float x2, float y2) : this(new Vector2(x1, y1), new Vector2(x2, y2)) { }

    public AABB GetAABB()
    {
        return new AABB(Start, End);
    }

    public Vector2[] GetPoints()
    {
        return [Start, End];   
    }

    public bool Equals(Line other)
    {
        return Start.Equals(other.Start) && End.Equals(other.End);
    }

    public override bool Equals(object? obj)
    {
        return obj is Line other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, End);
    }
}
