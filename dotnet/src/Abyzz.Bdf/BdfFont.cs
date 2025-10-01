using System.Numerics;

namespace Abyzz.Bdf;

public class BdfFont
{
    private readonly Dictionary<char, BdfFontGlyph> _glyphs = new();

    public string Name { get => Info.FontName; }
    public float Size { get => Info.FontSize; }
    public int LineHeight { get => Info.FontBoundingBox[1] - Info.FontBoundingBox[3]; }

    public BdfInfo Info { get; } = new();

    public IReadOnlyDictionary<char, BdfFontGlyph> Glyphs { get => _glyphs; }


    public Vector2 MeasureString(string text)
    {
        var width = text.Select(c => GetGlyph(c)?.Width ?? 0).Sum();
        var lineCount = text.Split(["\r\n", "\r", "\n"], StringSplitOptions.None).Length;
        return new Vector2(width, LineHeight * lineCount);
    }

    public BdfFontGlyph? GetGlyph(char c)
    {
        return Glyphs.GetValueOrDefault(c);
    }

    internal void AddGlyph(char glyph, BdfFontGlyph fontGlyph)
    {
        _glyphs.Add(glyph, fontGlyph);
    }
}
