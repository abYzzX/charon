namespace Charon.Ecs;

public interface IComponentMapper<T> where T : struct
{
    ref T Get(IEntity entity);
    bool Has(IEntity entity);
    void Remove(IEntity entity);
}
