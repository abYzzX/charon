using SDL;

namespace Charon.Sdl3;

public interface ISdlEventManager
{
    IDisposable RegisterEventHandler(ISdlEventHandler handler, params SDL_EventType[] eventTypes);
    IDisposable RegisterEventHandler(Action<SDL_Event> action, params SDL_EventType[] eventTypes);
}
