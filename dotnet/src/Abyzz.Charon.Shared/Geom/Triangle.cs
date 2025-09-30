using Charon.Math;

namespace Charon.Geom;

public readonly struct Triangle : IShape
{
    public Vector2 P1 { get; }
    public Vector2 P2 { get; }
    public Vector2 P3 { get; }
    
    public Vector2 Center { get; }

    public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;
        Center = (p1 + p2 + p3) / 3f; // Schwerpunkt
    }

    public Triangle(Vector2 center, float size)
    {
        Center = center;
        
        // Erstelle ein gleichseitiges Dreieck um den Mittelpunkt
        var height = size * 0.866f; // sqrt(3)/2 für gleichseitiges Dreieck
        
        // Punkte für ein gleichseitiges Dreieck mit Spitze nach oben
        P1 = center + new Vector2(0, -height * 2f/3f);        // Top
        P2 = center + new Vector2(-size/2f, height/3f);       // Bottom Left
        P3 = center + new Vector2(size/2f, height/3f);        // Bottom Right
    }

    public static Triangle FromCenter(Vector2 center, float size)
    {
        return new Triangle(center, size);
    }

    public static Triangle FromCenter(float x, float y, float size)
    {
        return FromCenter(new Vector2(x, y), size);
    }

    public Triangle WithCenter(Vector2 newCenter)
    {
        var offset = newCenter - Center;
        return new Triangle(P1 + offset, P2 + offset, P3 + offset);
    }

    public AABB GetAABB()
    {
        var points = GetPoints();
        var minX = points.Min(p => p.X);
        var maxX = points.Max(p => p.X);
        var minY = points.Min(p => p.Y);
        var maxY = points.Max(p => p.Y);
        return new AABB((minX, minY), (maxX, maxY));
    }

    public Vector2[] GetPoints()
    {
        return [P1, P2, P3];  
    }
}
