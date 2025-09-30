namespace Charon.Font.BdfReader;

internal static class BdfConsts
{
    public static string[] NewLines { get; } = [ "\r\n", "\n", "\r" ];
    
    public const string Header = "STARTFONT";
    public const string Font = "FONT";
    public const string Size = "SIZE";
    public const string FontBoundingBox = "FONTBOUNDINGBOX";

    public static class Glyph
    {
        public const string StartChar = "STARTCHAR";
        public const string Encoding = "ENCODING";
        public const string SWidth = "SWIDTH";
        public const string DWidth = "DWIDTH";
        public const string BBox = "BBX";
        public const string Bitmap = "BITMAP";
        public const string EndChar = "ENDCHAR";
    }
}
