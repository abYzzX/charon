using Charon.Math;

namespace Charon.Input;

public class MouseEventArgs(MouseButtons button, Vector2 position, Vector2 wheelDelta) : EventArgs
{
    public MouseButtons Button { get; } = button;
    public Vector2 Position { get; } = position;
    public Vector2 WheelDelta { get; } = wheelDelta;
}
