namespace Charon.Font;

public class SpriteFont : IFont
{
    private readonly Dictionary<char, IFontGlyph> _glyphs = new();
    
    protected IReadOnlyDictionary<char, IFontGlyph> Glyphs => _glyphs;
    
    public string Name { get; protected set;}
    public float Size { get; protected set;}
    public int LineHeight { get; protected set;}
    public ITexture Texture { get; protected set;}

    protected SpriteFont(string name, float size, int lineHeight, ITexture texture)
    {
        Name = name;
        Size = size;
        LineHeight = lineHeight;
        Texture = texture;   
    }
    
    public Vector2 MeasureString(string text)
    {
        var width = text.Select(GetCharWidth).Sum();
        var lineCount = text.Split(["\r\n", "\r", "\n"], StringSplitOptions.None).Length;
        return new Vector2(width, LineHeight * lineCount);   
    }

    public IFontGlyph? GetGlyph(char c)
    {
        return _glyphs.TryGetValue(c, out var value) 
            ? value
            : null;
    }

    protected float GetCharWidth(char c)
    {
        var charGlyph = GetGlyph(c);
        return charGlyph == null
            ? 0
            : charGlyph.Width + charGlyph.XAdvance;
    }
    
    protected void AddGlyph(IFontGlyph glyph)
    {
        _glyphs.Add(glyph.Character, glyph);   
    }

    public static SpriteFont Create(string name, float size, int lineHeight, ITexture texture,
        Dictionary<char, IFontGlyph> glyphs)
    {
        var font = new SpriteFont(name, size, lineHeight, texture);
        font._glyphs.AddRange(glyphs);
        return font;   
    }
}

public readonly struct SpriteFontGlyph : IFontGlyph
{
    public char Character { get; init; }
    public int X { get; init;  }
    public int Y { get; init;  }
    public int Width { get; init;  }
    public int Height { get; init;  }
    public int XOffset { get; init;  }
    public int YOffset { get; init;  }
    public int XAdvance { get; init;  }
}
