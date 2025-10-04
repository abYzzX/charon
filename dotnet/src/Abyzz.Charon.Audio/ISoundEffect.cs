namespace Charon.Audio;

public interface ISoundEffect
{
    Vector2 Position { get; set; }
    float Volume { get; set; }
    void Play(int loops = 0);
    void Stop();
    void Pause();
    void Resume();
}
