namespace Charon.Audio;

public interface IMusicPlayer
{
    /// <summary>
    /// Gets or sets the volume of the music (0.0 to 1.0).
    /// </summary>
    float Volume { get; set; }

    /// <summary>
    /// Gets whether music is currently playing.
    /// </summary>
    bool IsPlaying { get; }

    /// <summary>
    /// Gets whether music is currently paused.
    /// </summary>
    bool IsPaused { get; }

    /// <summary>
    /// Plays music from the beginning.
    /// </summary>
    /// <param name="loops">Number of times to loop. -1 for infinite loop.</param>
    void Play(int loops = -1);

    /// <summary>
    /// Plays music with a fade-in effect.
    /// </summary>
    /// <param name="fadeMs">Fade-in duration in milliseconds.</param>
    /// <param name="loops">Number of times to loop. -1 for infinite loop.</param>
    void FadeIn(int fadeMs, int loops = -1);

    /// <summary>
    /// Fades out and stops the music.
    /// </summary>
    /// <param name="fadeMs">Fade-out duration in milliseconds.</param>
    void FadeOut(int fadeMs);

    /// <summary>
    /// Stops the music immediately.
    /// </summary>
    void Stop();

    /// <summary>
    /// Pauses the music.
    /// </summary>
    void Pause();

    /// <summary>
    /// Resumes paused music.
    /// </summary>
    void Resume();
}
