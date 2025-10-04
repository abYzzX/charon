namespace Charon.Audio;

public class Sdl3MixerSettings
{
    public int Channels { get; set; } = 2;
    public int Frequency { get; set; } = 48000;
    public int Bits { get; set; } = 16;
    public int TrackPoolSize { get; set; } = 32;
    public float MasterVolume { get; set; } = 1.0f;
    public float MusicVolume { get; set; } = 1.0f;
    public float EffectVolume { get; set; } = 1.0f;
}
