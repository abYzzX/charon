// ReSharper disable CheckNamespace
namespace System.Collections.Generic;

public interface IBag<T> : IReadOnlyList<T>
{
    int Size { get; }
    int Count { get; }
    T? this[int index] { get; set; }
    void Add(T item);
    void Set(int index, T? item);
    void Clear();
    T? Remove(int index);
    bool Contains(T item);
}
