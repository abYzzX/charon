using System.Collections;

namespace Charon.Ecs;

internal class EntityQuery : IEntityQuery, IEnumerable<IEntity>, IEntityObserver, IDisposable 
{
    private readonly HashSet<int> _entityIds = new();
    private readonly List<Type> _all;
    private readonly List<Type> _one;
    private readonly List<Type> _exclude;
    private readonly IDisposable _observerRegistration;
    private readonly IEntityManager _entityManager;
        
    public int Count { get => _entityIds.Count; }
    
    public EntityQuery(IEntityManager entityManager, List<Type> all, List<Type> one, List<Type> exclude)
    {
        _all = all;
        _one = one;
        _exclude = exclude;
        _entityManager = entityManager;
        InitialScan();
        _observerRegistration = entityManager.RegisterObserver(this);
    }

    public void OnEntityRemoved(IEntity entity)
    {
        _entityIds.Remove(entity.Id);       
    }

    public void OnEntityUpdated(IEntity entity)
    {
        if (IsMatch(entity))
        {
            _entityIds.Add(entity.Id);
        }
        else
        {
            _entityIds.Remove(entity.Id);
        }
    }

    private bool IsMatch(IEntity entity)
    {
        if (!_all.All(x => _entityManager.GetComponentStorage(x).Has(entity.Id)))
        {
            return false;
        }

        if (_exclude.Count > 0 && _exclude.Any(x => _entityManager.GetComponentStorage(x).Has(entity.Id)))
        {
            return false;
        }

        return _one.Count == 0 || _one.Any(x => _entityManager.GetComponentStorage(x).Has(entity.Id));
    }
    
    public void Dispose()
    {
        _observerRegistration.Dispose();       
    }

    public IEnumerator<IEntity> GetEnumerator()
    {
        var snapshot = _entityIds.ToArray();
        foreach (var id in snapshot)
        {
            yield return new Entity(id);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void InitialScan()
    {
        // Option 1: Über alle Component-Storages iterieren
        var candidateStorage = _all.Count > 0 
            ? _entityManager.GetComponentStorage(_all[0]) 
            : null;
    
        if (candidateStorage != null)
        {
            foreach (var entityId in candidateStorage.Entities)
            {
                var entity = new Entity(entityId);
                if (IsMatch(entity))
                {
                    _entityIds.Add(entityId);
                }
            }
        }
    }    
}
