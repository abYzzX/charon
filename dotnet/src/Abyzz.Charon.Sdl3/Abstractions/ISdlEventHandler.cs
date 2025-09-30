using SDL;

namespace Charon.Sdl3;

public interface ISdlEventHandler
{
    void HandleEvent(SDL_Event e);
}
