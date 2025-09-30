using Charon.Exceptions;

namespace Charon.ContentPipeline;

public static class ContentManagerExtensions
{
    public static ITexture LoadTexture(this IContentManager manager, string path)
    {
        var loader = manager.GetContentLoader<ITexture>(path);
        using var stream = manager.LoadStream(path);
        return loader.Load(stream, path) as ITexture
               ?? throw new CharonContentException($"Loader returned null: {loader.GetType().FullName}");
    }
}
