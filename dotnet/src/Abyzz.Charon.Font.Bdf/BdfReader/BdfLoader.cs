using Charon.Modularity;
using Microsoft.Extensions.Logging;

namespace Charon.Font.BdfReader;

public class BdfLoader : ITransientDependency
{
    public required ILogger<BdfLoader> Logger { private get; init; }
    
    public BdfFont Load(Stream stream, string filename)
    {
        try
        {
            Logger.LogDebug("Loading BDF font...");
            using var reader = new StreamReader(stream);
            var lines = reader.ReadToEnd().Split(BdfConsts.NewLines,
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var font = new BdfFont();
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                Logger.LogTrace("BDFLoader: {LineNumber:0000}: {Line}", i, line);

                if (StartsWith(line, BdfConsts.Header))
                {
                    font.Info.Version = Version.Parse(GetLineValue(line));
                    Logger.LogTrace("  - Version: {Version}", font.Info.Version);
                }
                else if (StartsWith(line, BdfConsts.Font))
                {
                    font.Info.FontName = GetLineValue(line);
                    Logger.LogTrace("  - Font Name: {FontName}", font.Info.FontName);
                }
                else if (StartsWith(line, BdfConsts.Size))
                {
                    var values = GetLineInts(line);
                    font.Info.FontSize = values[0];
                    Logger.LogTrace("  - Font Size: {Size}, ResX: {ResX}, ResY: {ResY}",
                        values[0], values[1], values[2]);
                }
                else if (StartsWith(line, BdfConsts.FontBoundingBox))
                {
                    font.Info.FontBoundingBox = GetLineInts(line);
                    Logger.LogTrace("  - Font Bounding Box: X: {X}, Y: {Y}, XOff: {XOff}, YOff: {YOff}",
                        font.Info.FontBoundingBox[0], font.Info.FontBoundingBox[1],
                        font.Info.FontBoundingBox[2], font.Info.FontBoundingBox[3]);
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
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error loading BDF font");
            return null;
        }
    }

    private void ReadChar(BdfFont font, string[] lines, ref int index)
    {
        Logger.LogTrace("  Reading character...");
        
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
                Logger.LogTrace("    - Character Code: {Code}", charCode);
            }
            else if (StartsWith(line, BdfConsts.Glyph.SWidth))
            {
                sWidth = GetLineInts(line);
                Logger.LogTrace("    - Character scale width: X0: {SWidth0}, Y0: {SWidth1}", sWidth[0], sWidth[1]);
            }
            else if (StartsWith(line, BdfConsts.Glyph.DWidth))
            {
                dWidth = GetLineInts(line);
                Logger.LogTrace("    - Character delta width: X0: {DWidth0}, Y0: {DWidth1}", dWidth[0], dWidth[1]);
            }
            else if (StartsWith(line, BdfConsts.Glyph.BBox))
            {
                bBox = GetLineInts(line);
                Logger.LogTrace("    - Character bounding box: X0: {BBox0}, Y0: {BBox1}, XOff: {BBox2}, YOff: {BBox3}",
                    bBox[0], bBox[1], bBox[2], bBox[3]);
            }
            else if (line.Equals(BdfConsts.Glyph.Bitmap, StringComparison.OrdinalIgnoreCase))
            {
                readBitmap = true;
                Logger.LogTrace("    - Character bitmap...");
            }
            else if (readBitmap)
            {
                bitmap.Add(line);
                Logger.LogTrace("      - {Line}", line);
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
        Logger.LogTrace("  - Character: {Char}", charCode);
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
