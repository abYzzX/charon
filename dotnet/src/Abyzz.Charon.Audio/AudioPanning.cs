namespace Charon.Audio;

public readonly struct AudioPanning(float left, float right) : IEquatable<AudioPanning>
{
    public float Left { get; } = System.Math.Clamp(left, 0f, 1f);
    public float Right { get; } = System.Math.Clamp(right, 0f, 1f);

    public bool Equals(AudioPanning other)
    {
        return Left.Equals(other.Left) && Right.Equals(other.Right);
    }

    public override bool Equals(object? obj)
    {
        return obj is AudioPanning other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Left, Right);
    }

    public static bool operator==(AudioPanning a, AudioPanning b) => a.Equals(b);
    public static bool operator!=(AudioPanning a, AudioPanning b) => !a.Equals(b);
    
    public static AudioPanning operator+(AudioPanning a, AudioPanning b) => new(a.Left + b.Left, a.Right + b.Right);
    public static AudioPanning operator-(AudioPanning a, AudioPanning b) => new(a.Left - b.Left, a.Right - b.Right);
    public static AudioPanning operator*(AudioPanning a, AudioPanning b) => new(a.Left * b.Left, a.Right * b.Right);
    public static AudioPanning operator/(AudioPanning a, AudioPanning b) => new(a.Left / b.Left, a.Right / b.Right);

    public static AudioPanning operator+(AudioPanning a, float b) => new(a.Left + b, a.Right + b);
    public static AudioPanning operator-(AudioPanning a, float b) => new(a.Left - b, a.Right - b);
    public static AudioPanning operator*(AudioPanning a, float b) => new(a.Left * b, a.Right * b);
    public static AudioPanning operator/(AudioPanning a, float b) => new(a.Left / b, a.Right / b);
}
