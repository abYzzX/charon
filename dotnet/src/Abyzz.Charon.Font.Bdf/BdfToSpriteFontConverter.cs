using Abyzz.Bdf;
using Charon.Modularity;

namespace Charon.Font;

public class BdfToSpriteFontConverter : ITransientDependency
{
    public required IRendererAccessor Renderer { private get; init; }
    public required IRenderBatch RenderBatch { private get; init; }
    public required ITextureFactory TextureFactory { private get; init; }

    public SpriteFont Convert(BdfFont font, params string[] characterSets)
    {
        var fullCharset = new string(string.Join("", characterSets).Distinct().ToArray());
        var textureSize = font.MeasureString(fullCharset);
        var texture = TextureFactory.Create((int)textureSize.X, (int)textureSize.Y);
        var glyphs = new Dictionary<char, IFontGlyph>();
        var points = new List<Vector2>();
        
        RenderCharacterSet(font, fullCharset, ref points, ref glyphs);
        
        using (Renderer.Renderer.SetRenderTarget(texture))
        {
            Renderer.Renderer.Clear(Color.Transparent);
            using (RenderBatch.Begin())
            {
                RenderBatch.DrawPoints(Color.White, points.ToArray());
            }
        }
        
        return SpriteFont.Create(font.Name, font.Size, font.LineHeight, texture, glyphs);
    }

    private void RenderCharacterSet(BdfFont font, string characterSet, ref List<Vector2> points, ref Dictionary<char, IFontGlyph> glyphs)
    {
        var characterX = 0;
        foreach (var character in characterSet)
        {
            var glyph = font.GetGlyph(character);
            var y = 0;
            foreach (var lineBmp in glyph.Bitmap)
            {
                var x = characterX;
                foreach (var b in lineBmp)
                {
                    for (var i = 0; i < 8; i++, x++)
                    {
                        var isSet = (b & (1 << (7 - i))) != 0;
                        if (isSet)
                        {
                            points.Add(new Vector2(x, y));
                        }
                    }
                }

                y++;
            }
            
            glyphs.Add(glyph.Character, new SpriteFontGlyph()
            {
                Character = glyph.Character,
                X = characterX,
                Y = 0,
                Width = glyph.Width,
                Height = glyph.Height,
                XOffset = glyph.XOffset,
                YOffset = glyph.YOffset,
                XAdvance = glyph.XAdvance,
            });
            characterX += glyph.Width;
        }
    }
}
