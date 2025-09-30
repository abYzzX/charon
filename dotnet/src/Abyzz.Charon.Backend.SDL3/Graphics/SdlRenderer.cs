using Charon.Geom;
using Charon.Math;
using Charon.Modularity;
using Charon.Modularity.Attributes;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(typeof(IRenderer))]
internal unsafe class SdlRenderer(SDL_Renderer* handle) : IRenderer, ISingletonDependency
{
    private Color _color = Color.Transparent;
    public SDL_Renderer* Handle { get; } = handle;

    public Color Color
    {
        get => _color;
        set
        {
            if (_color.Equals(value)) return;

            _color = value;
            SDL3.SDL_SetRenderDrawColorFloat(Handle, _color.R, _color.G, _color.B, _color.A);
        }
    }

    public Matrix2D Projection { get; set; } = Matrix2D.Identity;

    public void Clear(Color color)
    {
        Color = color;
        SDL3.SDL_RenderClear(Handle);
    }

    public void Present()
    {
        SDL3.SDL_RenderPresent(Handle);
    }

    public void Dispose()
    {
        SDL3.SDL_DestroyRenderer(Handle);
    }

    public IRenderer SetColor(Color color)
    {
        Color = color;
        return this;
    }
    
    public IDisposable SetRenderTarget(ITexture texture)
    {
        if (texture is not SdlTexture sdlTexture)
        {
            throw new ArgumentException("SdlTexture required.");
        }
        
        var oldTarget = SDL3.SDL_GetRenderTarget(Handle);
        SDL3.SDL_SetRenderTarget(Handle, sdlTexture.Handle);
        return new DisposableAction(() => SDL3.SDL_SetRenderTarget(Handle, oldTarget));   
    }
    
}
