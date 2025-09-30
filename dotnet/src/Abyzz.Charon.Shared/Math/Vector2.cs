namespace Charon;

public readonly struct Vector2(float x, float y) : IEquatable<Vector2>
{
    public static Vector2 Zero { get; } = new(0, 0);
    public static Vector2 One { get; } = new(1, 1);
    public static Vector2 UnitX { get; } = new(1, 0);
    public static Vector2 UnitY { get; } = new(0, 1);

    public static Vector2 Up { get; } = new(0, -1);
    public static Vector2 Down { get; } = new(0, 1);
    public static Vector2 Left { get; } = new(-1, 0);
    public static Vector2 Right { get; } = new(1, 0);

    public float X { get; } = x;
    public float Y { get; } = y;

    public float Length
    {
        get => MathF.Sqrt(X * X + Y * Y);
    }

    public float LengthSquared
    {
        get => X * X + Y * Y;
    }

    public float Angle
    {
        get => MathF.Atan2(Y, X); // Radiant
    }

    public float AngleInDegrees
    {
        get => Angle * 180 / MathF.PI;
    }

    public Vector2() : this(0, 0) { }
    public Vector2(float v) : this(v, v) { }

    public override string ToString()
    {
        return $"Vec2[{nameof(X)}: {X}, {nameof(Y)}: {Y}]";
    }

    public bool Equals(Vector2 other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector2 other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static float Distance(Vector2 left, Vector2 right)
    {
        return (left - right).Length;
    }

    public static float DistanceSquared(Vector2 left, Vector2 right)
    {
        return (left - right).LengthSquared;
    }

    public static float Dot(Vector2 left, Vector2 right)
    {
        return left.X * right.X + left.Y * right.Y;
    }

    public static float Cross(Vector2 left, Vector2 right)
    {
        return left.X * right.Y - left.Y * right.X;
    }

    public static Vector2 Normalize(Vector2 v)
    {
        return v.Length > 0 ? v / v.Length : Zero;
    }

    public static Vector2 Lerp(Vector2 from, Vector2 to, float t)
    {
        return from + (to - from) * t;
    }

    public static Vector2 Rotate(Vector2 v, float angle)
    {
        var cos = MathF.Cos(angle);
        var sin = MathF.Sin(angle);
        return new Vector2(v.X * cos - v.Y * sin, v.X * sin + v.Y * cos);
    }

    public static Vector2 RotateDegrees(Vector2 v, float angleDegrees)
    {
        return Rotate(v, angleDegrees * MathF.PI / 180);
    }

    // Operators
    public static bool operator ==(Vector2 left, Vector2 right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector2 left, Vector2 right)
    {
        return !left.Equals(right);
    }

    public static Vector2 operator -(Vector2 v)
    {
        return new Vector2(-v.X, -v.Y);
    }

    public static Vector2 operator +(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X + right.X, left.Y + right.Y);
    }

    public static Vector2 operator -(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X - right.X, left.Y - right.Y);
    }

    public static Vector2 operator *(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X * right.X, left.Y * right.Y);
    }

    public static Vector2 operator /(Vector2 left, Vector2 right)
    {
        return new Vector2(left.X / right.X, left.Y / right.Y);
    }

    public static Vector2 operator +(Vector2 left, float f)
    {
        return new Vector2(left.X + f, left.Y + f);
    }

    public static Vector2 operator -(Vector2 left, float f)
    {
        return new Vector2(left.X - f, left.Y - f);
    }

    public static Vector2 operator *(Vector2 left, float f)
    {
        return new Vector2(left.X * f, left.Y * f);
    }

    public static Vector2 operator /(Vector2 left, float f)
    {
        return new Vector2(left.X / f, left.Y / f);
    }
    
    public static implicit operator Vector2((float x, float y) v) => new(v.x, v.y);
    public static implicit operator Vector2(float[] v)
    {
        if (v.Length != 2)
        {
            throw new ArgumentException("Invalid array length");
        }
        
        return new(v[0], v[1]);
    }
}
