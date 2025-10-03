using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.Options;

namespace Charon.Ecs;

[ExposeServices(typeof(IEntityManager))]
internal class EntityManager : IEntityManager, IScopedDependency
{
    private int _nextId = 0;
    private readonly Stack<int> _freeIds = new();
    private readonly int _maxEntities;
    private readonly Dictionary<Type, ISparseSet> _storages = new();
    private readonly List<IEntityObserver> _observers = new();

    public EntityManager(IOptions<EntityManagerOptions> options)
    {
        _maxEntities = options.Value.MaxEntities;
    }

    public void Add<T>(IEntity entity, T comp) where T : struct, IComponent
    {
        GetComponentStorage<T>().Add(entity.Id, comp);
        foreach (var observer in _observers)
            observer.OnEntityUpdated(entity);
    }

    public void Remove<T>(IEntity entity) where T : struct, IComponent
    {
        GetComponentStorage<T>().Remove(entity.Id);
        foreach (var observer in _observers)
            observer.OnEntityUpdated(entity);
    }

    public bool Has<T>(IEntity entity) where T : struct, IComponent
    {
        return GetComponentStorage<T>().Has(entity.Id);
    }

    public IEntity CreateEntity()
    {
        IEntity entity;
        if (_freeIds.Count > 0)
            entity = new Entity(_freeIds.Pop());
        else if (_nextId >= _maxEntities)
            throw new Exception("Max entities reached!");
        else 
            entity = new Entity(_nextId++);
        
        return entity;        
    }

    public void DestroyEntity(IEntity entity)
    {
        foreach (var observer in _observers)
            observer.OnEntityRemoved(entity);

        foreach (var store in _storages.Values)
        {
            store.Remove(entity.Id);       
        }
        
        _freeIds.Push(entity.Id);
    }

    public ISparseSet<T> GetComponentStorage<T>() where T : struct, IComponent
    {
        return (ISparseSet<T>)GetComponentStorage(typeof(T));       
    }

    public ISparseSet GetComponentStorage(Type componentType)
    {
        if (!componentType.IsAssignableTo<IComponent>())
        {
            throw new ArgumentException("Type must implement IComponent interface");       
        }
        
        if (!_storages.TryGetValue(componentType, out var store))
        {
            var storeType = typeof(SparseSet<>).MakeGenericType(componentType);
            var ctor = storeType.GetConstructor([typeof(int)]);
            store = (ISparseSet)ctor.Invoke([_maxEntities]);
            _storages[componentType] = store;
        }

        return store;
    }

    public ref T GetComponent<T>(IEntity entity) where T : struct, IComponent
    {
        var storage = GetComponentStorage<T>();
        return ref storage.Get(entity.Id);
    }

    public IDisposable RegisterObserver(IEntityObserver observer)
    {
        _observers.Add(observer);
        return new DisposableAction(() => _observers.Remove(observer));   
    }
}
