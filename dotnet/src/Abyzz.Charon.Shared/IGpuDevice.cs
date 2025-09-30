namespace Charon;

public interface IGpuDevice : IDisposable
{
    IntPtr Handle { get; }
}
