namespace Charon;

public interface ISceneRenderableService : ISceneService
{
    int ZLevel { get; }   
    void Render();
}
