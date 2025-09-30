namespace Charon;

public class CharonInitializationException : Exception
{
    public CharonInitializationException() { }
    public CharonInitializationException(string message) : base(message) { }
    public CharonInitializationException(string message, Exception inner) : base(message, inner) { }
}
