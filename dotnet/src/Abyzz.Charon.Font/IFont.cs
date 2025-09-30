using Charon.Math;

namespace Charon.Font;

public interface IFont
{
    string Name { get; }
    float Size { get; }
    int LineHeight { get; }
    ITexture Texture { get; }
    
    Vector2 MeasureString(string text);
    IFontGlyph? GetGlyph(char c);
}
