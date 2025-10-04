namespace Charon.Audio;

public class Sdl3MixerSettings
{
    public int Channels { get; set; } = 2;
    public int Frequency { get; set; } = 48000;
    public int Bits { get; set; } = 16;
    public int TrackPoolSize { get; set; } = 32;
}
