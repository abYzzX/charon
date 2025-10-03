namespace Charon.Ecs;

public class ComponentMapper<T> : IComponentMapper<T> where T : struct, IComponent
{
    public required IEntityManager Manager { private get; init; }

    public ref T Get(IEntity entity) => ref Manager.GetComponent<T>(entity);
    public bool Has(IEntity entity) => Manager.Has<T>(entity);
    public void Remove(IEntity entity) => Manager.Remove<T>(entity);
}
