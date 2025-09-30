// ReSharper disable CheckNamespace
namespace System.Collections.Generic;

public interface IDynamicArray<T> : IEnumerable<T>
{
    int Size { get; }
    T? this[int index] { get; set; }
    void Clear();
}
