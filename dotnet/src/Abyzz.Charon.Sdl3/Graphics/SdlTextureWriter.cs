using Charon.Modularity;
using Charon.Modularity.Attributes;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(typeof(ITextureWriter))]
internal unsafe class SdlTextureWriter : ITextureWriter, ITransientDependency
{
    public required IRendererAccessor RendererAccessor { private get; init; }
    
    public void SaveTexture(ITexture texture, string path)
    {
        if (texture is not SdlTexture sdlTexture)
            throw new ArgumentException("SdlTexture required.");

        if (RendererAccessor.Renderer is not SdlRenderer sdlRenderer)
            throw new ArgumentException("SdlRenderer required.");

        // Set render target to texture
        SDL3.SDL_SetRenderTarget(sdlRenderer.Handle, sdlTexture.Handle);

        // Read back into a new surface
        var rect = new SDL_Rect {x = 0, y = 0, w = sdlTexture.Width, h = sdlTexture.Height};
        var surface = SDL3.SDL_RenderReadPixels(sdlRenderer.Handle, &rect);

        // Reset render target
        SDL3.SDL_SetRenderTarget(sdlRenderer.Handle, null);

        if (surface == null)
            throw new CharonSdlException();

        // Save as PNG (SDL3_image)
        if (!SDL3_image.IMG_SavePNG(surface, path))
        {
            SDL3.SDL_DestroySurface(surface);
            throw new CharonSdlException();
        }

        // Free surface
        SDL3.SDL_DestroySurface(surface);
    }
}
