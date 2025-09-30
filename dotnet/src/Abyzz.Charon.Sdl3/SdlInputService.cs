using Charon.Input;
using Charon.Math;
using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.Logging;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(
    typeof(IKeyboardInputService),
    typeof(IMouseInputService),
    typeof(IGlobalService)
)]
public class SdlInputService :
    IKeyboardInputService,
    IMouseInputService,
    IGlobalService,
    IDisposable,
    ISingletonDependency
{
    private readonly bool[] _keyStates = new bool[(int)SDL_Scancode.SDL_SCANCODE_COUNT];
    private MouseButtons _mouseButtonState = 0;

    private IDisposable[] _eventHandlerRegistrations = [];

    public required ILogger<SdlInputService> Logger { private get; init; }
    public required ISdlEventManager SdlEventManager { private get; init; }

    public Vector2 MousePosition { get; private set; } = Vector2.Zero;
    public int Order { get; } = -90;

    public void Initialize()
    {
        _eventHandlerRegistrations =
        [
            SdlEventManager.RegisterEventHandler(HandleKeyboardEvent,
                SDL_EventType.SDL_EVENT_KEY_DOWN,
                SDL_EventType.SDL_EVENT_KEY_UP),
            SdlEventManager.RegisterEventHandler(HandleMouseEvent,
                SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN,
                SDL_EventType.SDL_EVENT_MOUSE_BUTTON_UP,
                SDL_EventType.SDL_EVENT_MOUSE_MOTION,
                SDL_EventType.SDL_EVENT_MOUSE_WHEEL)
        ];

        Array.Fill(_keyStates, false);
    }

    public void Update(IGameTime gameTime) { }

    public void Render() { }

    public bool IsKeyDown(Keys key) => _keyStates[(int)key];
    public bool IsKeyUp(Keys key) => !_keyStates[(int)key];
    public event EventHandler<KeyboardEventArgs>? KeyDown;
    public event EventHandler<KeyboardEventArgs>? KeyUp;

    public bool IsMouseButtonDown(MouseButtons buttons)
    {
        return _mouseButtonState.HasFlag(buttons);
    }

    public bool IsMouseButtonUp(MouseButtons buttons)
    {
        return !_mouseButtonState.HasFlag(buttons);
    }

    public event EventHandler<MouseEventArgs>? MouseDown;
    public event EventHandler<MouseEventArgs>? MouseUp;
    public event EventHandler<MouseEventArgs>? MouseMove;
    public event EventHandler<MouseEventArgs>? MouseWheel;

    private void HandleKeyboardEvent(SDL_Event ev)
    {
        switch (ev.Type)
        {
            case SDL_EventType.SDL_EVENT_KEY_DOWN:
                Logger.LogTrace("Key down: {Key}", ev.key.scancode);
                _keyStates[(int)ev.key.scancode] = true;
                KeyDown?.Invoke(this, new KeyboardEventArgs((Keys)(int)ev.key.scancode));
                break;
            case SDL_EventType.SDL_EVENT_KEY_UP:
                Logger.LogTrace("Key up: {Key}", ev.key.scancode);
                _keyStates[(int)ev.key.scancode] = false;
                KeyUp?.Invoke(this, new KeyboardEventArgs((Keys)(int)ev.key.scancode));
                break;
        }
    }

    private void HandleMouseEvent(SDL_Event ev)
    {
        switch (ev.Type)
        {
            case SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN:
                Logger.LogTrace("Mouse Button: {Button}", _mouseButtonState);
                _mouseButtonState |= ev.button.Button.ToMouseButton();
                MouseDown?.Invoke(this, new MouseEventArgs(_mouseButtonState, MousePosition, Vector2.Zero));
                break;
            case SDL_EventType.SDL_EVENT_MOUSE_BUTTON_UP:
                Logger.LogTrace("Mouse Button: {Button}", _mouseButtonState);
                _mouseButtonState &= ~ev.button.Button.ToMouseButton();
                MouseUp?.Invoke(this, new MouseEventArgs(_mouseButtonState, MousePosition, Vector2.Zero));
                break;
            case SDL_EventType.SDL_EVENT_MOUSE_MOTION:
                Logger.LogTrace("Mouse Position: {X}, {Y}", ev.motion.x, ev.motion.y);
                MousePosition = new Vector2(ev.motion.x, ev.motion.y);
                MouseMove?.Invoke(this, new MouseEventArgs(_mouseButtonState, MousePosition, Vector2.Zero));
                break;
            case SDL_EventType.SDL_EVENT_MOUSE_WHEEL:
                Logger.LogTrace("Mouse Wheel: {WheelX}, {WheelY}", ev.wheel.x, ev.wheel.y);
                MouseWheel?.Invoke(this,
                    new MouseEventArgs(_mouseButtonState, MousePosition, new Vector2(ev.wheel.x, ev.wheel.y)));
                break;
        }
    }

    public void Dispose()
    {
        foreach (var reg in _eventHandlerRegistrations)
        {
            reg.Dispose();
        }
    }
}
