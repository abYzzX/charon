using Charon.Modularity;
using Charon.Modularity.Attributes;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(typeof(ITexture))]
internal unsafe class SdlTexture : ITexture, IDisposable, ITransientDependency
{
    public SDL_Texture* Handle { get; }
    
    public TextureFormat Format { get; }
    public int Width { get; }
    public int Height { get; }

    public SdlTexture(SDL_Texture* handle, TextureFormat format, int width, int height)
    {
        Handle = handle;
        Format = format;
        Width = width;
        Height = height;
    }

    public void Dispose()
    {
        SDL3.SDL_DestroyTexture(Handle);
    }
}
