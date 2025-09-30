namespace Charon.Font.BdfReader;

public class BdfFontGlyph
{
    public char Character { get; init; }
    public int X { get; init; }
    public int Y { get; init; }
    public int Width { get; init; }
    public int Height { get; init; }
    public int XOffset { get; init; }
    public int YOffset { get; init; }
    public int XAdvance { get; init; }
    public IReadOnlyList<byte[]> Bitmap { get; init; } = [];    
}
