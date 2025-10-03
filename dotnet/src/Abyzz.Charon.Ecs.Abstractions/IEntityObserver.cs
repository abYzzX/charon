namespace Charon.Ecs;

public interface IEntityObserver
{
    public void OnEntityRemoved(IEntity entity);
    public void OnEntityUpdated(IEntity entity);
}
