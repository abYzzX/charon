// ReSharper disable CheckNamespace
namespace System.Collections;

public interface IBits : IReadOnlyBits
{
    bool GetAndClearBit(int index);
    bool GetAndSetBit(int index);
    void FlipBit(int index);
    void Clear();
    void And(IReadOnlyBits other);
    void AndNot(IReadOnlyBits other);
    void Or(IReadOnlyBits other);
    void XOr(IReadOnlyBits other);
}
