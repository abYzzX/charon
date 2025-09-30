// ReSharper disable CheckNamespace
namespace System.Collections.Generic;

public class Bag<T>(int capacity = 32) : IBag<T>
{
    private T?[] _items = new T?[capacity];
    private readonly int _initCapacity = capacity;
    
    public int Size { get; private set; } = capacity;
    public int Count { get; private set; } = 0;

    public T? this[int index]
    {
        get => index > Count || index > Size ? default : _items[index];
        set => Set(index, value);
    }

    public void Add(T item)
    {
        EnsureCapacity(Count);
        _items[Count] = item;
        Count++;
    }

    public void Set(int index, T? item)
    {
        EnsureCapacity(index);
        _items[index] = item;
        Count = Math.Max(Count, index + 1);
    }

    public void Clear()
    {
        Array.Clear(_items, 0, Size);
        Array.Resize(ref _items, _initCapacity);;
        Count = 0;
    }

    public T? Remove(int index)
    {
        var item = _items[index];
        if (item != null)
        {
            _items[index] = default;
            Count--;
        }

        return item;
    }

    public bool Contains(T item)
    {
        return Array.IndexOf(_items, item, 0, Count) != -1;
    }
    
    private void EnsureCapacity(int neededIndex)
    {
        var newSize = Size;
        while (neededIndex > newSize)
        {
            newSize *= 2;
        }
        
        if (newSize > Size)
        {
            Array.Resize(ref _items, newSize);
            Size = newSize;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.Where(x => x != null).GetEnumerator()!;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
