namespace Charon;

public interface IFpsCounter
{
    float Fps { get; }
    float MinFps { get; }
    float MaxFps { get; }
    float FrameTime { get; }
}
