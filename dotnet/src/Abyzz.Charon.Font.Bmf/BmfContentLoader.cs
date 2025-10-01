using System.IO.Compression;
using Charon.ContentPipeline;
using Charon.Exceptions;
using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.Logging;

namespace Charon.Font;

[ExposeServices(typeof(IContentLoader))]
public class BmfContentLoader : IContentLoader, ITransientDependency
{
    private IContentManager? _contentManager = default;
    
    public Type ContentType { get; } = typeof(IFont);   
    public string Name { get; } = "BMFont";
    public IReadOnlyCollection<string> SupportedExtensions { get; } = [".fnt", ".cfnt"];

    public required Func<IContentManager> ContentManagerFactory { private get; init; }
    public required ILogger<BmfContentLoader> Logger { private get; init; }
    
    public object? Load(Stream stream, string filename)
    {
        if (filename.EndsWith(".fnt", StringComparison.OrdinalIgnoreCase))
        {
            return LoadFont(stream);       
        }
        
        if (filename.EndsWith(".cfnt", StringComparison.OrdinalIgnoreCase))
        {
            return LoadCompressedFont(stream);      
        }

        throw new CharonContentException("Unknown file extension");
    }
    
    private IFont LoadCompressedFont(Stream stream)
    {
        Logger.LogDebug("Loading compressed font");
        var zip = new ZipArchive(stream, ZipArchiveMode.Read);
        try
        {
            var fntEntry = zip.Entries.FirstOrDefault(x => x.Name.EndsWith(".fnt", StringComparison.OrdinalIgnoreCase));
            if (fntEntry is null)
            {
                throw new CharonContentException("No fnt file found in archive");
            }

            using var fntStream = fntEntry.Open();
            var fntData = ReadFntFile(fntStream);
            var contentManager = ContentManagerFactory();
            var textureEntry = zip.GetEntry(fntData.Pages.First().File);
            using var textureStream = textureEntry?.Open();
            var texture = contentManager.LoadTexture(textureEntry.Name, textureStream);
            return BmfFontDataToSpriteFontConverter.Convert(fntData, texture);       
        }
        finally
        {
            zip.Dispose();
        }
    }
    
    private IFont LoadFont(Stream stream)
    {
        Logger.LogDebug("Loading font");
        var fntData = ReadFntFile(stream);
        var contentManager = ContentManagerFactory();
        var texture = contentManager.LoadTexture(fntData.Pages.First().File);
        return BmfFontDataToSpriteFontConverter.Convert(fntData, texture);      
    }

    private ITexture LoadTexture(string path)
    {
        _contentManager ??= ContentManagerFactory();
        return _contentManager.LoadTexture(path);       
    }

    private BmFontData? ReadFntFile(Stream stream)
    {
        using var fntReader = new StreamReader(stream);
        var fntContent = fntReader.ReadToEnd();
        return fntContent.Contains("xml", StringComparison.OrdinalIgnoreCase)
            ? BmFontData.LoadFromXml(fntContent)
            : BmFontData.Load(fntContent);
    }
}
