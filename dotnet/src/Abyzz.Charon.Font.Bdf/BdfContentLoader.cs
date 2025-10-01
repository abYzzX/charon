using Abyzz.Bdf;
using Charon.Modularity;
using Charon.Modularity.Attributes;

namespace Charon.Font;

[ExposeServices(typeof(IContentLoader))]
public class BdfContentLoader : IContentLoader, ITransientDependency
{
    public Type ContentType { get; } = typeof(IFont);
    public string Name { get; } = "Bitmap Distribution Format";
    public IReadOnlyCollection<string> SupportedExtensions { get; } = [".bdf"];
    
    public required BdfToSpriteFontConverter Converter { private get; init; }
    
    public object? Load(Stream stream, string filename)
    {
        var bdf = new BdfLoader().Load(stream, filename);
        return Converter.Convert(bdf, Charsets.PrintableAscii);
    }
}
