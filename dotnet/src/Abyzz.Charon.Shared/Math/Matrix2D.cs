namespace Charon;

public struct Matrix2D(float m11, float m12, float m21, float m22, float m31, float m32) : IEquatable<Matrix2D>
{
    public float M11 { get; set; } = m11;
    public float M12 { get; set; } = m12;
    public float M21 { get; set; } = m21;
    public float M22 { get; set; } = m22;
    public float M31 { get; set; } = m31;
    public float M32 { get; set; } = m32;

    public bool IsIdentity
    {
        get => Equals(Identity);
    }

    public static Matrix2D Identity
    {
        get => new(1, 0, 0, 1, 0, 0);
    }

    public static Matrix2D CreateTranslation(Vector2 translation) => CreateTranslation(translation.X, translation.Y);
    
    public static Matrix2D CreateTranslation(float x, float y)
    {
        return new Matrix2D(1, 0, 0, 1, x, y);
    }

    public static Matrix2D CreateScale(Vector2 scale) => CreateScale(scale.X, scale.Y);
    public static Matrix2D CreateScale(float sx, float sy)
    {
        return new Matrix2D(sx, 0, 0, sy, 0, 0);
    }

    public static Matrix2D CreateScale(Vector2 scale, Vector2 centerPoint) => CreateScale(scale.X, scale.Y, centerPoint);
    
    public static Matrix2D CreateScale(float sx, float sy, Vector2 centerPoint)
    {
        return
            CreateTranslation(-centerPoint.X, -centerPoint.Y) *
            CreateScale(sx, sy) *
            CreateTranslation(centerPoint.X, centerPoint.Y);
    }

    public static Matrix2D CreateRotation(float radians)
    {
        var c = MathF.Cos(radians);
        var s = MathF.Sin(radians);
        return new Matrix2D(c, s, -s, c, 0, 0);
    }

    public static Matrix2D CreateRotation(float radians, Vector2 centerPoint)
    {
        return
            CreateTranslation(-centerPoint.X, -centerPoint.Y) *
            CreateRotation(radians) *
            CreateTranslation(centerPoint.X, centerPoint.Y);
    }


    public static Matrix2D CreateSkew(Vector2 skew) => CreateSkew(skew.X, skew.Y);
    public static Matrix2D CreateSkew(float radiansX, float radiansY)
    {
        var tanX = MathF.Tan(radiansX);
        var tanY = MathF.Tan(radiansY);

        return new Matrix2D(
            1, tanY,
            tanX, 1,
            0, 0
        );
    }

    public static Matrix2D CreateSkew(Vector2 skew, Vector2 centerPoint) => CreateSkew(skew.X, skew.Y, centerPoint);
    
    public static Matrix2D CreateSkew(float radiansX, float radiansY, Vector2 centerPoint)
    {
        return
            CreateTranslation(-centerPoint.X, -centerPoint.Y) *
            CreateSkew(radiansX, radiansY) *
            CreateTranslation(centerPoint.X, centerPoint.Y);
    }

    public static Matrix2D CreateTransform(Vector2 position, float rotation, Vector2 scale, Vector2 centerPoint)
    {
        return
            CreateTranslation(position.X, position.Y) *
            CreateTranslation(-centerPoint.X, -centerPoint.Y) *
            CreateRotation(rotation) *
            CreateScale(scale.X, scale.Y) *
            CreateTranslation(centerPoint.X, centerPoint.Y);
    }

    public static Matrix2D operator *(Matrix2D a, Matrix2D b)
    {
        return new Matrix2D(
            a.M11 * b.M11 + a.M12 * b.M21,
            a.M11 * b.M12 + a.M12 * b.M22,
            a.M21 * b.M11 + a.M22 * b.M21,
            a.M21 * b.M12 + a.M22 * b.M22,
            a.M31 * b.M11 + a.M32 * b.M21 + b.M31,
            a.M31 * b.M12 + a.M32 * b.M22 + b.M32
        );
    }

    public static Matrix2D operator /(Matrix2D a, Matrix2D b)
    {
        if (!b.Invert(out var invB))
        {
            throw new InvalidOperationException("Matrix b is not invertible");
        }

        return a * invB;
    }

    public bool Invert(out Matrix2D result)
    {
        var det = M11 * M22 - M12 * M21;
        if (MathF.Abs(det) < 1e-6f)
        {
            result = Identity;
            return false;
        }

        var invDet = 1.0f / det;

        var m11 = M22 * invDet;
        var m12 = -M12 * invDet;
        var m21 = -M21 * invDet;
        var m22 = M11 * invDet;

        var m31 = -(M31 * m11 + M32 * m21);
        var m32 = -(M31 * m12 + M32 * m22);

        result = new Matrix2D(m11, m12, m21, m22, m31, m32);
        return true;
    }

    public Vector2 Transform(Vector2 v)
    {
        if (IsIdentity)
        {
            return v;       
        }
        
        return new Vector2(
            v.X * M11 + v.Y * M21 + M31,
            v.X * M12 + v.Y * M22 + M32
        );
    }

    public override string ToString()
    {
        return $"[{M11}, {M12}] [{M21}, {M22}] [{M31}, {M32}]";
    }

    public bool Equals(Matrix2D other)
    {
        return M11.Equals(other.M11) && M12.Equals(other.M12) && M21.Equals(other.M21) && M22.Equals(other.M22) &&
               M31.Equals(other.M31) && M32.Equals(other.M32);
    }

    public override bool Equals(object? obj)
    {
        return obj is Matrix2D other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(M11, M12, M21, M22, M31, M32);
    }
}
