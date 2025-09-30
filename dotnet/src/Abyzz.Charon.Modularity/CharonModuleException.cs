namespace Charon;

public class CharonModuleException : Exception
{
    public CharonModuleException() { }
    public CharonModuleException(string message) : base(message) { }
    public CharonModuleException(string message, Exception inner) : base(message, inner) { }
}
