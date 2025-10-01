namespace Abyzz.Bdf;

public class BdfLoader
{
    public BdfFont Load(Stream stream, string filename)
    {
            using var reader = new StreamReader(stream);
            var lines = reader.ReadToEnd().Split(BdfConsts.NewLines,
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var font = new BdfFont();
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                if (StartsWith(line, BdfConsts.Header))
                {
                    font.Info.Version = Version.Parse(GetLineValue(line));
                }
                else if (StartsWith(line, BdfConsts.Font))
                {
                    font.Info.FontName = GetLineValue(line);
                }
                else if (StartsWith(line, BdfConsts.Size))
                {
                    var values = GetLineInts(line);
                    font.Info.FontSize = values[0];
                }
                else if (StartsWith(line, BdfConsts.FontBoundingBox))
                {
                    font.Info.FontBoundingBox = GetLineInts(line);
                }
                else if (StartsWith(line, BdfConsts.Glyph.StartChar))
                {
                    ReadChar(font, lines, ref i);
                }
                else
                {
                    var parts = line.Split(" ", 2);
                    if (parts.Length == 2)
                    {
                        font.Info.Properties.TryAdd(parts[0], parts[1]);
                    }
                }
            }

            return font;
    }

    private void ReadChar(BdfFont font, string[] lines, ref int index)
    {
        var charCode = 0;
        int[] sWidth = [0, 0];
        int[] dWidth = [0, 0];
        int[] bBox = [0, 0, 0, 0];
        List<string> bitmap = new();
        var readBitmap = false;
        
        while (!lines[++index].StartsWith(BdfConsts.Glyph.EndChar))
        {
            var line = lines[index];
            if (StartsWith(line, BdfConsts.Glyph.Encoding))
            {
                charCode = GetLineInts(line)[0];
            }
            else if (StartsWith(line, BdfConsts.Glyph.SWidth))
            {
                sWidth = GetLineInts(line);
            }
            else if (StartsWith(line, BdfConsts.Glyph.DWidth))
            {
                dWidth = GetLineInts(line);
            }
            else if (StartsWith(line, BdfConsts.Glyph.BBox))
            {
                bBox = GetLineInts(line);
            }
            else if (line.Equals(BdfConsts.Glyph.Bitmap, StringComparison.OrdinalIgnoreCase))
            {
                readBitmap = true;
            }
            else if (readBitmap)
            {
                bitmap.Add(line);
            }
        }

        var glyph = new BdfFontGlyph()
        {
            Character = Convert.ToChar(charCode),
            Width = bBox[0],
            Height = bBox[1],
            XOffset = bBox[2],
            YOffset = bBox[3],
            XAdvance = dWidth[0],
            Bitmap = bitmap.Select(x => Enumerable.Range(0, x.Length / 2)
                .Select(i => Convert.ToByte(x.Substring(i * 2, 2), 16))
                .ToArray()).ToArray()
        };
        font.AddGlyph(Convert.ToChar(charCode), glyph);
    }

    private static bool StartsWith(string line, string value) => 
        line.StartsWith(value + " ", StringComparison.OrdinalIgnoreCase);

    private static string GetLineValue(string line)
    {
        return line.Substring(line.IndexOf(' ')).Trim();
    }
    
    private static int[] GetLineInts(string line)
    {
        return GetLineValue(line)
            .Split(' ', StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
