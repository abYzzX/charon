namespace Charon;

public interface ISceneUpdatableService : ISceneService
{
    void Update(IGameTime gameTime);
}
