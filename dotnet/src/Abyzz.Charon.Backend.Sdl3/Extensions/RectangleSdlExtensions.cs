using Charon.Geom;
using SDL;

namespace Charon.Sdl3;

internal static class RectangleSdlExtensions
{
    internal static SDL_FRect ToFRect(this Rectangle r)
    {
        return new SDL_FRect() { x = r.X, y = r.Y, w = r.Width, h = r.Height };
    }
}
