namespace Charon.Exceptions;

public class CharonContentException : Exception
{
    public CharonContentException() { }
    public CharonContentException(string message) : base(message) { }
    public CharonContentException(string message, Exception inner) : base(message, inner) { }
}
