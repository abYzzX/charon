using System.Collections;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Charon;

[DebuggerDisplay("{DebuggerToString(),nq}")]
[DebuggerTypeProxy(typeof(CharonServiceCollectionDebugView))]
public class CharonServiceCollection : IServiceCollection
{
    private readonly List<ServiceDescriptor> _descriptors = new();

    private readonly List<Action<IServiceCollection, ServiceDescriptor>> _serviceAddedCallbacks = new();
    private readonly List<Action<IServiceCollection, ServiceDescriptor>> _serviceRemovedCallbacks = new();

    /// <inheritdoc />
    public int Count => _descriptors.Count;

    /// <inheritdoc />
    public bool IsReadOnly { get; private set; }

    /// <inheritdoc />
    public ServiceDescriptor this[int index]
    {
        get
        {
            return _descriptors[index];
        }
        set
        {
            CheckReadOnly();
            _descriptors[index] = value;
        }
    }

    public void AddServiceAddedCallback(Action<IServiceCollection, ServiceDescriptor> callback)
    {
        _serviceAddedCallbacks.Add(callback);
    }

    private void InvokeServiceAddedCallbacks(ServiceDescriptor descriptor)
    {
        foreach (var callback in _serviceAddedCallbacks)
        {
            callback(this, descriptor);
        }
    }

    public void AddServiceRemovedCallback(Action<IServiceCollection, ServiceDescriptor> callback)
    {
        _serviceRemovedCallbacks.Add(callback);
    }

    private void InvokeServiceRemovedCallbacks(ServiceDescriptor descriptor)
    {
        foreach (var callback in _serviceRemovedCallbacks)
        {
            callback(this, descriptor);
        }
    }

    /// <inheritdoc />
    public void Clear()
    {
        CheckReadOnly();
        _descriptors.Clear();
    }

    /// <inheritdoc />
    public bool Contains(ServiceDescriptor item)
    {
        return _descriptors.Contains(item);
    }

    /// <inheritdoc />
    public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
    {
        _descriptors.CopyTo(array, arrayIndex);
    }

    /// <inheritdoc />
    public bool Remove(ServiceDescriptor item)
    {
        CheckReadOnly();
        InvokeServiceRemovedCallbacks(item);
        return _descriptors.Remove(item);
    }

    /// <inheritdoc />
    public IEnumerator<ServiceDescriptor> GetEnumerator()
    {
        return _descriptors.GetEnumerator();
    }

    void ICollection<ServiceDescriptor>.Add(ServiceDescriptor item)
    {
        CheckReadOnly();
        _descriptors.Add(item);
        InvokeServiceAddedCallbacks(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <inheritdoc />
    public int IndexOf(ServiceDescriptor item)
    {
        return _descriptors.IndexOf(item);
    }

    /// <inheritdoc />
    public void Insert(int index, ServiceDescriptor item)
    {
        CheckReadOnly();
        _descriptors.Insert(index, item);
        InvokeServiceAddedCallbacks(item);
    }

    /// <inheritdoc />
    public void RemoveAt(int index)
    {
        CheckReadOnly();
        var descriptor = _descriptors[index];
        _descriptors.RemoveAt(index);
        InvokeServiceRemovedCallbacks(descriptor);
    }

    /// <summary>
    /// Makes this collection read-only.
    /// </summary>
    /// <remarks>
    /// After the collection is marked as read-only, any further attempt to modify it throws an <see cref="InvalidOperationException" />.
    /// </remarks>
    public void MakeReadOnly()
    {
        IsReadOnly = true;
    }

    private void CheckReadOnly()
    {
        if (IsReadOnly)
        {
            ThrowReadOnlyException();
        }
    }

    private static void ThrowReadOnlyException() =>
        throw new InvalidOperationException("ServiceCollection is read-only.");

    private string DebuggerToString()
    {
        var debugText = $"Count = {_descriptors.Count}";
        if (IsReadOnly)
        {
            debugText += ", IsReadOnly = true";
        }

        return debugText;
    }

    private sealed class CharonServiceCollectionDebugView(CharonServiceCollection services)
    {
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public ServiceDescriptor[] Items
        {
            get
            {
                var items = new ServiceDescriptor[services.Count];
                services.CopyTo(items, 0);
                return items;
            }
        }
    }
}
