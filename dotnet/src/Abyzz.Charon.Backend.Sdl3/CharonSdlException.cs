namespace Charon.Sdl3;

public class CharonSdlException : Exception
{
    public CharonSdlException() : this(SDL.SDL3.SDL_GetError() ?? "unknown error") { }
    public CharonSdlException(string message) : base(message) { }
    public CharonSdlException(string message, Exception inner) : base(message, inner) { }
}
