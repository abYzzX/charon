namespace Charon.Input;

public interface IKeyboardInputService
{
    bool IsKeyDown(Keys key);
    bool IsKeyUp(Keys key);
    
    event EventHandler<KeyboardEventArgs> KeyDown;
    event EventHandler<KeyboardEventArgs> KeyUp;
}
