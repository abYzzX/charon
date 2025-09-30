using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.Options;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(
    typeof(ICharonGame),
    typeof(IRendererAccessor),
    typeof(IWindowAccessor)
    )]
internal class CharonSdl3Game : ICharonGame, IRendererAccessor, IWindowAccessor, ISdlEventHandler, ISingletonDependency
{
    private readonly List<IGlobalService> _globalServices;
    private bool _isRunning = false;

    public required Func<IGameTime> GameTimeFactory { private get; init; }
    public required ISdlFactory SdlFactory { private get; init; }
    public required IOptions<Sdl3Settings> Settings { private get; init; }
    public required ISdlEventManager SdlEventManager { private get; init; }

    public IWindow Window { get; private set; } = default!;
    public IRenderer Renderer { get; private set; } = default!;
    public IGpuDevice? GraphicsDevice { get; private set; }

    public CharonSdl3Game(ICollection<IGlobalService> globalServices)
    {
        _globalServices = globalServices.OrderBy(x => x.Order).ToList();
    }

    public void Initialize()
    {
        SdlFactory.InitializeSdl();
        Window = SdlFactory.CreateWindow();
        Renderer = SdlFactory.CreateRenderer(Window);

        foreach (var globalService in _globalServices)
        {
            globalService.Initialize();
        }
    }

    public void Run()
    {
        if (_isRunning)
        {
            throw new CharonInitializationException("Cannot run game while game is already running");
        }

        if (Window == null || Renderer == null)
        {
            throw new CharonInitializationException("Call Initialize before running game");
        }

        _isRunning = true;
        Window.Show();
        var targetFrameTime = 1000u / Settings.Value.TargetFps;
        var gameTime = GameTimeFactory();
        using var quitEventHandler = SdlEventManager.RegisterEventHandler(this, SDL_EventType.SDL_EVENT_QUIT);
        
        while (_isRunning)
        {
            var frameStart = SDL3.SDL_GetTicks();
            gameTime.Update();
            foreach (var globalService in _globalServices)
            {
                globalService.Update(gameTime);
            }

            Renderer.Clear(Settings.Value.ClearColor);

            foreach (var globalService in _globalServices)
            {
                globalService.Render();
            }

            Renderer.Present();

            if (Settings.Value.LimitFps)
            {
                var frameEnd = SDL3.SDL_GetTicks();
                var frameDuration = frameEnd - frameStart;
                if (Settings.Value.LimitFps && frameDuration < targetFrameTime)
                {
                    SDL3.SDL_Delay((uint)(targetFrameTime - frameDuration));
                }
            }
        }

        Shutdown();
    }

    public void Shutdown()
    {
        _isRunning = false;
        Renderer?.Dispose();
        Window?.Dispose();
    }

    public void Dispose()
    {
        Shutdown();
    }

    public void HandleEvent(SDL_Event e)
    {
        if (e.Type == SDL_EventType.SDL_EVENT_QUIT)
        {
            _isRunning = false;
        }
    }
}
