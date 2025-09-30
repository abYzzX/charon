using System.Runtime.InteropServices;
using Charon.Modularity;
using Charon.Modularity.Attributes;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(typeof(IContentLoader))]
public class SdlTextureLoader : IContentLoader, ITransientDependency
{
    private readonly SdlRenderer _sdlRenderer;

    public Type ContentType { get; } = typeof(ITexture);
    public string Name { get; } = "SdlTextureLoader";
    public IReadOnlyCollection<string> SupportedExtensions { get; } = [".png", ".jpg", ".jpeg", ".bmp"];   

    public SdlTextureLoader(IRendererAccessor rendererAccessor)
    {
        if (rendererAccessor.Renderer is not SdlRenderer sdlRenderer)
        {
            throw new CharonInitializationException("SdlRenderer is required.");
        }
        
        _sdlRenderer = sdlRenderer;
    }
    
    public unsafe object? Load(Stream stream, string filename)
    {
        var data = new byte[stream.Length];
        _ = stream.Read(data);
        var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        try
        {
            var ptr = handle.AddrOfPinnedObject();

            var io = SDL3.SDL_IOFromMem(ptr, new UIntPtr((uint)data.Length));
            if (io == null)
            {
                throw new CharonSdlException();
            }

            var surface = SDL3_image.IMG_Load_IO(io, true);
            if (surface == null)
            {
                throw new CharonSdlException();           
            }

            var texture = SDL3.SDL_CreateTextureFromSurface(_sdlRenderer.Handle, surface);
            SDL3.SDL_SetTextureScaleMode(texture, SDL_ScaleMode.SDL_SCALEMODE_LINEAR);        

            SDL3.SDL_DestroySurface(surface);

            return new SdlTexture(texture, TextureFormat.ARGB8, texture->w, texture->h);
        }
        finally
        {
            handle.Free();
        }        
    }
}
