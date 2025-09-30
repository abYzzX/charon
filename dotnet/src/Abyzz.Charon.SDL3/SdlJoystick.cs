using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlJoystick
{
    private const string NativeLibName = SDL.NativeLibName;

	public const string SDL_PROP_JOYSTICK_CAP_MONO_LED_BOOLEAN = "SDL.joystick.cap.mono_led";
	public const string SDL_PROP_JOYSTICK_CAP_RGB_LED_BOOLEAN = "SDL.joystick.cap.rgb_led";
	public const string SDL_PROP_JOYSTICK_CAP_PLAYER_LED_BOOLEAN = "SDL.joystick.cap.player_led";
	public const string SDL_PROP_JOYSTICK_CAP_RUMBLE_BOOLEAN = "SDL.joystick.cap.rumble";
	public const string SDL_PROP_JOYSTICK_CAP_TRIGGER_RUMBLE_BOOLEAN = "SDL.joystick.cap.trigger_rumble";

	public enum SDL_JoystickType
	{
		SDL_JOYSTICK_TYPE_UNKNOWN = 0,
		SDL_JOYSTICK_TYPE_GAMEPAD = 1,
		SDL_JOYSTICK_TYPE_WHEEL = 2,
		SDL_JOYSTICK_TYPE_ARCADE_STICK = 3,
		SDL_JOYSTICK_TYPE_FLIGHT_STICK = 4,
		SDL_JOYSTICK_TYPE_DANCE_PAD = 5,
		SDL_JOYSTICK_TYPE_GUITAR = 6,
		SDL_JOYSTICK_TYPE_DRUM_KIT = 7,
		SDL_JOYSTICK_TYPE_ARCADE_PAD = 8,
		SDL_JOYSTICK_TYPE_THROTTLE = 9,
		SDL_JOYSTICK_TYPE_COUNT = 10,
	}

	public enum SDL_JoystickConnectionState
	{
		SDL_JOYSTICK_CONNECTION_INVALID = -1,
		SDL_JOYSTICK_CONNECTION_UNKNOWN = 0,
		SDL_JOYSTICK_CONNECTION_WIRED = 1,
		SDL_JOYSTICK_CONNECTION_WIRELESS = 2,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_LockJoysticks();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_UnlockJoysticks();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HasJoystick();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetJoysticks(out int count);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetJoystickNameForID(uint instance_id);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetJoystickPathForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetJoystickPlayerIndexForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlGuid.SDL_GUID SDL_GetJoystickGUIDForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetJoystickVendorForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetJoystickProductForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetJoystickProductVersionForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_JoystickType SDL_GetJoystickTypeForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_OpenJoystick(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetJoystickFromID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetJoystickFromPlayerIndex(int player_index);

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_VirtualJoystickTouchpadDesc
	{
		public ushort nfingers;
		public fixed ushort padding[3];
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_VirtualJoystickSensorDesc
	{
		public SdlSensor.SDL_SensorType type;
		public float rate;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_VirtualJoystickDesc
	{
		public uint version;
		public ushort type;
		public ushort padding;
		public ushort vendor_id;
		public ushort product_id;
		public ushort naxes;
		public ushort nbuttons;
		public ushort nballs;
		public ushort nhats;
		public ushort ntouchpads;
		public ushort nsensors;
		public fixed ushort padding2[2];
		public uint button_mask;
		public uint axis_mask;
		public byte* name;
		public SDL_VirtualJoystickTouchpadDesc* touchpads;
		public SDL_VirtualJoystickSensorDesc* sensors;
		public IntPtr userdata;
		public IntPtr Update; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr SetPlayerIndex; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr Rumble; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr RumbleTriggers; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr SetLED; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr SendEffect; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr SetSensorsEnabled; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr Cleanup; // WARN_ANONYMOUS_FUNCTION_POINTER
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_AttachVirtualJoystick(ref SDL_VirtualJoystickDesc desc);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_DetachVirtualJoystick(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_IsJoystickVirtual(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetJoystickVirtualAxis(IntPtr joystick, int axis, short value);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetJoystickVirtualBall(IntPtr joystick, int ball, short xrel, short yrel);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetJoystickVirtualButton(IntPtr joystick, int button, SDLBool down);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetJoystickVirtualHat(IntPtr joystick, int hat, byte value);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetJoystickVirtualTouchpad(IntPtr joystick, int touchpad, int finger, SDLBool down, float x, float y, float pressure);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SendJoystickVirtualSensorData(IntPtr joystick, SdlSensor.SDL_SensorType type, ulong sensor_timestamp, float* data, int num_values);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetJoystickProperties(IntPtr joystick);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetJoystickName(IntPtr joystick);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetJoystickPath(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetJoystickPlayerIndex(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetJoystickPlayerIndex(IntPtr joystick, int player_index);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlGuid.SDL_GUID SDL_GetJoystickGUID(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetJoystickVendor(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetJoystickProduct(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetJoystickProductVersion(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetJoystickFirmwareVersion(IntPtr joystick);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetJoystickSerial(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_JoystickType SDL_GetJoystickType(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_GetJoystickGUIDInfo(SdlGuid.SDL_GUID guid, out ushort vendor, out ushort product, out ushort version, out ushort crc16);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_JoystickConnected(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetJoystickID(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetNumJoystickAxes(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetNumJoystickBalls(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetNumJoystickHats(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetNumJoystickButtons(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_SetJoystickEventsEnabled(SDLBool enabled);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_JoystickEventsEnabled();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_UpdateJoysticks();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial short SDL_GetJoystickAxis(IntPtr joystick, int axis);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetJoystickAxisInitialState(IntPtr joystick, int axis, out short state);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetJoystickBall(IntPtr joystick, int ball, out int dx, out int dy);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial byte SDL_GetJoystickHat(IntPtr joystick, int hat);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetJoystickButton(IntPtr joystick, int button);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RumbleJoystick(IntPtr joystick, ushort low_frequency_rumble, ushort high_frequency_rumble, uint duration_ms);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RumbleJoystickTriggers(IntPtr joystick, ushort left_rumble, ushort right_rumble, uint duration_ms);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetJoystickLED(IntPtr joystick, byte red, byte green, byte blue);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SendJoystickEffect(IntPtr joystick, IntPtr data, int size);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_CloseJoystick(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_JoystickConnectionState SDL_GetJoystickConnectionState(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlPower.SDL_PowerState SDL_GetJoystickPowerInfo(IntPtr joystick, out int percent);

}
