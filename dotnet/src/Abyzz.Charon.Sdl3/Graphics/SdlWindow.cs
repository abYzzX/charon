using Charon.Modularity;
using Charon.Modularity.Attributes;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(typeof(IWindow))]
internal unsafe class SdlWindow(SDL_Window* handle) : IWindow, ISingletonDependency
{
    public SDL_Window* Handle { get; } = handle;
    public string Title { get; set; }
    public int Width { get; }
    public int Height { get; }
    
    public void Show()
    {
        SDL3.SDL_ShowWindow(Handle);
    }

    public void Close()
    {
        SDL3.SDL_DestroyWindow(Handle);
    }

    public void Dispose()
    {
        Close();
    }
}
