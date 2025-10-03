// ReSharper disable once CheckNamespace
namespace System.Collections.Generic;

public interface ISparseSet
{
    IEnumerable<int> Entities { get; }
    bool Has(int entity);
    void Remove(int entity);
}

public interface ISparseSet<T> : ISparseSet where T : struct
{
    int Count { get; }
    void Add(int entity, in T component);
    ref T Get(int entity);
    IEnumerable<T> Components { get; }
}
