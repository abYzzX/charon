// ReSharper disable once CheckNamespace

namespace System;

public class DisposableAction : IDisposable
{
    private readonly Action _action;

    public DisposableAction(Action action)
    {
        ArgumentNullException.ThrowIfNull(action);
        _action = action;
    }

    public void Dispose()
    {
        _action();
    }
}
