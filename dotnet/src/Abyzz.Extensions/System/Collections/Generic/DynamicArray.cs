// ReSharper disable CheckNamespace
namespace System.Collections.Generic;

public class DynamicArray<T>(int size = 16) : IDynamicArray<T>
{
    private T?[] _items = new T?[size];

    public int Size => _items.Length;
    
    public T? this[int index]
    {
        get => index >= _items.Length ? default : _items[index];
        set => SetItem(index, value);
    }

    public void Clear()
    {
        _items = new T?[size];
    }

    private void SetItem(int index, T? item)
    {
        EnsureSize(index);
        _items[index] = item;
    }
    
    private void EnsureSize(int size)
    {
        if (size < _items.Length) return;
        
        var newSize = _items.Length;
        while (newSize <= size)
        {
            newSize *= 2;
        }
        
        Array.Resize(ref _items, newSize);
    }
    
    public class DynamicArrayEnumerator<TItem>(DynamicArray<TItem> array) : IEnumerator<TItem>
    {
        private int _index = -1;
        private TItem _current;

        public void Dispose()
        { }

        public bool MoveNext()
        {
            while (_index < array.Size - 1 && array[_index + 1] == null)
            {
                _index++;
                _current = array[_index];
                if (_current != null)
                {
                    return true;
                }
            }
            
            return false;
        }

        public void Reset()
        {
            _index = -1;
        }

        TItem IEnumerator<TItem>.Current
        {
            get => _current;
        }

        object? IEnumerator.Current
        {
            get => _current;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new DynamicArrayEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
