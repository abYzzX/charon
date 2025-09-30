using Charon.Modularity;
using Charon.Modularity.Attributes;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(typeof(IGameTime))]
public class SdlGameTime : IGameTime, IScopedDependency
{
    private ulong _lastTicks;
    public float TotalElapsedTime { get; protected set; } = 0.0f;
    public float DeltaTime { get; protected set; } = 0.0f;

    public virtual void Update()
    {
        var now = SDL3.SDL_GetTicks();
        DeltaTime = (now - _lastTicks) / 1000f;
        TotalElapsedTime += DeltaTime;
        _lastTicks = now;
    }
}
