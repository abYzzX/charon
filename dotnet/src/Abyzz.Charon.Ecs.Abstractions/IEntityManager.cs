namespace Charon.Ecs;

public interface IEntityManager
{
    void Add<T>(IEntity entity, T comp) where T : struct;
    void Remove<T>(IEntity entity) where T : struct;
    bool Has<T>(IEntity entity) where T : struct;
    IEntity CreateEntity();
    void DestroyEntity(int entity); 
    SparseSet<T> GetComponentStorage<T>() where T : struct;
    ref T GetComponent<T>(IEntity entity) where T : struct;
}
