namespace Charon;

public readonly struct Color(byte r, byte g, byte b, byte a = 255) : IEquatable<Color>
{
    public float R { get; } = r / 255f;
    public float G { get; } = g / 255f;
    public float B { get; } = b / 255f;
    public float A { get; } = a / 255f;

    public uint Value { get; } = (uint)((a << 24) | (b << 16) | (g << 8) | r);

    public Color(uint abgr) : this(
        (byte)(abgr >> 0),
        (byte)(abgr >> 8),
        (byte)(abgr >> 16),
        (byte)(abgr >> 24))
    {
    }

    public static Color Random(byte? alpha = null)
    {
        var rand = System.Random.Shared;
        var bytes = new byte[4];
        rand.NextBytes(bytes);
        return new Color(bytes[0], bytes[1], bytes[2], alpha ?? bytes[3]);
    }
    
    public bool Equals(Color other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Color other && Equals(other);
    }

    public override int GetHashCode()
    {
        return (int)Value;
    }

    public static Color Transparent { get; } = new(0);
    public static Color AliceBlue { get; } = new(0xfffff8f0);
    public static Color AntiqueWhite { get; } = new(0xffd7ebfa);
    public static Color Aqua { get; } = new(0xffffff00);
    public static Color Aquamarine { get; } = new(0xffd4ff7f);
    public static Color Azure { get; } = new(0xfffffff0);
    public static Color Beige { get; } = new(0xffdcf5f5);
    public static Color Bisque { get; } = new(0xffc4e4ff);
    public static Color Black { get; } = new(0xff000000);
    public static Color BlanchedAlmond { get; } = new(0xffcdebff);
    public static Color Blue { get; } = new(0xffff0000);
    public static Color BlueViolet { get; } = new(0xffe22b8a);
    public static Color Brown { get; } = new(0xff2a2aa5);
    public static Color BurlyWood { get; } = new(0xff87b8de);
    public static Color CadetBlue { get; } = new(0xffa09e5f);
    public static Color Chartreuse { get; } = new(0xff00ff7f);
    public static Color Chocolate { get; } = new(0xff1e69d2);
    public static Color Coral { get; } = new(0xff507fff);
    public static Color CornflowerBlue { get; } = new(0xffed9564);
    public static Color Cornsilk { get; } = new(0xffdcf8ff);
    public static Color Crimson { get; } = new(0xff3c14dc);
    public static Color Cyan { get; } = new(0xffffff00);
    public static Color DarkBlue { get; } = new(0xff8b0000);
    public static Color DarkCyan { get; } = new(0xff8b8b00);
    public static Color DarkGoldenrod { get; } = new(0xff0b86b8);
    public static Color DarkGray { get; } = new(0xffa9a9a9);
    public static Color DarkGreen { get; } = new(0xff006400);
    public static Color DarkKhaki { get; } = new(0xff6bb7bd);
    public static Color DarkMagenta { get; } = new(0xff8b008b);
    public static Color DarkOliveGreen { get; } = new(0xff2f6b55);
    public static Color DarkOrange { get; } = new(0xff008cff);
    public static Color DarkOrchid { get; } = new(0xffcc3299);
    public static Color DarkRed { get; } = new(0xff00008b);
    public static Color DarkSalmon { get; } = new(0xff7a96e9);
    public static Color DarkSeaGreen { get; } = new(0xff8bbc8f);
    public static Color DarkSlateBlue { get; } = new(0xff8b3d48);
    public static Color DarkSlateGray { get; } = new(0xff4f4f2f);
    public static Color DarkTurquoise { get; } = new(0xffd1ce00);
    public static Color DarkViolet { get; } = new(0xffd30094);
    public static Color DeepPink { get; } = new(0xff9314ff);
    public static Color DeepSkyBlue { get; } = new(0xffffbf00);
    public static Color DimGray { get; } = new(0xff696969);
    public static Color DodgerBlue { get; } = new(0xffff901e);
    public static Color Firebrick { get; } = new(0xff2222b2);
    public static Color FloralWhite { get; } = new(0xfff0faff);
    public static Color ForestGreen { get; } = new(0xff228b22);
    public static Color Fuchsia { get; } = new(0xffff00ff);
    public static Color Gainsboro { get; } = new(0xffdcdcdc);
    public static Color GhostWhite { get; } = new(0xfffff8f8);
    public static Color Gold { get; } = new(0xff00d7ff);
    public static Color Goldenrod { get; } = new(0xff20a5da);
    public static Color Gray { get; } = new(0xff808080);
    public static Color Green { get; } = new(0xff008000);
    public static Color GreenYellow { get; } = new(0xff2fffad);
    public static Color Honeydew { get; } = new(0xfff0fff0);
    public static Color HotPink { get; } = new(0xffb469ff);
    public static Color IndianRed { get; } = new(0xff5c5ccd);
    public static Color Indigo { get; } = new(0xff82004b);
    public static Color Ivory { get; } = new(0xfff0ffff);
    public static Color Khaki { get; } = new(0xff8ce6f0);
    public static Color Lavender { get; } = new(0xfffae6e6);
    public static Color LavenderBlush { get; } = new(0xfff5f0ff);
    public static Color LawnGreen { get; } = new(0xff00fc7c);
    public static Color LemonChiffon { get; } = new(0xffcdfaff);
    public static Color LightBlue { get; } = new(0xffe6d8ad);
    public static Color LightCoral { get; } = new(0xff8080f0);
    public static Color LightCyan { get; } = new(0xffffffe0);
    public static Color LightGoldenrodYellow { get; } = new(0xffd2fafa);
    public static Color LightGray { get; } = new(0xffd3d3d3);
    public static Color LightGreen { get; } = new(0xff90ee90);
    public static Color LightPink { get; } = new(0xffc1b6ff);
    public static Color LightSalmon { get; } = new(0xff7aa0ff);
    public static Color LightSeaGreen { get; } = new(0xffaab220);
    public static Color LightSkyBlue { get; } = new(0xffface87);
    public static Color LightSlateGray { get; } = new(0xff998877);
    public static Color LightSteelBlue { get; } = new(0xffdec4b0);
    public static Color LightYellow { get; } = new(0xffe0ffff);
    public static Color Lime { get; } = new(0xff00ff00);
    public static Color LimeGreen { get; } = new(0xff32cd32);
    public static Color Linen { get; } = new(0xffe6f0fa);
    public static Color Magenta { get; } = new(0xffff00ff);
    public static Color Maroon { get; } = new(0xff000080);
    public static Color MediumAquamarine { get; } = new(0xffaacd66);
    public static Color MediumBlue { get; } = new(0xffcd0000);
    public static Color MediumOrchid { get; } = new(0xffd355ba);
    public static Color MediumPurple { get; } = new(0xffdb7093);
    public static Color MediumSeaGreen { get; } = new(0xff71b33c);
    public static Color MediumSlateBlue { get; } = new(0xffee687b);
    public static Color MediumSpringGreen { get; } = new(0xff9afa00);
    public static Color MediumTurquoise { get; } = new(0xffccd148);
    public static Color MediumVioletRed { get; } = new(0xff8515c7);
    public static Color MidnightBlue { get; } = new(0xff701919);
    public static Color MintCream { get; } = new(0xfffafff5);
    public static Color MistyRose { get; } = new(0xffe1e4ff);
    public static Color Moccasin { get; } = new(0xffb5e4ff);
    public static Color MonoGameOrange { get; } = new(0xff003ce7);
    public static Color NavajoWhite { get; } = new(0xffaddeff);
    public static Color Navy { get; } = new(0xff800000);
    public static Color OldLace { get; } = new(0xffe6f5fd);
    public static Color Olive { get; } = new(0xff008080);
    public static Color OliveDrab { get; } = new(0xff238e6b);
    public static Color Orange { get; } = new(0xff00a5ff);
    public static Color OrangeRed { get; } = new(0xff0045ff);
    public static Color Orchid { get; } = new(0xffd670da);
    public static Color PaleGoldenrod { get; } = new(0xffaae8ee);
    public static Color PaleGreen { get; } = new(0xff98fb98);
    public static Color PaleTurquoise { get; } = new(0xffeeeeaf);
    public static Color PaleVioletRed { get; } = new(0xff9370db);
    public static Color PapayaWhip { get; } = new(0xffd5efff);
    public static Color PeachPuff { get; } = new(0xffb9daff);
    public static Color Peru { get; } = new(0xff3f85cd);
    public static Color Pink { get; } = new(0xffcbc0ff);
    public static Color Plum { get; } = new(0xffdda0dd);
    public static Color PowderBlue { get; } = new(0xffe6e0b0);
    public static Color Purple { get; } = new(0xff800080);
    public static Color Red { get; } = new(0xff0000ff);
    public static Color RosyBrown { get; } = new(0xff8f8fbc);
    public static Color RoyalBlue { get; } = new(0xffe16941);
    public static Color SaddleBrown { get; } = new(0xff13458b);
    public static Color Salmon { get; } = new(0xff7280fa);
    public static Color SandyBrown { get; } = new(0xff60a4f4);
    public static Color SeaGreen { get; } = new(0xff578b2e);
    public static Color SeaShell { get; } = new(0xffeef5ff);
    public static Color Sienna { get; } = new(0xff2d52a0);
    public static Color Silver { get; } = new(0xffc0c0c0);
    public static Color SkyBlue { get; } = new(0xffebce87);
    public static Color SlateBlue { get; } = new(0xffcd5a6a);
    public static Color SlateGray { get; } = new(0xff908070);
    public static Color Snow { get; } = new(0xfffafaff);
    public static Color SpringGreen { get; } = new(0xff7fff00);
    public static Color SteelBlue { get; } = new(0xffb48246);
    public static Color Tan { get; } = new(0xff8cb4d2);
    public static Color Teal { get; } = new(0xff808000);
    public static Color Thistle { get; } = new(0xffd8bfd8);
    public static Color Tomato { get; } = new(0xff4763ff);
    public static Color Turquoise { get; } = new(0xffd0e040);
    public static Color Violet { get; } = new(0xffee82ee);
    public static Color Wheat { get; } = new(0xffb3def5);
    public static Color White { get; } = new(0xffffffff);
    public static Color WhiteSmoke { get; } = new(0xfff5f5f5);
    public static Color Yellow { get; } = new(0xff00ffff);
    public static Color YellowGreen { get; } = new(0xff32cd9a);
}
