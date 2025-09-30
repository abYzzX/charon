namespace Charon;

public interface IContentManager
{
    Stream LoadStream(string path);
    IContentLoader GetContentLoader<TContentType>(string path);

}
