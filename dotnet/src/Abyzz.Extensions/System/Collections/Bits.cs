// ReSharper disable CheckNamespace

using System.Text;

namespace System.Collections;

public class Bits : IBits
{
    private const int BitsPerLong = 64;

    private long[] _bits = new long[1];

    public int BitCount => _bits.Length << 6;

    public bool IsEmpty => _bits.All(x => x == 0);

    public int Length
    {
        get
        {
            for (var word = _bits.Length - 1; word >= 0; --word)
            {
                var bitsAtWord = _bits[word];
                if (bitsAtWord == 0) continue;

                for (var bit = 63; bit >= 0; --bit)
                {
                    if ((bitsAtWord & (1L << bit)) != 0)
                        return (word << 6) + bit + 1;
                }
            }

            return 0;
        }
    }

    public bool this[int index]
    {
        get => GetBit(index);
        set
        {
            if (value) SetBit(index);
            else ClearBit(index);
        }
    }

    public Bits(int size = 64)
    {
        EnsureCapacity(size >> 6);
    }

    public long GetWord(int index)
    {
        if (index < 0 || index >= _bits.Length)
        {
            throw new IndexOutOfRangeException(nameof(index));
        }

        return _bits[index];
    }

    private void EnsureCapacity(int size)
    {
        if (size > _bits.Length)
        {
            Array.Resize(ref _bits, size + 1);
        }
    }

    public bool GetAndClearBit(int index)
    {
        var word = index >> 6;
        if (word >= _bits.Length) return false;
        var bit = _bits[word] & (1L << (index & 0x3F));
        _bits[word] &= ~(1L << (index & 0x3F));
        return bit != 0;
    }

    public bool GetAndSetBit(int index)
    {
        var word = index >> 6;
        if (word >= _bits.Length) return false;
        var bit = _bits[word] & (1L << (index & 0x3F));
        _bits[word] |= 1L << (index & 0x3F);
        return bit != 0;
    }

    public void FlipBit(int index)
    {
        var word = index >> 6;
        if (word >= _bits.Length) return;
        _bits[word] ^= 1L << (index & 0x3F);
    }

    public void Clear()
    {
        Array.Clear(_bits, 0, _bits.Length);
    }

    public void And(IReadOnlyBits other)
    {
        var commonWords = Math.Min(_bits.Length, other.BitCount >> 6);
        for (var i = 0; commonWords > i; i++)
        {
            _bits[i] &= other.GetWord(i);
        }

        if (_bits.Length <= commonWords)
        {
            return;
        }

        for (var i = commonWords; _bits.Length > i; i++)
        {
            _bits[i] = 0L;
        }
    }

    public void AndNot(IReadOnlyBits other)
    {
        for (var i = 0; i < _bits.Length && i < other.BitCount << 6; i++)
        {
            _bits[i] &= ~other.GetWord(i);
        }
    }

    public void Or(IReadOnlyBits other)
    {
        var otherWordCount = other.BitCount >> 6;
        var commonWords = Math.Min(_bits.Length, otherWordCount);
        for (var i = 0; commonWords > i; i++)
        {
            _bits[i] |= other.GetWord(i);
        }

        if (commonWords >= otherWordCount)
        {
            return;
        }

        EnsureCapacity(otherWordCount);
        for (var i = commonWords; otherWordCount > i; i++)
        {
            _bits[i] = other.GetWord(i);
        }
    }

    public void XOr(IReadOnlyBits other)
    {
        var otherWordCount = other.BitCount >> 6;
        var commonWords = Math.Min(_bits.Length, otherWordCount);
        for (var i = 0; commonWords > i; i++)
        {
            _bits[i] ^= other.GetWord(i);
        }

        if (commonWords >= otherWordCount)
        {
            return;
        }

        EnsureCapacity(otherWordCount);
        for (var i = commonWords; otherWordCount > i; i++)
        {
            _bits[i] = other.GetWord(i);
        }
    }

    public bool Intersects(IReadOnlyBits other)
    {
        var otherBitsLength = other.BitCount >> 6;
        for (var i = Math.Min(_bits.Length, otherBitsLength) - 1; i >= 0; i--)
        {
            if ((_bits[i] & other.GetWord(i)) != 0)
            {
                return true;
            }
        }

        return false;
    }

    public string ToBitString()
    {
        var sb = new StringBuilder();
        for (var i = _bits.Length - 1; i >= 0; i--)
        {
            sb.Append(Convert.ToString(_bits[i], 2).PadLeft(64, '0'));
        }
        
        return sb.ToString();   
    }

    public string ToHexString()
    {
        var sb = new StringBuilder();
        for (var i = _bits.Length - 1; i >= 0; i--)
        {
            sb.Append(Convert.ToString(_bits[i], 16).PadLeft(16, '0'));
        }
        
        return sb.ToString();   
    }

    public bool ContainsAll(IReadOnlyBits other)
    {
        var otherBitsLength = other.BitCount >> 6;

        for (var i = _bits.Length; i < otherBitsLength; i++)
        {
            if (other.GetWord(i) != 0)
            {
                return false;
            }
        }

        for (var i = Math.Min(_bits.Length, otherBitsLength) - 1; i >= 0; i--)
        {
            var otherWord = other.GetWord(i);
            if ((_bits[i] & otherWord) != otherWord)
            {
                return false;
            }
        }

        return true;
    }

    private bool GetBit(int index)
    {
        var word = index >> 6;
        if (word >= _bits.Length) return false;
        return (_bits[word] & (1L << (index & 0x3F))) != 0;
    }

    private void SetBit(int index)
    {
        var word = index >> 6;
        if (word >= _bits.Length) return;
        _bits[word] |= 1L << (index & 0x3F);
    }

    private void ClearBit(int index)
    {
        var word = index >> 6;
        if (word >= _bits.Length) return;
        _bits[word] &= ~(1L << (index & 0x3F));
    }
}
