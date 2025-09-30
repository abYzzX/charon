namespace Charon;

public interface IContentLoader
{
    Type ContentType { get; }   
    string Name { get; }
    IReadOnlyCollection<string> SupportedExtensions { get; }
    object? Load(Stream stream, string filename);    
}
