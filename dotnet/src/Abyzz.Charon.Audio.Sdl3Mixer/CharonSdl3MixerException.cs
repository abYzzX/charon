using SDL;

namespace Charon.Audio;

public class CharonSdl3MixerException : Exception
{
    public CharonSdl3MixerException() : this(SDL3.SDL_GetError() ?? "unknown error") { }
    public CharonSdl3MixerException(string message) : base(message) { }
    public CharonSdl3MixerException(string message, Exception inner) : base(message, inner) { }
}
