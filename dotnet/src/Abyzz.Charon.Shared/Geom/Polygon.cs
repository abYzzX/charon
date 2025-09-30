using Charon.Math;

namespace Charon.Geom;

public class Polygon : IShape, IEquatable<Polygon>
{
    private readonly List<Vector2> _points = new();

    public Polygon() { }

    public Polygon(IEnumerable<Vector2> points)
    {
        _points.AddRange(points);
    }

    public IReadOnlyList<Vector2> Points
    {
        get => _points;
    }

    public int Count
    {
        get => _points.Count;
    }

    public float Perimeter
    {
        get
        {
            if (Count < 2)
            {
                return 0f;
            }

            var length = 0f;
            for (var i = 0; i < Count; i++)
            {
                var a = _points[i];
                var b = _points[(i + 1) % Count]; // schließt letzten mit erstem
                length += Vector2.Distance(a, b);
            }

            return length;
        }
    }

    public float Area
    {
        get
        {
            if (Count < 3)
            {
                return 0f;
            }

            var sum = 0f;
            for (var i = 0; i < Count; i++)
            {
                var a = _points[i];
                var b = _points[(i + 1) % Count];
                sum += a.X * b.Y - b.X * a.Y;
            }

            return MathF.Abs(sum) * 0.5f;
        }
    }

    public Vector2 Centroid
    {
        get
        {
            if (Count == 0)
            {
                return Vector2.Zero;
            }

            if (Count == 1)
            {
                return _points[0];
            }

            if (Count == 2)
            {
                return (_points[0] + _points[1]) / 2f;
            }

            var cx = 0f;
            var cy = 0f;
            var areaFactor = 0f;

            for (var i = 0; i < Count; i++)
            {
                var a = _points[i];
                var b = _points[(i + 1) % Count];
                var cross = a.X * b.Y - b.X * a.Y;
                cx += (a.X + b.X) * cross;
                cy += (a.Y + b.Y) * cross;
                areaFactor += cross;
            }

            var polygonArea = areaFactor * 0.5f;
            if (MathF.Abs(polygonArea) < float.Epsilon)
            {
                return Vector2.Zero; // degeneriert
            }

            return new Vector2(cx / (6f * polygonArea), cy / (6f * polygonArea));
        }
    }

    public bool Equals(Polygon? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return _points.Equals(other._points);
    }

    public AABB GetAABB()
    {
        var minX = _points.Min(p => p.X);
        var maxX = _points.Max(p => p.X);
        var minY = _points.Min(p => p.Y);
        var maxY = _points.Max(p => p.Y);

        return new AABB(new Vector2(minX, minY), new Vector2(maxX, maxY));
    }

    public Vector2[] GetPoints()
    {
        return _points.ToArray();
    }

    public void Add(Vector2 point)
    {
        _points.Add(point);
    }

    public void AddRange(IEnumerable<Vector2> points)
    {
        _points.AddRange(points);
    }

    public bool ContainsPoint(Vector2 p)
    {
        var inside = false;
        for (int i = 0, j = Count - 1; i < Count; j = i++)
        {
            var pi = _points[i];
            var pj = _points[j];
            var intersect = pi.Y > p.Y != pj.Y > p.Y &&
                            p.X < (pj.X - pi.X) * (p.Y - pi.Y) / (pj.Y - pi.Y + float.Epsilon) + pi.X;
            if (intersect)
            {
                inside = !inside;
            }
        }

        return inside;
    }

    public void Translate(Vector2 delta)
    {
        for (var i = 0; i < Count; i++)
        {
            _points[i] = _points[i] + delta;
        }
    }

    public void Scale(float factor)
    {
        for (var i = 0; i < Count; i++)
        {
            _points[i] = _points[i] * factor;
        }
    }

    public void Rotate(float angle)
    {
        for (var i = 0; i < Count; i++)
        {
            _points[i] = Vector2.Rotate(_points[i], angle);
        }
    }

    public void RotateDegrees(float angleDegrees)
    {
        Rotate(angleDegrees * MathF.PI / 180f);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((Polygon)obj);
    }

    public override int GetHashCode()
    {
        return _points.GetHashCode();
    }
}
