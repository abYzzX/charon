using Charon.Math;

namespace Charon.Geom;

public class GeometryMath
{
    public static int[] TriangulateConvex(Vector2[] points)
    {
        var indices = new List<int>();
        for (int i = 1; i < points.Length - 1; i++)
        {
            indices.Add(0);
            indices.Add(i);
            indices.Add(i + 1);
        }
        return indices.ToArray();
    }
    
    public static bool IsConvexPolygon(Vector2[] points)
    {
        var n = points.Length;
        if (n < 3)
        {
            return false;
        }

        bool? sign = null;

        for (var i = 0; i < n; i++)
        {
            var p0 = points[i];
            var p1 = points[(i + 1) % n];
            var p2 = points[(i + 2) % n];

            var d1 = p1 - p0;
            var d2 = p2 - p1;

            var cross = d1.X * d2.Y - d1.Y * d2.X;

            if (cross != 0)
            {
                if (!sign.HasValue)
                {
                    sign = cross > 0;
                }
                else if (cross > 0 != sign.Value)
                {
                    return false;
                }
            }
        }

        return true;
    }    
}
