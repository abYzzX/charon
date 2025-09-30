using Charon.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Charon.ContentPipeline;

public class FileSystemContentManager : IContentManager
{
    public required IOptions<FileSystemContentManagerSettings> Settings { protected get; init; }
    public required ILogger<FileSystemContentManager> Logger { protected get; init; }
    public required ICollection<IContentLoader> Loaders { protected get; init; }

    private string GetFilePath(string path)
    {
        return Path.IsPathRooted(path)
            ? path
            : Path.Combine(Settings.Value.RootPath?.EnsureEndsWith("/") ?? "./", path);
    }

    public IContentLoader GetContentLoader<TContentType>(string path)
    {
        var extension = Path.GetExtension(path);
        return Loaders.FirstOrDefault(x =>
                   x.ContentType == typeof(TContentType) &&
                   x.SupportedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
               ?? throw new CharonContentException($"No loader for extension: {extension}");
    }

    public Stream LoadStream(string path)
    {
        Logger.LogDebug($"Loading stream: {path}");
        var filePath = GetFilePath(path);
        if (!File.Exists(filePath))
        {
            Logger.LogError($"File not found: {filePath}");
            throw new CharonContentException($"File not found: {filePath}");
        }

        return File.OpenRead(filePath);
    }
}
