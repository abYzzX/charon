namespace Charon;

public interface IWindow : IDisposable
{
    string Title { get; set; }
    int Width { get; }
    int Height { get; }
    
    void Show();
    void Close();
}
