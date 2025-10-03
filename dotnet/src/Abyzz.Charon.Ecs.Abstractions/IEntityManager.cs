namespace Charon.Ecs;

public interface IEntityManager
{
    void Add<T>(IEntity entity, T comp) where T : struct, IComponent;
    void Remove<T>(IEntity entity) where T : struct, IComponent;
    bool Has<T>(IEntity entity) where T : struct, IComponent;
    IEntity CreateEntity();
    void DestroyEntity(IEntity entity);
    ISparseSet<T> GetComponentStorage<T>() where T : struct, IComponent;
    ISparseSet GetComponentStorage(Type componentType);
    ref T GetComponent<T>(IEntity entity) where T : struct, IComponent;
    IDisposable RegisterObserver(IEntityObserver observer);
}

