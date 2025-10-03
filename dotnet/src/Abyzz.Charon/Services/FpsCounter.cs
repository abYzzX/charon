using Charon.Debugging;
using Charon.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Charon.Services;

public class FpsCounter : IFpsCounter, IGlobalService
{
    private int _fpsCounter;
    private float _fpsTimer;
    
    public float Fps { get; private set; } = 0;
    public float MinFps { get; private set; } = float.MaxValue;
    public float MaxFps { get; private set; } = float.MinValue;
    public float FrameTime { get; private set; }
    public int Order { get; } = -100;
    
    public required IDebugOverlay DebugOverlay { private get; init; }

    public void Initialize()
    {
        _fpsCounter = 0;
        _fpsTimer = 1.0f;
    }

    public void Update(IGameTime gameTime)
    {
        FrameTime = gameTime.DeltaTime;
        _fpsCounter++;
        _fpsTimer -= gameTime.DeltaTime;
        if (_fpsTimer <= 0.0f)
        {
            Fps = _fpsCounter;
            _fpsTimer = 1.0f;
            _fpsCounter = 0;
            MinFps = System.Math.Min(Fps, MinFps);
            MaxFps = System.Math.Max(Fps, MaxFps);
        }

        DebugOverlay.AddText($"FPS: {Fps:0.0} ({FrameTime * 1000:0}ms)");
    }

    public void Render() { }
}

public static class FpsCounterExtensions
{
    public static IServiceCollection AddFpsCounter(this IServiceCollection services)
    {
        services.AddSingleton<FpsCounter>();
        services.AddSingleton<IFpsCounter>(sp => sp.GetRequiredService<FpsCounter>());
        services.AddSingleton<IGlobalService>(sp => sp.GetRequiredService<FpsCounter>());
        return services;
    }

    public static ICharonGameBuilder AddFpsCounter(this ICharonGameBuilder builder)
    {
        builder.ConfigureServices(s => s.AddFpsCounter());
        return builder;
    }
}
