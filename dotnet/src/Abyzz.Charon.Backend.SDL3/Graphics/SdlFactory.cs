using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.Options;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(typeof(ISdlFactory))]
internal unsafe class SdlFactory : ISdlFactory, ITransientDependency
{
    public required IOptions<Sdl3Settings> Settings { private get; init; }

    public void InitializeSdl()
    {
        var flags = SDL_InitFlags.SDL_INIT_VIDEO
                    | SDL_InitFlags.SDL_INIT_EVENTS;
        
        if (!SDL3.SDL_Init(flags))
        {
            throw new CharonSdlException();
        }
    }
    
    public IWindow CreateWindow()
    {
        var windowFlags = (SDL_WindowFlags)0;
        if (Settings.Value.Fullscreen) windowFlags |= SDL_WindowFlags.SDL_WINDOW_FULLSCREEN;
        if (Settings.Value.IsResizable) windowFlags |= SDL_WindowFlags.SDL_WINDOW_RESIZABLE;
        if (Settings.Value.CaptureMouse) windowFlags |= SDL_WindowFlags.SDL_WINDOW_MOUSE_CAPTURE;
        if (Settings.Value.UseOpenGl) windowFlags |= SDL_WindowFlags.SDL_WINDOW_OPENGL;
        if (Settings.Value.UseVulkan) windowFlags |= SDL_WindowFlags.SDL_WINDOW_VULKAN;

        
        
        var windowHandle = SDL3.SDL_CreateWindow(
            Settings.Value.Title, 
            Settings.Value.WindowWidth,
            Settings.Value.WindowHeight, windowFlags);

        if (windowHandle == null)
        {
            throw new CharonSdlException();
        }
            
        return new SdlWindow(windowHandle);
    }

    public IRenderer CreateRenderer(IWindow window)
    {
        if (window is not SdlWindow sdlWindow)
        {
            throw new CharonInitializationException("SdlWindow required to create a renderer.");
        }
        
        var rendererHandle = SDL3.SDL_CreateRenderer(sdlWindow.Handle, "");

        if (rendererHandle == null)
        {
            throw new CharonSdlException();
        }
        
        if (Settings.Value.VSync)
        {
            SDL3.SDL_SetRenderVSync(rendererHandle, -1);
        }
        
        return new SdlRenderer(rendererHandle);
    }

    public IGpuDevice CreateGpuDevice()
    {
        throw new NotImplementedException();
    }
}
