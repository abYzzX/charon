namespace Charon.SDL3;

public readonly record struct SDLBool
{
    private readonly byte value;

    internal const byte FALSE_VALUE = 0;
    internal const byte TRUE_VALUE = 1;

    internal SDLBool(byte value)
    {
        this.value = value;
    }

    public static implicit operator bool(SDLBool b)
    {
        return b.value != FALSE_VALUE;
    }

    public static implicit operator SDLBool(bool b)
    {
        return new SDLBool(b ? TRUE_VALUE : FALSE_VALUE);
    }

    public bool Equals(SDLBool other)
    {
        return other.value == value;
    }

    public override int GetHashCode()
    {
        return value.GetHashCode();
    }
}
