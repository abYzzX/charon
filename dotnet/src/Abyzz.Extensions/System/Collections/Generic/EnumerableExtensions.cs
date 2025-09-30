// ReSharper disable CheckNamespace

namespace System.Collections.Generic;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Flatten<T>(
        this IEnumerable<T> source,
        Func<T, IEnumerable<T>> childrenSelector)
    {
        foreach (var item in source)
        {
            yield return item;
            var children = childrenSelector(item);
            foreach (var child in children.Flatten(childrenSelector))
            {
                yield return child;
            }
        }
    }
}
