namespace Charon.Audio;

public interface IAudioMixer
{
    /// <summary>
    /// Gets or sets the master volume (0.0 to 1.0).
    /// Affects all audio output.
    /// </summary>
    float MasterVolume { get; set; }

    /// <summary>
    /// Gets or sets the music volume (0.0 to 1.0).
    /// Multiplied with MasterVolume.
    /// </summary>
    float MusicVolume { get; set; }

    /// <summary>
    /// Gets or sets the sound effects volume (0.0 to 1.0).
    /// Multiplied with MasterVolume.
    /// </summary>
    float EffectVolume { get; set; }

    /// <summary>
    /// Plays a sound effect.
    /// </summary>
    /// <param name="sound">The sound effect to play.</param>
    /// <param name="loops">Number of times to loop. 1 = play once, -1 = infinite.</param>
    void PlaySound(ISoundEffect sound, int loops = 1);

    /// <summary>
    /// Plays music.
    /// </summary>
    /// <param name="music">The music to play.</param>
    /// <param name="loops">Number of times to loop. -1 = infinite.</param>
    void PlayMusic(IMusicPlayer music, int loops = -1);

    /// <summary>
    /// Plays music with a fade-in effect.
    /// </summary>
    /// <param name="music">The music to play.</param>
    /// <param name="fadeMs">Fade-in duration in milliseconds.</param>
    /// <param name="loops">Number of times to loop. -1 = infinite.</param>
    void PlayMusicFadeIn(IMusicPlayer music, int fadeMs, int loops = -1);
}
