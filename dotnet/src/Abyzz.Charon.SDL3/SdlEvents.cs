using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlEvents
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_EventType
	{
		SDL_EVENT_FIRST = 0,
		SDL_EVENT_QUIT = 256,
		SDL_EVENT_TERMINATING = 257,
		SDL_EVENT_LOW_MEMORY = 258,
		SDL_EVENT_WILL_ENTER_BACKGROUND = 259,
		SDL_EVENT_DID_ENTER_BACKGROUND = 260,
		SDL_EVENT_WILL_ENTER_FOREGROUND = 261,
		SDL_EVENT_DID_ENTER_FOREGROUND = 262,
		SDL_EVENT_LOCALE_CHANGED = 263,
		SDL_EVENT_SYSTEM_THEME_CHANGED = 264,
		SDL_EVENT_DISPLAY_ORIENTATION = 337,
		SDL_EVENT_DISPLAY_ADDED = 338,
		SDL_EVENT_DISPLAY_REMOVED = 339,
		SDL_EVENT_DISPLAY_MOVED = 340,
		SDL_EVENT_DISPLAY_DESKTOP_MODE_CHANGED = 341,
		SDL_EVENT_DISPLAY_CURRENT_MODE_CHANGED = 342,
		SDL_EVENT_DISPLAY_CONTENT_SCALE_CHANGED = 343,
		SDL_EVENT_DISPLAY_FIRST = 337,
		SDL_EVENT_DISPLAY_LAST = 343,
		SDL_EVENT_WINDOW_SHOWN = 514,
		SDL_EVENT_WINDOW_HIDDEN = 515,
		SDL_EVENT_WINDOW_EXPOSED = 516,
		SDL_EVENT_WINDOW_MOVED = 517,
		SDL_EVENT_WINDOW_RESIZED = 518,
		SDL_EVENT_WINDOW_PIXEL_SIZE_CHANGED = 519,
		SDL_EVENT_WINDOW_METAL_VIEW_RESIZED = 520,
		SDL_EVENT_WINDOW_MINIMIZED = 521,
		SDL_EVENT_WINDOW_MAXIMIZED = 522,
		SDL_EVENT_WINDOW_RESTORED = 523,
		SDL_EVENT_WINDOW_MOUSE_ENTER = 524,
		SDL_EVENT_WINDOW_MOUSE_LEAVE = 525,
		SDL_EVENT_WINDOW_FOCUS_GAINED = 526,
		SDL_EVENT_WINDOW_FOCUS_LOST = 527,
		SDL_EVENT_WINDOW_CLOSE_REQUESTED = 528,
		SDL_EVENT_WINDOW_HIT_TEST = 529,
		SDL_EVENT_WINDOW_ICCPROF_CHANGED = 530,
		SDL_EVENT_WINDOW_DISPLAY_CHANGED = 531,
		SDL_EVENT_WINDOW_DISPLAY_SCALE_CHANGED = 532,
		SDL_EVENT_WINDOW_SAFE_AREA_CHANGED = 533,
		SDL_EVENT_WINDOW_OCCLUDED = 534,
		SDL_EVENT_WINDOW_ENTER_FULLSCREEN = 535,
		SDL_EVENT_WINDOW_LEAVE_FULLSCREEN = 536,
		SDL_EVENT_WINDOW_DESTROYED = 537,
		SDL_EVENT_WINDOW_HDR_STATE_CHANGED = 538,
		SDL_EVENT_WINDOW_FIRST = 514,
		SDL_EVENT_WINDOW_LAST = 538,
		SDL_EVENT_KEY_DOWN = 768,
		SDL_EVENT_KEY_UP = 769,
		SDL_EVENT_TEXT_EDITING = 770,
		SDL_EVENT_TEXT_INPUT = 771,
		SDL_EVENT_KEYMAP_CHANGED = 772,
		SDL_EVENT_KEYBOARD_ADDED = 773,
		SDL_EVENT_KEYBOARD_REMOVED = 774,
		SDL_EVENT_TEXT_EDITING_CANDIDATES = 775,
		SDL_EVENT_MOUSE_MOTION = 1024,
		SDL_EVENT_MOUSE_BUTTON_DOWN = 1025,
		SDL_EVENT_MOUSE_BUTTON_UP = 1026,
		SDL_EVENT_MOUSE_WHEEL = 1027,
		SDL_EVENT_MOUSE_ADDED = 1028,
		SDL_EVENT_MOUSE_REMOVED = 1029,
		SDL_EVENT_JOYSTICK_AXIS_MOTION = 1536,
		SDL_EVENT_JOYSTICK_BALL_MOTION = 1537,
		SDL_EVENT_JOYSTICK_HAT_MOTION = 1538,
		SDL_EVENT_JOYSTICK_BUTTON_DOWN = 1539,
		SDL_EVENT_JOYSTICK_BUTTON_UP = 1540,
		SDL_EVENT_JOYSTICK_ADDED = 1541,
		SDL_EVENT_JOYSTICK_REMOVED = 1542,
		SDL_EVENT_JOYSTICK_BATTERY_UPDATED = 1543,
		SDL_EVENT_JOYSTICK_UPDATE_COMPLETE = 1544,
		SDL_EVENT_GAMEPAD_AXIS_MOTION = 1616,
		SDL_EVENT_GAMEPAD_BUTTON_DOWN = 1617,
		SDL_EVENT_GAMEPAD_BUTTON_UP = 1618,
		SDL_EVENT_GAMEPAD_ADDED = 1619,
		SDL_EVENT_GAMEPAD_REMOVED = 1620,
		SDL_EVENT_GAMEPAD_REMAPPED = 1621,
		SDL_EVENT_GAMEPAD_TOUCHPAD_DOWN = 1622,
		SDL_EVENT_GAMEPAD_TOUCHPAD_MOTION = 1623,
		SDL_EVENT_GAMEPAD_TOUCHPAD_UP = 1624,
		SDL_EVENT_GAMEPAD_SENSOR_UPDATE = 1625,
		SDL_EVENT_GAMEPAD_UPDATE_COMPLETE = 1626,
		SDL_EVENT_GAMEPAD_STEAM_HANDLE_UPDATED = 1627,
		SDL_EVENT_FINGER_DOWN = 1792,
		SDL_EVENT_FINGER_UP = 1793,
		SDL_EVENT_FINGER_MOTION = 1794,
		SDL_EVENT_FINGER_CANCELED = 1795,
		SDL_EVENT_CLIPBOARD_UPDATE = 2304,
		SDL_EVENT_DROP_FILE = 4096,
		SDL_EVENT_DROP_TEXT = 4097,
		SDL_EVENT_DROP_BEGIN = 4098,
		SDL_EVENT_DROP_COMPLETE = 4099,
		SDL_EVENT_DROP_POSITION = 4100,
		SDL_EVENT_AUDIO_DEVICE_ADDED = 4352,
		SDL_EVENT_AUDIO_DEVICE_REMOVED = 4353,
		SDL_EVENT_AUDIO_DEVICE_FORMAT_CHANGED = 4354,
		SDL_EVENT_SENSOR_UPDATE = 4608,
		SDL_EVENT_PEN_PROXIMITY_IN = 4864,
		SDL_EVENT_PEN_PROXIMITY_OUT = 4865,
		SDL_EVENT_PEN_DOWN = 4866,
		SDL_EVENT_PEN_UP = 4867,
		SDL_EVENT_PEN_BUTTON_DOWN = 4868,
		SDL_EVENT_PEN_BUTTON_UP = 4869,
		SDL_EVENT_PEN_MOTION = 4870,
		SDL_EVENT_PEN_AXIS = 4871,
		SDL_EVENT_CAMERA_DEVICE_ADDED = 5120,
		SDL_EVENT_CAMERA_DEVICE_REMOVED = 5121,
		SDL_EVENT_CAMERA_DEVICE_APPROVED = 5122,
		SDL_EVENT_CAMERA_DEVICE_DENIED = 5123,
		SDL_EVENT_RENDER_TARGETS_RESET = 8192,
		SDL_EVENT_RENDER_DEVICE_RESET = 8193,
		SDL_EVENT_RENDER_DEVICE_LOST = 8194,
		SDL_EVENT_PRIVATE0 = 16384,
		SDL_EVENT_PRIVATE1 = 16385,
		SDL_EVENT_PRIVATE2 = 16386,
		SDL_EVENT_PRIVATE3 = 16387,
		SDL_EVENT_POLL_SENTINEL = 32512,
		SDL_EVENT_USER = 32768,
		SDL_EVENT_LAST = 65535,
		SDL_EVENT_ENUM_PADDING = 2147483647,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_CommonEvent
	{
		public uint type;
		public uint reserved;
		public ulong timestamp;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_DisplayEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint displayID;
		public int data1;
		public int data2;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_WindowEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public int data1;
		public int data2;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_KeyboardDeviceEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_KeyboardEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public uint which;
		public SdlScancode.SDL_Scancode scancode;
		public uint key;
		public SdlKeycode.SDL_Keymod mod;
		public ushort raw;
		public SDLBool down;
		public SDLBool repeat;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_TextEditingEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public byte* text;
		public int start;
		public int length;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_TextEditingCandidatesEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public byte** candidates;
		public int num_candidates;
		public int selected_candidate;
		public SDLBool horizontal;
		public byte padding1;
		public byte padding2;
		public byte padding3;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_TextInputEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public byte* text;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_MouseDeviceEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_MouseMotionEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public uint which;
		public SdlMouse.SDL_MouseButtonFlags state;
		public float x;
		public float y;
		public float xrel;
		public float yrel;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_MouseButtonEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public uint which;
		public byte button;
		public SDLBool down;
		public byte clicks;
		public byte padding;
		public float x;
		public float y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_MouseWheelEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public uint which;
		public float x;
		public float y;
		public SdlMouse.SDL_MouseWheelDirection direction;
		public float mouse_x;
		public float mouse_y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_JoyAxisEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public byte axis;
		public byte padding1;
		public byte padding2;
		public byte padding3;
		public short value;
		public ushort padding4;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_JoyBallEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public byte ball;
		public byte padding1;
		public byte padding2;
		public byte padding3;
		public short xrel;
		public short yrel;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_JoyHatEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public byte hat;
		public byte value;
		public byte padding1;
		public byte padding2;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_JoyButtonEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public byte button;
		public SDLBool down;
		public byte padding1;
		public byte padding2;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_JoyDeviceEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_JoyBatteryEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public SdlPower.SDL_PowerState state;
		public int percent;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_GamepadAxisEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public byte axis;
		public byte padding1;
		public byte padding2;
		public byte padding3;
		public short value;
		public ushort padding4;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_GamepadButtonEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public byte button;
		public SDLBool down;
		public byte padding1;
		public byte padding2;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_GamepadDeviceEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_GamepadTouchpadEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public int touchpad;
		public int finger;
		public float x;
		public float y;
		public float pressure;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_GamepadSensorEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public int sensor;
		public fixed float data[3];
		public ulong sensor_timestamp;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_AudioDeviceEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public SDLBool recording;
		public byte padding1;
		public byte padding2;
		public byte padding3;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_CameraDeviceEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_RenderEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_TouchFingerEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public ulong touchID;
		public ulong fingerID;
		public float x;
		public float y;
		public float dx;
		public float dy;
		public float pressure;
		public uint windowID;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_PenProximityEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public uint which;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_PenMotionEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public uint which;
		public SdlPen.SDL_PenInputFlags pen_state;
		public float x;
		public float y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_PenTouchEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public uint which;
		public SdlPen.SDL_PenInputFlags pen_state;
		public float x;
		public float y;
		public SDLBool eraser;
		public SDLBool down;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_PenButtonEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public uint which;
		public SdlPen.SDL_PenInputFlags pen_state;
		public float x;
		public float y;
		public byte button;
		public SDLBool down;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_PenAxisEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public uint which;
		public SdlPen.SDL_PenInputFlags pen_state;
		public float x;
		public float y;
		public SdlPen.SDL_PenAxis axis;
		public float value;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_DropEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public float x;
		public float y;
		public byte* source;
		public byte* data;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_ClipboardEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public SDLBool owner;
		public int num_mime_types;
		public byte** mime_types;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_SensorEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
		public uint which;
		public fixed float data[6];
		public ulong sensor_timestamp;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_QuitEvent
	{
		public SDL_EventType type;
		public uint reserved;
		public ulong timestamp;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_UserEvent
	{
		public uint type;
		public uint reserved;
		public ulong timestamp;
		public uint windowID;
		public int code;
		public IntPtr data1;
		public IntPtr data2;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct SDL_Event
	{
		[FieldOffset(0)]
		public uint type;
		[FieldOffset(0)]
		public SDL_CommonEvent common;
		[FieldOffset(0)]
		public SDL_DisplayEvent display;
		[FieldOffset(0)]
		public SDL_WindowEvent window;
		[FieldOffset(0)]
		public SDL_KeyboardDeviceEvent kdevice;
		[FieldOffset(0)]
		public SDL_KeyboardEvent key;
		[FieldOffset(0)]
		public SDL_TextEditingEvent edit;
		[FieldOffset(0)]
		public SDL_TextEditingCandidatesEvent edit_candidates;
		[FieldOffset(0)]
		public SDL_TextInputEvent text;
		[FieldOffset(0)]
		public SDL_MouseDeviceEvent mdevice;
		[FieldOffset(0)]
		public SDL_MouseMotionEvent motion;
		[FieldOffset(0)]
		public SDL_MouseButtonEvent button;
		[FieldOffset(0)]
		public SDL_MouseWheelEvent wheel;
		[FieldOffset(0)]
		public SDL_JoyDeviceEvent jdevice;
		[FieldOffset(0)]
		public SDL_JoyAxisEvent jaxis;
		[FieldOffset(0)]
		public SDL_JoyBallEvent jball;
		[FieldOffset(0)]
		public SDL_JoyHatEvent jhat;
		[FieldOffset(0)]
		public SDL_JoyButtonEvent jbutton;
		[FieldOffset(0)]
		public SDL_JoyBatteryEvent jbattery;
		[FieldOffset(0)]
		public SDL_GamepadDeviceEvent gdevice;
		[FieldOffset(0)]
		public SDL_GamepadAxisEvent gaxis;
		[FieldOffset(0)]
		public SDL_GamepadButtonEvent gbutton;
		[FieldOffset(0)]
		public SDL_GamepadTouchpadEvent gtouchpad;
		[FieldOffset(0)]
		public SDL_GamepadSensorEvent gsensor;
		[FieldOffset(0)]
		public SDL_AudioDeviceEvent adevice;
		[FieldOffset(0)]
		public SDL_CameraDeviceEvent cdevice;
		[FieldOffset(0)]
		public SDL_SensorEvent sensor;
		[FieldOffset(0)]
		public SDL_QuitEvent quit;
		[FieldOffset(0)]
		public SDL_UserEvent user;
		[FieldOffset(0)]
		public SDL_TouchFingerEvent tfinger;
		[FieldOffset(0)]
		public SDL_PenProximityEvent pproximity;
		[FieldOffset(0)]
		public SDL_PenTouchEvent ptouch;
		[FieldOffset(0)]
		public SDL_PenMotionEvent pmotion;
		[FieldOffset(0)]
		public SDL_PenButtonEvent pbutton;
		[FieldOffset(0)]
		public SDL_PenAxisEvent paxis;
		[FieldOffset(0)]
		public SDL_RenderEvent render;
		[FieldOffset(0)]
		public SDL_DropEvent drop;
		[FieldOffset(0)]
		public SDL_ClipboardEvent clipboard;
		[FieldOffset(0)]
		public fixed byte padding[128];
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_PumpEvents();

	public enum SDL_EventAction
	{
		SDL_ADDEVENT = 0,
		SDL_PEEKEVENT = 1,
		SDL_GETEVENT = 2,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_PeepEvents(Span<SDL_Event> events, int numevents, SDL_EventAction action, uint minType, uint maxType);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HasEvent(uint type);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HasEvents(uint minType, uint maxType);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_FlushEvent(uint type);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_FlushEvents(uint minType, uint maxType);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_PollEvent(out SDL_Event @event);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_WaitEvent(out SDL_Event @event);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_WaitEventTimeout(out SDL_Event @event, int timeoutMS);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_PushEvent(ref SDL_Event @event);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate bool SDL_EventFilter(IntPtr userdata, SDL_Event* evt);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_SetEventFilter(SDL_EventFilter filter, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetEventFilter(out SDL_EventFilter filter, out IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_AddEventWatch(SDL_EventFilter filter, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_RemoveEventWatch(SDL_EventFilter filter, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_FilterEvents(SDL_EventFilter filter, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_SetEventEnabled(uint type, SDLBool enabled);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_EventEnabled(uint type);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_RegisterEvents(int numevents);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetWindowFromEvent(ref SDL_Event @event);

}
