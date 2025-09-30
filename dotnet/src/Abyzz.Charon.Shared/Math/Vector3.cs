namespace Charon;

public readonly struct Vector3(float x, float y, float z) : IEquatable<Vector3>
{
    public static Vector3 Zero { get; } = new(0, 0, 0);
    public static Vector3 One { get; } = new(1, 1, 1);
    public static Vector3 UnitX { get; } = new(1, 0, 0);
    public static Vector3 UnitY { get; } = new(0, 1, 0);
    public static Vector3 UnitZ { get; } = new(0, 0, 1);

    public float X { get; } = x;
    public float Y { get; } = y;
    public float Z { get; } = z;

    public float Length
    {
        get => MathF.Sqrt(X * X + Y * Y + Z * Z);
    }

    public float LengthSquared
    {
        get => X * X + Y * Y + Z * Z;
    }

    public Vector3() : this(0, 0, 0) { }
    public Vector3(float v) : this(v, v, v) { }

    public bool Equals(Vector3 other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector3 other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    public static float Distance(Vector3 left, Vector3 right)
    {
        return (left - right).Length;
    }

    public static float DistanceSquared(Vector3 left, Vector3 right)
    {
        return (left - right).LengthSquared;
    }

    public static float Dot(Vector3 left, Vector3 right)
    {
        return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
    }

    public static Vector3 Cross(Vector3 left, Vector3 right)
    {
        return new Vector3(
            left.Y * right.Z - left.Z * right.Y,
            left.Z * right.X - left.X * right.Z,
            left.X * right.Y - left.Y * right.X
        );
    }

    public static Vector3 Normalize(Vector3 v)
    {
        return v / v.Length;
    }

    public static Vector3 Lerp(Vector3 from, Vector3 to, float t)
    {
        return from + (to - from) * t;
    }

    public static Vector3 RotateX(Vector3 v, float angle)
    {
        var cos = MathF.Cos(angle);
        var sin = MathF.Sin(angle);
        return new Vector3(v.X, v.Y * cos - v.Z * sin, v.Y * sin + v.Z * cos);
    }

    public static Vector3 RotateY(Vector3 v, float angle)
    {
        var cos = MathF.Cos(angle);
        var sin = MathF.Sin(angle);
        return new Vector3(v.X * cos + v.Z * sin, v.Y, -v.X * sin + v.Z * cos);
    }

    public static Vector3 RotateZ(Vector3 v, float angle)
    {
        var cos = MathF.Cos(angle);
        var sin = MathF.Sin(angle);
        return new Vector3(v.X * cos - v.Y * sin, v.X * sin + v.Y * cos, v.Z);
    }

    // Operators
    public static bool operator ==(Vector3 left, Vector3 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector3 left, Vector3 right)
    {
        return !left.Equals(right);
    }

    public static Vector3 operator -(Vector3 v)
    {
        return new Vector3(-v.X, -v.Y, -v.Z);
    }

    public static Vector3 operator +(Vector3 left, Vector3 right)
    {
        return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }

    public static Vector3 operator -(Vector3 left, Vector3 right)
    {
        return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }

    public static Vector3 operator *(Vector3 left, Vector3 right)
    {
        return new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
    }

    public static Vector3 operator /(Vector3 left, Vector3 right)
    {
        return new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
    }

    public static Vector3 operator +(Vector3 left, float f)
    {
        return new Vector3(left.X + f, left.Y + f, left.Z + f);
    }

    public static Vector3 operator -(Vector3 left, float f)
    {
        return new Vector3(left.X - f, left.Y - f, left.Z - f);
    }

    public static Vector3 operator *(Vector3 left, float f)
    {
        return new Vector3(left.X * f, left.Y * f, left.Z * f);
    }

    public static Vector3 operator /(Vector3 left, float f)
    {
        return new Vector3(left.X / f, left.Y / f, left.Z / f);
    }
}
