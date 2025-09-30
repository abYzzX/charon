// ReSharper disable CheckNamespace

using System.Reflection;

namespace System.Collections.Generic;

/// <summary>
///     A shortcut for <see cref="TypeList{TBaseType}" /> to use object as base type.
/// </summary>
public class TypeList : TypeList<object>, ITypeList
{
    public static implicit operator TypeList(Type[] types)
    {
        var typeList = new TypeList();
        typeList.AddRange(types);
        return typeList;
    }
}

/// <summary>
///     Extends <see cref="List{Type}" /> to add restriction a specific base type.
/// </summary>
/// <typeparam name="TBaseType">Base Type of <see cref="Type" />s in this list</typeparam>
public class TypeList<TBaseType> : ITypeList<TBaseType>
{
    /// <summary>
    ///     Creates a new <see cref="TypeList{T}" /> object.
    /// </summary>
    public TypeList()
    {
        Types = new List<Type>();
    }

    public TypeList(params Type[] types)
    {
        if (types.Any(x => !typeof(TBaseType).GetTypeInfo().IsAssignableFrom(x)))
        {
            throw new ArgumentException("Given types should be instance of " + typeof(TBaseType).AssemblyQualifiedName);
        }

        Types = new List<Type>(types);
    }

    protected IList<Type> Types { get; set; }

    /// <summary>
    ///     Gets the count.
    /// </summary>
    /// <value>The count.</value>
    public int Count
    {
        get => Types.Count;
    }

    /// <summary>
    ///     Gets a value indicating whether this instance is read only.
    /// </summary>
    /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
    public bool IsReadOnly
    {
        get => false;
    }

    /// <summary>
    ///     Gets or sets the <see cref="Type" /> at the specified index.
    /// </summary>
    /// <param name="index">Index.</param>
    public Type this[int index]
    {
        get => Types[index];
        set
        {
            CheckType(value);
            Types[index] = value;
        }
    }

    /// <inheritdoc />
    public virtual void Add<T>() where T : TBaseType
    {
        Types.Add(typeof(T));
    }

    /// <inheritdoc />
    public virtual void Add(Type item)
    {
        CheckType(item);
        Types.Add(item);
    }

    public virtual bool TryAdd<T>() where T : TBaseType
    {
        if (Contains<T>())
        {
            return false;
        }

        Add<T>();
        return true;
    }

    /// <inheritdoc />
    public virtual void Insert(int index, Type item)
    {
        CheckType(item);
        Types.Insert(index, item);
    }

    /// <inheritdoc />
    public virtual int IndexOf(Type item)
    {
        return Types.IndexOf(item);
    }

    /// <inheritdoc />
    public virtual bool Contains<T>() where T : TBaseType
    {
        return Contains(typeof(T));
    }

    /// <inheritdoc />
    public virtual bool Contains(Type item)
    {
        return Types.Contains(item);
    }

    /// <inheritdoc />
    public virtual void Remove<T>() where T : TBaseType
    {
        Types.Remove(typeof(T));
    }

    /// <inheritdoc />
    public virtual bool Remove(Type item)
    {
        return Types.Remove(item);
    }

    /// <inheritdoc />
    public virtual void RemoveAt(int index)
    {
        Types.RemoveAt(index);
    }

    /// <inheritdoc />
    public virtual void Clear()
    {
        Types.Clear();
    }

    /// <inheritdoc />
    public virtual void CopyTo(Type[] array, int arrayIndex)
    {
        Types.CopyTo(array, arrayIndex);
    }

    /// <inheritdoc />
    public IEnumerator<Type> GetEnumerator()
    {
        return Types.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Types.GetEnumerator();
    }

    private static void CheckType(Type item)
    {
        if (!typeof(TBaseType).GetTypeInfo().IsAssignableFrom(item))
        {
            throw new ArgumentException(
                $"Given type ({item.AssemblyQualifiedName}) should be instance of {typeof(TBaseType).AssemblyQualifiedName} ",
                nameof(item));
        }
    }
    
}
