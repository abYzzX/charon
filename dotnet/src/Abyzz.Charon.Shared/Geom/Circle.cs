using Charon.Math;

namespace Charon.Geom;

public readonly struct Circle(Vector2 center, float radius) : IShape, IEquatable<Circle>
{
    public Vector2 Center { get; } = center;
    public float Radius { get; } = radius;

    public bool Contains(Vector2 point)
    {
        var dx = point.X - Center.X;
        var dy = point.Y - Center.Y;
        var distSq = dx * dx + dy * dy;
        return distSq <= Radius * Radius;
    }

    public AABB GetAABB()
    {
        var min = new Vector2(Center.X - Radius, Center.Y - Radius);
        var max = new Vector2(Center.X + Radius, Center.Y + Radius);
        return new AABB(min, max);
    }

    public Vector2[] GetPoints()
    {
        return GetPoints(16);
    }

    public Vector2[] GetPoints(int segments)
    {
        var points = new Vector2[segments];
        var angleStep = 2 * MathF.PI / segments;

        for (var i = 0; i < segments; i++)
        {
            var angle = i * angleStep;
            points[i] = new Vector2(
                center.X + radius * MathF.Cos(angle),
                center.Y + radius * MathF.Sin(angle)
            );
        }

        return points;
    }

    public override bool Equals(object? obj)
    {
        return obj is Circle other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Center, Radius);
    }

    public bool Equals(Circle other)
    {
        return Center.Equals(other.Center) && Radius.Equals(other.Radius);
    }
}
