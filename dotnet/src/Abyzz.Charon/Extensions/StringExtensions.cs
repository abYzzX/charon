// ReSharper disable once CheckNamespace
namespace System;

public static class StringExtensions
{
    public static string EnsureEndsWith(this string str, string value)
    {
        return str.EndsWith(value) ? str : str + value;
    }

    public static string EnsureStartsWith(this string str, string value)
    {
        return str.StartsWith(value) ? str : value + str;       
    }
    
    public static string[] Chunk(this string str, int size)
    {
        return Enumerable.Range(0, str.Length / size)
            .Select(i => str.Substring(i * size, size))
            .ToArray();
    }
}
