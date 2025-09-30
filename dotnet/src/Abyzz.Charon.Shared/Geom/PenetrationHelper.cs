using Charon.Math;

namespace Charon.Geom;

public static class PenetrationHelper
{
    public static Vector2 GetPenetration(this IShape a, IShape b)
    {
        switch (a)
        {
            case Circle c: return GetPenetration(c, b);
            case Rectangle r: return GetPenetration(r, b);
            case Line l: return GetPenetration(l, b);
            case Polygon p: return GetPenetration(p, b);
            default: throw new NotSupportedException();
        }
    }

    // ---------------- Circle ----------------
    public static Vector2 GetPenetration(Circle c, IShape other)
    {
        switch (other)
        {
            case Circle oc: return CircleVsCircle(c, oc);
            case Rectangle r: return CircleVsRectangle(c, r);
            case Line l: return CircleVsLine(c, l);
            case Polygon p: return CircleVsPolygon(c, p);
            default: throw new NotSupportedException();
        }
    }

    private static Vector2 CircleVsCircle(Circle a, Circle b)
    {
        var delta = b.Center - a.Center;
        var dist = delta.Length;
        var overlap = a.Radius + b.Radius - dist;
        if (overlap <= 0)
        {
            return Vector2.Zero;
        }

        var direction = delta / dist;
        return direction * overlap;
    }

    private static Vector2 CircleVsRectangle(Circle c, Rectangle r)
    {
        var rect = r.GetAABB();
        var closestX = System.Math.Clamp(c.Center.X, rect.Min.X, rect.Max.X);
        var closestY = System.Math.Clamp(c.Center.Y, rect.Min.Y, rect.Max.Y);
        var delta = new Vector2(closestX - c.Center.X, closestY - c.Center.Y);
        var dist = delta.Length;
        var overlap = c.Radius - dist;
        if (overlap <= 0)
        {
            return Vector2.Zero;
        }

        return delta / dist * overlap;
    }

    private static Vector2 CircleVsLine(Circle c, Line l)
    {
        var ab = l.End - l.Start;
        var ac = c.Center - l.Start;
        var t = System.Math.Clamp(Vector2.Dot(ac, ab) / ab.LengthSquared, 0, 1);
        var closest = l.Start + ab * t;
        var delta = closest - c.Center;
        var dist = delta.Length;
        var overlap = c.Radius - dist;
        if (overlap <= 0)
        {
            return Vector2.Zero;
        }

        return delta / dist * overlap;
    }

    private static Vector2 CircleVsPolygon(Circle c, Polygon p)
    {
        var minPen = Vector2.Zero;
        var minDist = float.MaxValue;

        for (var i = 0; i < p.Points.Count; i++)
        {
            var a = p.Points[i];
            var b = p.Points[(i + 1) % p.Points.Count];
            var line = new Line(a.X, a.Y, b.X, b.Y);
            var pen = CircleVsLine(c, line);
            var dist = pen.Length;
            if (dist > 0 && dist < minDist)
            {
                minDist = dist;
                minPen = pen;
            }
        }

        // Punkt im Polygon?
        if (PointInPolygon(c.Center, p))
        {
            // Minimaler Verschiebungsvektor zurück zur Außenkante
            var aabb = p.GetAABB();
            var dx = System.Math.Min(aabb.Max.X - c.Center.X, c.Center.X - aabb.Min.X);
            var dy = System.Math.Min(aabb.Max.Y - c.Center.Y, c.Center.Y - aabb.Min.Y);
            if (dx < dy)
            {
                minPen = new Vector2(dx * System.Math.Sign(c.Center.X - (aabb.Min.X + aabb.Max.X) / 2), 0);
            }
            else
            {
                minPen = new Vector2(0, dy * System.Math.Sign(c.Center.Y - (aabb.Min.Y + aabb.Max.Y) / 2));
            }
        }

        return minPen;
    }

    // ---------------- Rectangle ----------------
    public static Vector2 GetPenetration(Rectangle r, IShape other)
    {
        switch (other)
        {
            case Circle c: return -GetPenetration(c, r);
            case Rectangle or: return RectangleVsRectangle(r, or);
            case Line l: return RectangleVsLine(r, l);
            case Polygon p: return RectangleVsPolygon(r, p);
            default: throw new NotSupportedException();
        }
    }

    private static Vector2 RectangleVsRectangle(Rectangle a, Rectangle b)
    {
        var aa = a.GetAABB();
        var ab = b.GetAABB();

        var overlapX = System.Math.Min(aa.Max.X, ab.Max.X) - System.Math.Max(aa.Min.X, ab.Min.X);
        var overlapY = System.Math.Min(aa.Max.Y, ab.Max.Y) - System.Math.Max(aa.Min.Y, ab.Min.Y);
        if (overlapX <= 0 || overlapY <= 0)
        {
            return Vector2.Zero;
        }

        if (overlapX < overlapY)
        {
            return new Vector2(overlapX * System.Math.Sign(b.Position.X - a.Position.X), 0);
        }

        return new Vector2(0, overlapY * System.Math.Sign(b.Position.Y - a.Position.Y));
    }

    private static Vector2 RectangleVsLine(Rectangle r, Line l)
    {
        // Kanten des Rechtecks
        var rect = r.GetAABB();
        var edges = new[]
        {
            new Line(rect.Min.X, rect.Min.Y, rect.Max.X, rect.Min.Y),
            new Line(rect.Max.X, rect.Min.Y, rect.Max.X, rect.Max.Y),
            new Line(rect.Max.X, rect.Max.Y, rect.Min.X, rect.Max.Y),
            new Line(rect.Min.X, rect.Max.Y, rect.Min.X, rect.Min.Y)
        };

        var minPen = Vector2.Zero;
        var minLen = float.MaxValue;
        foreach (var edge in edges)
        {
            var pen = LineVsLine(edge, l);
            var len = pen.Length;
            if (len > 0 && len < minLen)
            {
                minLen = len;
                minPen = pen;
            }
        }

        return minPen;
    }

    private static Vector2 RectangleVsPolygon(Rectangle r, Polygon p)
    {
        var rectPoly = new Polygon(new[]
        {
            r.GetAABB().Min, new Vector2(r.GetAABB().Max.X, r.GetAABB().Min.Y), r.GetAABB().Max,
            new Vector2(r.GetAABB().Min.X, r.GetAABB().Max.Y)
        });

        return PolygonVsPolygon(rectPoly, p);
    }

    // ---------------- Line ----------------
    public static Vector2 GetPenetration(Line l, IShape other)
    {
        switch (other)
        {
            case Circle c: return -GetPenetration(c, l);
            case Rectangle r: return -GetPenetration(r, l);
            case Line ol: return LineVsLine(l, ol);
            case Polygon p: return LineVsPolygon(l, p);
            default: throw new NotSupportedException();
        }
    }

    private static Vector2 LineVsLine(Line a, Line b)
    {
        if (!IntersectionHelper.Intersects(a, b))
        {
            return Vector2.Zero;
        }

        // Linie → minimaler Pushback entlang normal
        var normal = new Vector2(-(a.End.Y - a.Start.Y), a.End.X - a.Start.X);
        normal = normal / normal.Length;
        return normal * 0.001f; // kleiner Wert, da Linie theoretisch keine Fläche hat
    }

    private static Vector2 LineVsPolygon(Line l, Polygon p)
    {
        if (!IntersectionHelper.Intersects(l, p))
        {
            return Vector2.Zero;
        }

        var normal = new Vector2(-(l.End.Y - l.Start.Y), l.End.X - l.Start.X);
        normal = normal / normal.Length;
        return normal * 0.001f;
    }

    // ---------------- Polygon ----------------
    public static Vector2 GetPenetration(Polygon p, IShape other)
    {
        switch (other)
        {
            case Circle c: return -GetPenetration(c, p);
            case Rectangle r: return -GetPenetration(r, p);
            case Line l: return -GetPenetration(l, p);
            case Polygon op: return PolygonVsPolygon(p, op);
            default: throw new NotSupportedException();
        }
    }

    private static Vector2 PolygonVsPolygon(Polygon p1, Polygon p2)
    {
        var axes = GetNormals(p1).Concat(GetNormals(p2)).ToList();
        var minPen = Vector2.Zero;
        var minOverlap = float.MaxValue;

        foreach (var axis in axes)
        {
            ProjectPolygon(p1, axis, out var min1, out var max1);
            ProjectPolygon(p2, axis, out var min2, out var max2);

            var overlap = System.Math.Min(max1, max2) - System.Math.Max(min1, min2);
            if (overlap <= 0)
            {
                return Vector2.Zero;
            }

            if (overlap < minOverlap)
            {
                minOverlap = overlap;
                minPen = axis * overlap * System.Math.Sign(Vector2.Dot(axis, p2.Points[0] - p1.Points[0]));
            }
        }

        return minPen;
    }

    private static IEnumerable<Vector2> GetNormals(Polygon p)
    {
        for (var i = 0; i < p.Points.Count; i++)
        {
            var a = p.Points[i];
            var b = p.Points[(i + 1) % p.Points.Count];
            var edge = b - a;
            yield return new Vector2(-edge.Y, edge.X) / edge.Length;
        }
    }

    private static void ProjectPolygon(Polygon p, Vector2 axis, out float min, out float max)
    {
        min = max = Vector2.Dot(p.Points[0], axis);
        for (var i = 1; i < p.Points.Count; i++)
        {
            var proj = Vector2.Dot(p.Points[i], axis);
            if (proj < min)
            {
                min = proj;
            }

            if (proj > max)
            {
                max = proj;
            }
        }
    }

    private static bool PointInPolygon(Vector2 point, Polygon poly)
    {
        var inside = false;
        for (int i = 0, j = poly.Points.Count - 1; i < poly.Points.Count; j = i++)
        {
            var pi = poly.Points[i];
            var pj = poly.Points[j];
            if (pi.Y > point.Y != pj.Y > point.Y &&
                point.X < (pj.X - pi.X) * (point.Y - pi.Y) / (pj.Y - pi.Y + float.Epsilon) + pi.X)
            {
                inside = !inside;
            }
        }

        return inside;
    }
}
