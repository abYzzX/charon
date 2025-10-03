// ReSharper disable once CheckNamespace
namespace System.Collections.Generic;

public class SparseSet<T> : ISparseSet<T> where T : struct
{
    private T[] _dense;
    private int[] _denseEntities;
    private int[] _sparse;

    private int _count;

    public int Count => _count;

    public IEnumerable<int> Entities
    {
        get
        {
            for (var i = 0; i < _count; i++)
                yield return _denseEntities[i];
        }
    }

    public IEnumerable<T> Components
    {
        get
        {
            for (var i = 0; i < _count; i++)
                yield return _dense[i];
        }
    }    

    public SparseSet(int capacity = 1024)
    {
        _dense = new T[capacity];
        _denseEntities = new int[capacity];
        _sparse = new int[capacity];
        Array.Fill(_sparse, -1);
        _count = 0;
    }

    private void EnsureCapacity(int entity)
    {
        if (entity < _sparse.Length) return;

        var newSize = Math.Max(_sparse.Length * 2, entity + 1);

        Array.Resize(ref _sparse, newSize);
        for (var i = _count; i < newSize; i++)
            _sparse[i] = -1;
    }

    public void Add(int entity, in T component)
    {
        EnsureCapacity(entity);
        if (_sparse[entity] != -1)
            return; // already exists

        _sparse[entity] = _count;
        _denseEntities[_count] = entity;
        _dense[_count] = component;
        _count++;

        if (_count >= _dense.Length)
        {
            Array.Resize(ref _dense, _dense.Length * 2);
            Array.Resize(ref _denseEntities, _denseEntities.Length * 2);
        }
    }

    public ref T Get(int entity)
    {
        return ref _dense[_sparse[entity]];
    }

    public bool Has(int entity) => entity < _sparse.Length && _sparse[entity] != -1;

    public void Remove(int entity)
    {
        if (!Has(entity)) return;

        var idx = _sparse[entity];
        var lastIdx = _count - 1;
        var lastEntity = _denseEntities[lastIdx];

        // Swap-Remove
        _dense[idx] = _dense[lastIdx];
        _denseEntities[idx] = lastEntity;
        _sparse[lastEntity] = idx;

        _sparse[entity] = -1;
        _count--;
    }
}
