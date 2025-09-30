using SDL;

namespace Charon.Sdl3;

internal static class ColorSdlExtensions
{
    public static SDL_FColor ToFColor(this Color c)
    {
        return new SDL_FColor { r = c.R, g = c.G, b = c.B, a = c.A };
    }
}
