namespace Charon;

public class CharonSceneException : Exception
{
    public CharonSceneException() { }
    public CharonSceneException(string message) : base(message) { }
    public CharonSceneException(string message, Exception inner) : base(message, inner) { }
}
