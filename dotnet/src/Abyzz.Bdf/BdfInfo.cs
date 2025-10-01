namespace Abyzz.Bdf;

public class BdfInfo
{
    public Version Version { get; internal set; }
    public string Comment { get; internal set; }
    public string FontName { get; internal set; }
    public int FontSize { get; internal set; }
    public int[] FontBoundingBox { get; internal set; }
    public Dictionary<string, string> Properties { get; } = new();
}
