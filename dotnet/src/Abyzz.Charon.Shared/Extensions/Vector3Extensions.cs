namespace Charon.Math;

public static class Vector3Extensions
{
    public static float Distance(this Vector3 v1, Vector3 v2)
    {
        return Vector3.Distance(v1, v2);
    }

    public static float DistanceSquared(this Vector3 v1, Vector3 v2)
    {
        return Vector3.DistanceSquared(v1, v2);
    }

    public static float Dot(this Vector3 v1, Vector3 v2)
    {
        return Vector3.Dot(v1, v2);
    }

    public static Vector3 Cross(this Vector3 v1, Vector3 v2)
    {
        return Vector3.Cross(v1, v2);
    }

    public static Vector3 Normalize(this Vector3 v)
    {
        return Vector3.Normalize(v);
    }

    public static Vector3 Lerp(this Vector3 from, Vector3 to, float t)
    {
        return Vector3.Lerp(from, to, t);
    }

    public static Vector3 RotateX(this Vector3 v, float angle)
    {
        return Vector3.RotateX(v, angle);
    }

    public static Vector3 RotateY(this Vector3 v, float angle)
    {
        return Vector3.RotateY(v, angle);
    }

    public static Vector3 RotateZ(this Vector3 v, float angle)
    {
        return Vector3.RotateZ(v, angle);
    }
}
