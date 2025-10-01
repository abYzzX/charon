using Charon.Modularity;

namespace Charon.Font;

public static class BmfFontDataToSpriteFontConverter
{
    public static SpriteFont Convert(BmFontData data, ITexture texture)
    {
        return SpriteFont.Create(
            name: data.Info.Face,
            size: data.Info.Size,
            lineHeight: data.Common.LineHeight,
            texture: texture,
            data.Chars.Select(x => new SpriteFontGlyph()
            {
                Character = System.Convert.ToChar(x.Id),
                Height = x.Height,
                Width = x.Width,
                XOffset = x.XOffset,
                YOffset = x.YOffset,
                XAdvance = x.XAdvance,
                X = x.X,
                Y = x.Y
            }).ToDictionary(x => x.Character, x => x as IFontGlyph));
    }
}

