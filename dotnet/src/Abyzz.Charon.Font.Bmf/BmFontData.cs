using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Charon.Exceptions;

namespace Charon.Font;

[XmlRoot("font")]
public class BmFontData
{
    [XmlElement("info")]
    public FontInfo Info { get; set; }

    [XmlElement("common")]
    public FontCommon Common { get; set; }

    [XmlArray("pages")]
    [XmlArrayItem("page")]
    public FontPage[] Pages { get; set; }

    [XmlArray("chars")]
    [XmlArrayItem("char")]
    public FontChar[] Chars { get; set; }

    [XmlArray("kernings")]
    [XmlArrayItem("kerning")]
    public FontKerning[] Kernings { get; set; }

    public class FontInfo
    {
        [XmlAttribute("face")]
        public string Face { get; set; }

        [XmlAttribute("size")]
        public int Size { get; set; }

        [XmlAttribute("bold")]
        public int Bold { get; set; }

        [XmlAttribute("italic")]
        public int Italic { get; set; }

        [XmlAttribute("charset")]
        public string CharSet { get; set; }

        [XmlAttribute("stretchH")]
        public int StretchH { get; set; }

        [XmlAttribute("smooth")]
        public int Smooth { get; set; }

        [XmlAttribute("aa")]
        public int SuperSampling { get; set; }

        [XmlAttribute("padding")]
        public string Padding { get; set; }

        [XmlAttribute("spacing")]
        public string Spacing { get; set; }

        [XmlAttribute("outline")]
        public int Outline { get; set; }
    }

    public class FontCommon
    {
        [XmlAttribute("lineHeight")]
        public int LineHeight { get; set; }

        [XmlAttribute("base")]
        public int Base { get; set; }

        [XmlAttribute("scaleW")]
        public int ScaleW { get; set; }

        [XmlAttribute("scaleH")]
        public int ScaleH { get; set; }

        [XmlAttribute("pages")]
        public int Pages { get; set; }

        [XmlAttribute("packed")]
        public int Packed { get; set; }

        [XmlAttribute("alphaChnl")]
        public int AlphaChnl { get; set; }

        [XmlAttribute("redChnl")]
        public int RedChnl { get; set; }

        [XmlAttribute("blueChnl")]
        public int BlueChnl { get; set; }
    }

    public class FontPage
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("file")]
        public string File { get; set; }
    }

    public class FontChar
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }

        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        [XmlAttribute("xoffset")]
        public int XOffset { get; set; }

        [XmlAttribute("yoffset")]
        public int YOffset { get; set; }

        [XmlAttribute("xadvance")]
        public int XAdvance { get; set; }

        [XmlAttribute("page")]
        public int Page { get; set; }

        [XmlAttribute("chnl")]
        public int Channel { get; set; }
    }

    public class FontKerning
    {
        [XmlAttribute("first")]
        public int First { get; set; }

        [XmlAttribute("second")]
        public int Second { get; set; }

        [XmlAttribute("amount")]
        public int Amount { get; set; }
    }

    public static BmFontData? LoadFromXml(string xml)
    {
        var serializer = new XmlSerializer(typeof(BmFontData));
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        return (BmFontData?)serializer.Deserialize(stream);
    }

    public static BmFontData? Load(string content)
    {
        string GetStringValue(string line, string attribute)
        {
            var regex = @$"{attribute}=(.+?)(?: |$)";
            var match = Regex.Match(line, regex);
            return match.Success 
                ? match.Groups[1].Value
                : string.Empty;
        }
        
        int GetIntValue(string line, string attribute)
        {
            var value = GetStringValue(line, attribute);
            return int.TryParse(value, out var result) 
                ? result 
                : 0;
        }

        var data = new BmFontData();
        var charIdx = 0;
        
        foreach (var line in content.Split(["\r\n", "\r", "\n"], StringSplitOptions.None))
        {
            if (line.StartsWith("info", StringComparison.OrdinalIgnoreCase))
            {
                data.Info = new FontInfo
                {
                    Face = GetStringValue(line, "face"), 
                    Size = GetIntValue(line, "size"), 
                    Bold = GetIntValue(line, "bold"),
                    Italic = GetIntValue(line, "italic"),
                    CharSet = GetStringValue(line, "charset"),
                    StretchH = GetIntValue(line, "stretchH"),
                    Smooth = GetIntValue(line, "smooth"),
                    SuperSampling = GetIntValue(line, "aa"),
                    Padding = GetStringValue(line, "padding"),
                    Spacing = GetStringValue(line, "spacing"),
                    Outline = GetIntValue(line, "outline")
                };
            }
            else if (line.StartsWith("common", StringComparison.OrdinalIgnoreCase))
            {
                data.Common = new FontCommon
                {
                    LineHeight = GetIntValue(line, "lineHeight"), 
                    Base = GetIntValue(line, "base"), 
                    ScaleW = GetIntValue(line, "scaleW"),
                    ScaleH = GetIntValue(line, "scaleH"),
                    Pages = GetIntValue(line, "pages"),
                    Packed = GetIntValue(line, "packed")
                };

                if (data.Common.Pages > 1)
                {
                    throw new CharonContentException("Multiple pages are not supported at the moment.");
                }
            }
            else if (line.StartsWith("page", StringComparison.OrdinalIgnoreCase))
            {
                data.Pages = new FontPage[data.Common.Pages];
                for (var i = 0; i < data.Common.Pages; i++)
                {
                    data.Pages[i].Id = i;
                    data.Pages[i].File = GetStringValue(line, $"id={i} file");
                }
            }
            else if (line.StartsWith("chars", StringComparison.OrdinalIgnoreCase))
            {
                data.Chars = new FontChar[GetIntValue(line, "count")];
            }
            else if (line.StartsWith("char", StringComparison.OrdinalIgnoreCase))
            {
                data.Chars[charIdx++] = new FontChar
                {
                    Id = GetIntValue(line, "id"),
                    X = GetIntValue(line, "x"),
                    Y = GetIntValue(line, "y"),
                    Width = GetIntValue(line, "width"),
                    Height = GetIntValue(line, "height"),
                    XOffset = GetIntValue(line, "xoffset"),
                    YOffset = GetIntValue(line, "yoffset"),
                    XAdvance = GetIntValue(line, "xadvance"),
                    Page = GetIntValue(line, "page"),
                    Channel = GetIntValue(line, "chnl")
                };
            }
        }
        
        return data;
    }
}
