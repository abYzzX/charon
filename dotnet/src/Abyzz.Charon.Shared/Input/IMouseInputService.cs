using Charon.Math;

namespace Charon.Input;

public interface IMouseInputService
{
    Vector2 MousePosition { get; }
    bool IsMouseButtonDown(MouseButtons buttons);
    bool IsMouseButtonUp(MouseButtons buttons);
    event EventHandler<MouseEventArgs> MouseDown;
    event EventHandler<MouseEventArgs> MouseUp;
    event EventHandler<MouseEventArgs> MouseMove;
    event EventHandler<MouseEventArgs> MouseWheel;
}
