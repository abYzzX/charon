using Charon.Geom;

namespace Charon.Font;

public static class SpriteBatchExtensions
{
    public static void DrawString(this ISpriteBatch batch, IFont font, string text, Vector2 position, Color color)
    {
        var letterX = position.X;
        foreach (var character in text)
        {
            if (font.GetGlyph(character) is { } glyph)
            {
                var letterPosition = new Vector2(letterX + glyph.XOffset, position.Y + glyph.YOffset);
                batch.DrawSprite(font.Texture,
                    letterPosition,
                    color,
                    new Rectangle(glyph.X, glyph.Y, glyph.Width, glyph.Height),
                    Vector2.Zero,
                    0,
                    Vector2.One,
                    false,
                    false);
            
                letterX += glyph.XAdvance;
            }
            else
            {
                letterX += font.LineHeight;
            }
            
        }
    }
}
