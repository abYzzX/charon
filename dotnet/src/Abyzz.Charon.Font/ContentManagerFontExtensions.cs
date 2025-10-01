using Charon.Exceptions;

namespace Charon.Font;

public static class ContentManagerFontExtensions
{
    public static IFont LoadFont(this IContentManager manager, string path)
    {
        var loader = manager.GetContentLoader<IFont>(path);
        using var stream = manager.LoadStream(path);
        return loader.Load(stream, path) as IFont
               ?? throw new CharonContentException($"Loader returned null: {loader.GetType().FullName}");   
    }
    
    public static IFont LoadFont(this IContentManager manager, string path, Stream stream)
    {
        var loader = manager.GetContentLoader<IFont>(path);
        return loader.Load(stream, path) as IFont
               ?? throw new CharonContentException($"Loader returned null: {loader.GetType().FullName}");   
    }
}
