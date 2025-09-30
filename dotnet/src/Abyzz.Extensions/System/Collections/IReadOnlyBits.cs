// ReSharper disable CheckNamespace
namespace System.Collections;

public interface IReadOnlyBits
{
    int BitCount { get; }
    bool IsEmpty { get; }
    int Length { get; }
    bool this[int index] { get; set; }
    long GetWord(int index);
    bool ContainsAll(IReadOnlyBits other);
    bool Intersects(IReadOnlyBits other);
    string ToBitString();
    string ToHexString();
}
