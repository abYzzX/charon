namespace Charon.Input;

public class KeyboardEventArgs(Keys key) : EventArgs
{
    public Keys Key { get; } = key;
}
