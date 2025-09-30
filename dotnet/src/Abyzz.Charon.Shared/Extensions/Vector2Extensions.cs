namespace Charon.Math;

public static class Vector2Extensions
{
    public static float Distance(this Vector2 v1, Vector2 v2)
    {
        return Vector2.Distance(v1, v2);
    }

    public static float DistanceSquared(this Vector2 v1, Vector2 v2)
    {
        return Vector2.DistanceSquared(v1, v2);
    }

    public static float Dot(this Vector2 v1, Vector2 v2)
    {
        return Vector2.Dot(v1, v2);
    }

    public static float Cross(this Vector2 v1, Vector2 v2)
    {
        return Vector2.Cross(v1, v2);
    }

    public static Vector2 Normalize(this Vector2 v)
    {
        return Vector2.Normalize(v);
    }

    public static Vector2 Lerp(this Vector2 from, Vector2 to, float t)
    {
        return Vector2.Lerp(from, to, t);
    }

    public static Vector2 Rotate(this Vector2 v, float angle)
    {
        return Vector2.Rotate(v, angle);
    }

    public static Vector2 RotateDegrees(this Vector2 v, float angleDegrees)
    {
        return Vector2.RotateDegrees(v, angleDegrees);
    }
}
