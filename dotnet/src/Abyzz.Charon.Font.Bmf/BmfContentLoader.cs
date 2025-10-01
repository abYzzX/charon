using Charon.ContentPipeline;
using Charon.Modularity;
using Charon.Modularity.Attributes;

namespace Charon.Font;

[ExposeServices(typeof(IContentLoader))]
public class BmfContentLoader : IContentLoader, ITransientDependency
{
    public Type ContentType { get; } = typeof(IFont);   
    public string Name { get; } = "BMFont";
    public IReadOnlyCollection<string> SupportedExtensions { get; } = [".fnt", ".cfnt"];
    
    public required Func<IContentManager> ContentManagerFactory { private get; init; }
    
    public object? Load(Stream stream, string filename)
    {
    }
}
