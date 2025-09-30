using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.Logging;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(
    typeof(ISdlEventManager),
    typeof(IGlobalService)
)]
internal class SdlEventManager : ISdlEventManager, IGlobalService, ISingletonDependency
{
    private readonly IDictionary<SDL_EventType, HashSet<ISdlEventHandler>> _eventHandlers =
        new Dictionary<SDL_EventType, HashSet<ISdlEventHandler>>();

    public required ILogger<SdlEventManager> Logger { private get; init; }
    
    public int Order { get; } = int.MinValue;

    public void Initialize() { }

    public unsafe void Update(IGameTime gameTime)
    {
        var ev = new SDL_Event();
        while (SDL3.SDL_PollEvent(&ev))
        {
            if (_eventHandlers.TryGetValue(ev.Type, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler.HandleEvent(ev);
                }
            }
        }
    }

    public void Render() { }

    public IDisposable RegisterEventHandler(Action<SDL_Event> action, params SDL_EventType[] eventTypes)
    {
        return RegisterEventHandler(new ActionEventHandler(action), eventTypes);
    }
    
    public IDisposable RegisterEventHandler(ISdlEventHandler handler, params SDL_EventType[] eventTypes)
    {
        foreach (var eventType in eventTypes)
        {
            if (!_eventHandlers.ContainsKey(eventType))
            {
                _eventHandlers.Add(eventType, new HashSet<ISdlEventHandler>());
            }
            
            _eventHandlers[eventType].Add(handler);
        }

        return new DisposableAction(() =>
        {
            foreach (var evt in eventTypes)
            {
                _eventHandlers[evt].Remove(handler);
            }
        });
    }
    
    private class ActionEventHandler(Action<SDL_Event> action) : ISdlEventHandler
    {
        public void HandleEvent(SDL_Event e)
        {
            action(e);
        }
    }
}
