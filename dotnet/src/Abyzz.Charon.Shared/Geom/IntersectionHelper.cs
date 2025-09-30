using Charon.Math;

namespace Charon.Geom;

public static class IntersectionHelper
{
    public static bool Intersects(this IShape a, IShape b)
    {
        switch (a)
        {
            case Circle c: return Intersects(c, b);
            case Rectangle r: return Intersects(r, b);
            case Line l: return Intersects(l, b);
            case Polygon p: return Intersects(p, b);
            default: throw new NotSupportedException();
        }
    }

    // ---------------- Circle ----------------
    public static bool Intersects(Circle c, IShape other)
    {
        switch (other)
        {
            case Circle oc: return Intersects(c, oc);
            case Rectangle r: return Intersects(c, r);
            case Line l: return Intersects(c, l);
            case Polygon p: return Intersects(c, p);
            default: throw new NotSupportedException();
        }
    }

    public static bool Intersects(Circle a, Circle b)
    {
        var dx = b.Center.X - a.Center.X;
        var dy = b.Center.Y - a.Center.Y;
        var rSum = a.Radius + b.Radius;
        return dx * dx + dy * dy <= rSum * rSum;
    }

    public static bool Intersects(Circle c, Rectangle r)
    {
        var rect = r.GetAABB();
        var closestX = System.Math.Clamp(c.Center.X, rect.Min.X, rect.Max.X);
        var closestY = System.Math.Clamp(c.Center.Y, rect.Min.Y, rect.Max.Y);
        var dx = c.Center.X - closestX;
        var dy = c.Center.Y - closestY;
        return dx * dx + dy * dy <= c.Radius * c.Radius;
    }

    public static bool Intersects(Circle c, Line l)
    {
        var ab = l.End - l.Start;
        var ac = c.Center - l.Start;
        var t = Vector2.Dot(ac, ab) / ab.LengthSquared;
        t = System.Math.Clamp(t, 0, 1);
        var closest = l.Start + ab * t;
        var dx = closest.X - c.Center.X;
        var dy = closest.Y - c.Center.Y;
        return dx * dx + dy * dy <= c.Radius * c.Radius;
    }

    public static bool Intersects(Circle c, Polygon p)
    {
        if (p.Points.Any(pt => (pt - c.Center).LengthSquared <= c.Radius * c.Radius))
        {
            return true;
        }

        for (var i = 0; i < p.Points.Count; i++)
        {
            var a = p.Points[i];
            var b = p.Points[(i + 1) % p.Points.Count];
            if (Intersects(c, new Line(a.X, a.Y, b.X, b.Y)))
            {
                return true;
            }
        }

        return false;
    }

    // ---------------- Rectangle ----------------
    public static bool Intersects(Rectangle r, IShape other)
    {
        switch (other)
        {
            case Circle c: return Intersects(c, r);
            case Rectangle or: return Intersects(r, or);
            case Line l: return Intersects(r, l);
            case Polygon p: return Intersects(r, p);
            default: throw new NotSupportedException();
        }
    }

    public static bool Intersects(Rectangle a, Rectangle b)
    {
        var aa = a.GetAABB();
        var ab = b.GetAABB();
        return !(ab.Max.X < aa.Min.X ||
                 ab.Min.X > aa.Max.X ||
                 ab.Max.Y < aa.Min.Y ||
                 ab.Min.Y > aa.Max.Y);
    }

    public static bool Intersects(Rectangle r, Line l)
    {
        // Linie schneiden mit Rechteckkante (4 Linien)
        var rect = r.GetAABB();
        var edges = new[]
        {
            new Line(rect.Min.X, rect.Min.Y, rect.Max.X, rect.Min.Y),
            new Line(rect.Max.X, rect.Min.Y, rect.Max.X, rect.Max.Y),
            new Line(rect.Max.X, rect.Max.Y, rect.Min.X, rect.Max.Y),
            new Line(rect.Min.X, rect.Max.Y, rect.Min.X, rect.Min.Y)
        };

        foreach (var edge in edges)
        {
            if (Intersects(edge, l))
            {
                return true;
            }
        }

        // Linie komplett im Rechteck?
        if (rect.Contains(l.Start) && rect.Contains(l.End))
        {
            return true;
        }

        return false;
    }

    public static bool Intersects(Rectangle r, Polygon p)
    {
        // Polygon-Kanten gegen Rechteck-Kanten testen
        var rect = r.GetAABB();
        var rectPoly = new Polygon(new[]
        {
            new Vector2(rect.Min.X, rect.Min.Y), new Vector2(rect.Max.X, rect.Min.Y),
            new Vector2(rect.Max.X, rect.Max.Y), new Vector2(rect.Min.X, rect.Max.Y)
        });

        return Intersects(rectPoly, p);
    }

    // ---------------- Line ----------------
    public static bool Intersects(Line l, IShape other)
    {
        switch (other)
        {
            case Circle c: return Intersects(c, l);
            case Rectangle r: return Intersects(r, l);
            case Line ol: return Intersects(l, ol);
            case Polygon p: return Intersects(l, p);
            default: throw new NotSupportedException();
        }
    }

    public static bool Intersects(Line a, Line b)
    {
        var d = (b.End.Y - b.Start.Y) * (a.End.X - a.Start.X) -
                (b.End.X - b.Start.X) * (a.End.Y - a.Start.Y);
        if (System.Math.Abs(d) < float.Epsilon)
        {
            return false; // Parallel
        }

        var ua = ((b.End.X - b.Start.X) * (a.Start.Y - b.Start.Y) -
                  (b.End.Y - b.Start.Y) * (a.Start.X - b.Start.X)) / d;

        var ub = ((a.End.X - a.Start.X) * (a.Start.Y - b.Start.Y) -
                  (a.End.Y - a.Start.Y) * (a.Start.X - b.Start.X)) / d;

        return ua >= 0 && ua <= 1 && ub >= 0 && ub <= 1;
    }

    public static bool Intersects(Line l, Polygon p)
    {
        for (var i = 0; i < p.Points.Count; i++)
        {
            var a = p.Points[i];
            var b = p.Points[(i + 1) % p.Points.Count];
            if (Intersects(l, new Line(a.X, a.Y, b.X, b.Y)))
            {
                return true;
            }
        }

        // Linie komplett innerhalb Polygon?
        if (PointInPolygon(l.Start, p) || PointInPolygon(l.End, p))
        {
            return true;
        }

        return false;
    }

    // ---------------- Polygon ----------------
    public static bool Intersects(Polygon p1, IShape other)
    {
        switch (other)
        {
            case Circle c: return Intersects(c, p1);
            case Rectangle r: return Intersects(r, p1);
            case Line l: return Intersects(l, p1);
            case Polygon p2: return Intersects(p1, p2);
            default: throw new NotSupportedException();
        }
    }

    public static bool Intersects(Polygon p1, Polygon p2)
    {
        return !HasSeparatingAxis(p1.Points, p2.Points) &&
               !HasSeparatingAxis(p2.Points, p1.Points);
    }

    private static bool HasSeparatingAxis(IReadOnlyList<Vector2> poly1, IReadOnlyList<Vector2> poly2)
    {
        for (var i = 0; i < poly1.Count; i++)
        {
            var a = poly1[i];
            var b = poly1[(i + 1) % poly1.Count];
            var edge = b - a;
            var axis = new Vector2(-edge.Y, edge.X); // normal

            var min1 = float.MaxValue;
            var max1 = float.MinValue;
            foreach (var p in poly1)
            {
                var proj = p.X * axis.X + p.Y * axis.Y;
                min1 = System.Math.Min(min1, proj);
                max1 = System.Math.Max(max1, proj);
            }

            var min2 = float.MaxValue;
            var max2 = float.MinValue;
            foreach (var p in poly2)
            {
                var proj = p.X * axis.X + p.Y * axis.Y;
                min2 = System.Math.Min(min2, proj);
                max2 = System.Math.Max(max2, proj);
            }

            if (max1 < min2 || max2 < min1)
            {
                return true; // separating axis found
            }
        }

        return false;
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
