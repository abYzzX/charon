using Charon.Modularity;
using Charon.Modularity.Attributes;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(typeof(ITextureFactory))]
internal unsafe class SdlTextureFactory : ITextureFactory, IScopedDependency
{
    public required IRendererAccessor RendererAccessor { private get; init; }

    public ITexture Create(int width, int height, TextureFormat? format = null)
    {
        if (RendererAccessor.Renderer is not SdlRenderer sdlRenderer)
        {
            throw new CharonInitializationException("SdlRenderer is required.");       
        }
        
        format ??= TextureFormat.ARGB8;
        var pixelFormat = format.Value.ToPixelFormat();
        return new SdlTexture(SDL3.SDL_CreateTexture(sdlRenderer.Handle, pixelFormat,
            SDL_TextureAccess.SDL_TEXTUREACCESS_TARGET, width, height), format.Value, width, height);
    }
}

internal static class TextureFormatSdlExtensions
{
    public static SDL_PixelFormat ToPixelFormat(this TextureFormat format)
    {
        return format switch
        {
            TextureFormat.ARGB8 => SDL_PixelFormat.SDL_PIXELFORMAT_ARGB8888,
            TextureFormat.BGRA8 => SDL_PixelFormat.SDL_PIXELFORMAT_BGRA8888,
            TextureFormat.RGB565 => SDL_PixelFormat.SDL_PIXELFORMAT_RGB565,
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
        };
    }
}
