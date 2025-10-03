using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.Options;

namespace Charon.Ecs;

[ExposeServices(typeof(IEntityManager))]
internal class EntityManager : IEntityManager, IScopedDependency
{
    private readonly Stack<int> _freeIds = new();
    private int _nextId = 0;
    private readonly int _maxEntities;
    private readonly Dictionary<Type, ISparseSet> _storages = new();

    public EntityManager(IOptions<EntityManagerOptions> options)
    {
        _maxEntities = options.Value.MaxEntities;
    }


    public void Add<T>(IEntity entity, T comp) where T : struct
        => GetComponentStorage<T>().Add(entity.Id, comp);

    public void Remove<T>(IEntity entity) where T : struct
        => GetComponentStorage<T>().Remove(entity.Id);

    public bool Has<T>(IEntity entity) where T : struct
        => GetComponentStorage<T>().Has(entity.Id);

    public IEntity CreateEntity()
    {
        if (_freeIds.Count > 0)
            return new Entity(_freeIds.Pop());

        if (_nextId >= _maxEntities)
            throw new Exception("Max entities reached!");

        return new Entity(_nextId++);
    }

    public void DestroyEntity(int entity)
    {
        _freeIds.Push(entity);
    }

    public SparseSet<T> GetComponentStorage<T>() where T : struct
    {
        if (!_storages.TryGetValue(typeof(T), out var store))
        {
            store = new SparseSet<T>(_maxEntities);
            _storages[typeof(T)] = store;
        }

        return (SparseSet<T>)store;
    }
    
    public ref T GetComponent<T>(IEntity entity) where T : struct
    {
        var storage = GetComponentStorage<T>();
        return ref storage.Get(entity.Id);
    }    
}
