using SDL;

namespace Charon.Sdl3;

internal static class BlendModeSdlExtensions
{
    public static SDL_BlendMode ToSDLBlendMode(this BlendMode mode)
    {
        return mode switch
        {
            BlendMode.None => SDL_BlendMode.SDL_BLENDMODE_NONE,
            BlendMode.Blend => SDL_BlendMode.SDL_BLENDMODE_BLEND,
            BlendMode.Add => SDL_BlendMode.SDL_BLENDMODE_ADD,
            BlendMode.Modify => SDL_BlendMode.SDL_BLENDMODE_MOD,
            BlendMode.Multiply => SDL_BlendMode.SDL_BLENDMODE_MUL,
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
        };
    }
}
