using Charon.Input;
using SDL;

namespace Charon.Sdl3;

internal static class SdlButtonsExtensions
{
    public static MouseButtons ToMouseButton(this SDLButton button)
    {
        return button switch
        {
            SDLButton.SDL_BUTTON_LEFT => MouseButtons.Left,
            SDLButton.SDL_BUTTON_MIDDLE => MouseButtons.Middle,
            SDLButton.SDL_BUTTON_RIGHT => MouseButtons.Right,
            SDLButton.SDL_BUTTON_X1 => MouseButtons.X1,
            SDLButton.SDL_BUTTON_X2 => MouseButtons.X2,
            _ => MouseButtons.None
        };
    }
        
}
