namespace Charon.Font;

public interface IFontGlyph
{
    char Character { get; }
    int X { get; }
    int Y { get; }
    int Width { get; }
    int Height { get; }
    int XOffset { get; }
    int YOffset { get; }
    int XAdvance { get; }
}
