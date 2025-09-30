namespace Charon;

public interface IGameTime
{
    float TotalElapsedTime { get; }
    float DeltaTime { get; }
    void Update();
}
