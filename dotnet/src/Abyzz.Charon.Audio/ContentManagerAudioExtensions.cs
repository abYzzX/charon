using Charon.Exceptions;

namespace Charon.Audio;

public static class ContentManagerAudioExtensions
{
    public static ISoundEffect LoadSoundEffect(this IContentManager manager, string path)
    {
        var loader = manager.GetContentLoader<ISoundEffect>(path);
        using var stream = manager.LoadStream(path);
        return loader.Load(stream, path) as ISoundEffect
               ?? throw new CharonContentException($"Loader returned null: {loader.GetType().FullName}");   
    }

    public static ISoundEffect LoadSoundEffect(this IContentManager manager, string path, Stream stream)
    {
        var loader = manager.GetContentLoader<ISoundEffect>(path);
        return loader.Load(stream, path) as ISoundEffect
               ?? throw new CharonContentException($"Loader returned null: {loader.GetType().FullName}");   
    }
}
