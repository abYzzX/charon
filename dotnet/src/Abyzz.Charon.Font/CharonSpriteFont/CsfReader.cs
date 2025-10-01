using System.Text;

namespace Charon.Font.CompiledSpriteFont;

public class CsfFileConsts
{
    public static char[] Magic { get; } = "CSF".ToArray();
    public static byte Version { get; } = 1;
}

public class CsfReader
{
    
}

public static class CsfWriter
{
    public static void Write(string filename, SpriteFont font)
    {
        using var fs = File.OpenWrite(filename);
        using var writer = new BinaryWriter(fs);
        
        writer.Write(CsfFileConsts.Magic);
        writer.Write(CsfFileConsts.Version);
        writer.Write(Convert.ToUInt16(font.Size));
        writer.Write(Convert.ToUInt16(font.LineHeight));
        
    }
}
