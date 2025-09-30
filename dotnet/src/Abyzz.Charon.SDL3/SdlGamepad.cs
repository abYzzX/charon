using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlGamepad
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_GamepadType
	{
		SDL_GAMEPAD_TYPE_UNKNOWN = 0,
		SDL_GAMEPAD_TYPE_STANDARD = 1,
		SDL_GAMEPAD_TYPE_XBOX360 = 2,
		SDL_GAMEPAD_TYPE_XBOXONE = 3,
		SDL_GAMEPAD_TYPE_PS3 = 4,
		SDL_GAMEPAD_TYPE_PS4 = 5,
		SDL_GAMEPAD_TYPE_PS5 = 6,
		SDL_GAMEPAD_TYPE_NINTENDO_SWITCH_PRO = 7,
		SDL_GAMEPAD_TYPE_NINTENDO_SWITCH_JOYCON_LEFT = 8,
		SDL_GAMEPAD_TYPE_NINTENDO_SWITCH_JOYCON_RIGHT = 9,
		SDL_GAMEPAD_TYPE_NINTENDO_SWITCH_JOYCON_PAIR = 10,
		SDL_GAMEPAD_TYPE_COUNT = 11,
	}

	public enum SDL_GamepadButton
	{
		SDL_GAMEPAD_BUTTON_INVALID = -1,
		SDL_GAMEPAD_BUTTON_SOUTH = 0,
		SDL_GAMEPAD_BUTTON_EAST = 1,
		SDL_GAMEPAD_BUTTON_WEST = 2,
		SDL_GAMEPAD_BUTTON_NORTH = 3,
		SDL_GAMEPAD_BUTTON_BACK = 4,
		SDL_GAMEPAD_BUTTON_GUIDE = 5,
		SDL_GAMEPAD_BUTTON_START = 6,
		SDL_GAMEPAD_BUTTON_LEFT_STICK = 7,
		SDL_GAMEPAD_BUTTON_RIGHT_STICK = 8,
		SDL_GAMEPAD_BUTTON_LEFT_SHOULDER = 9,
		SDL_GAMEPAD_BUTTON_RIGHT_SHOULDER = 10,
		SDL_GAMEPAD_BUTTON_DPAD_UP = 11,
		SDL_GAMEPAD_BUTTON_DPAD_DOWN = 12,
		SDL_GAMEPAD_BUTTON_DPAD_LEFT = 13,
		SDL_GAMEPAD_BUTTON_DPAD_RIGHT = 14,
		SDL_GAMEPAD_BUTTON_MISC1 = 15,
		SDL_GAMEPAD_BUTTON_RIGHT_PADDLE1 = 16,
		SDL_GAMEPAD_BUTTON_LEFT_PADDLE1 = 17,
		SDL_GAMEPAD_BUTTON_RIGHT_PADDLE2 = 18,
		SDL_GAMEPAD_BUTTON_LEFT_PADDLE2 = 19,
		SDL_GAMEPAD_BUTTON_TOUCHPAD = 20,
		SDL_GAMEPAD_BUTTON_MISC2 = 21,
		SDL_GAMEPAD_BUTTON_MISC3 = 22,
		SDL_GAMEPAD_BUTTON_MISC4 = 23,
		SDL_GAMEPAD_BUTTON_MISC5 = 24,
		SDL_GAMEPAD_BUTTON_MISC6 = 25,
		SDL_GAMEPAD_BUTTON_COUNT = 26,
	}

	public enum SDL_GamepadButtonLabel
	{
		SDL_GAMEPAD_BUTTON_LABEL_UNKNOWN = 0,
		SDL_GAMEPAD_BUTTON_LABEL_A = 1,
		SDL_GAMEPAD_BUTTON_LABEL_B = 2,
		SDL_GAMEPAD_BUTTON_LABEL_X = 3,
		SDL_GAMEPAD_BUTTON_LABEL_Y = 4,
		SDL_GAMEPAD_BUTTON_LABEL_CROSS = 5,
		SDL_GAMEPAD_BUTTON_LABEL_CIRCLE = 6,
		SDL_GAMEPAD_BUTTON_LABEL_SQUARE = 7,
		SDL_GAMEPAD_BUTTON_LABEL_TRIANGLE = 8,
	}

	public enum SDL_GamepadAxis
	{
		SDL_GAMEPAD_AXIS_INVALID = -1,
		SDL_GAMEPAD_AXIS_LEFTX = 0,
		SDL_GAMEPAD_AXIS_LEFTY = 1,
		SDL_GAMEPAD_AXIS_RIGHTX = 2,
		SDL_GAMEPAD_AXIS_RIGHTY = 3,
		SDL_GAMEPAD_AXIS_LEFT_TRIGGER = 4,
		SDL_GAMEPAD_AXIS_RIGHT_TRIGGER = 5,
		SDL_GAMEPAD_AXIS_COUNT = 6,
	}

	public enum SDL_GamepadBindingType
	{
		SDL_GAMEPAD_BINDTYPE_NONE = 0,
		SDL_GAMEPAD_BINDTYPE_BUTTON = 1,
		SDL_GAMEPAD_BINDTYPE_AXIS = 2,
		SDL_GAMEPAD_BINDTYPE_HAT = 3,
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct SDL_GamepadBinding
	{
		[FieldOffset(0)]
		public SDL_GamepadBindingType input_type;
		[FieldOffset(4)]
		public int input_button;
		[FieldOffset(4)]
		public INTERNAL_SDL_GamepadBinding_input_axis input_axis;
		[FieldOffset(4)]
		public INTERNAL_SDL_GamepadBinding_input_hat input_hat;
		[FieldOffset(16)]
		public SDL_GamepadBindingType output_type;
		[FieldOffset(20)]
		public SDL_GamepadButton output_button;
		[FieldOffset(20)]
		public INTERNAL_SDL_GamepadBinding_output_axis output_axis;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct INTERNAL_SDL_GamepadBinding_input_axis
	{
		public int axis;
		public int axis_min;
		public int axis_max;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct INTERNAL_SDL_GamepadBinding_input_hat
	{
		public int hat;
		public int hat_mask;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct INTERNAL_SDL_GamepadBinding_output_axis
	{
		public SDL_GamepadAxis axis;
		public int axis_min;
		public int axis_max;
	}

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_AddGamepadMapping(string mapping);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_AddGamepadMappingsFromIO(IntPtr src, SDLBool closeio);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_AddGamepadMappingsFromFile(string file);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ReloadGamepadMappings();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetGamepadMappings(out int count);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(CallerOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadMappingForGUID(SdlGuid.SDL_GUID guid);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(CallerOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadMapping(IntPtr gamepad);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetGamepadMapping(uint instance_id, string mapping);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HasGamepad();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetGamepads(out int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_IsGamepad(uint instance_id);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadNameForID(uint instance_id);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadPathForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetGamepadPlayerIndexForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlGuid.SDL_GUID SDL_GetGamepadGUIDForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetGamepadVendorForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetGamepadProductForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetGamepadProductVersionForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_GamepadType SDL_GetGamepadTypeForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_GamepadType SDL_GetRealGamepadTypeForID(uint instance_id);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(CallerOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadMappingForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_OpenGamepad(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetGamepadFromID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetGamepadFromPlayerIndex(int player_index);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetGamepadProperties(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetGamepadID(IntPtr gamepad);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadName(IntPtr gamepad);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadPath(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_GamepadType SDL_GetGamepadType(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_GamepadType SDL_GetRealGamepadType(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetGamepadPlayerIndex(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetGamepadPlayerIndex(IntPtr gamepad, int player_index);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetGamepadVendor(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetGamepadProduct(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetGamepadProductVersion(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ushort SDL_GetGamepadFirmwareVersion(IntPtr gamepad);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadSerial(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ulong SDL_GetGamepadSteamHandle(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlJoystick.SDL_JoystickConnectionState SDL_GetGamepadConnectionState(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlPower.SDL_PowerState SDL_GetGamepadPowerInfo(IntPtr gamepad, out int percent);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GamepadConnected(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetGamepadJoystick(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_SetGamepadEventsEnabled(SDLBool enabled);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GamepadEventsEnabled();

	public static Span<IntPtr> SDL_GetGamepadBindings(IntPtr gamepad)
	{
		var result = SDL_GetGamepadBindings(gamepad, out var count);
		return new Span<IntPtr>((void*) result, count);
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetGamepadBindings(IntPtr gamepad, out int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_UpdateGamepads();

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_GamepadType SDL_GetGamepadTypeFromString(string str);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadStringForType(SDL_GamepadType type);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_GamepadAxis SDL_GetGamepadAxisFromString(string str);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadStringForAxis(SDL_GamepadAxis axis);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GamepadHasAxis(IntPtr gamepad, SDL_GamepadAxis axis);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial short SDL_GetGamepadAxis(IntPtr gamepad, SDL_GamepadAxis axis);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_GamepadButton SDL_GetGamepadButtonFromString(string str);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadStringForButton(SDL_GamepadButton button);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GamepadHasButton(IntPtr gamepad, SDL_GamepadButton button);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetGamepadButton(IntPtr gamepad, SDL_GamepadButton button);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_GamepadButtonLabel SDL_GetGamepadButtonLabelForType(SDL_GamepadType type, SDL_GamepadButton button);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_GamepadButtonLabel SDL_GetGamepadButtonLabel(IntPtr gamepad, SDL_GamepadButton button);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetNumGamepadTouchpads(IntPtr gamepad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetNumGamepadTouchpadFingers(IntPtr gamepad, int touchpad);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetGamepadTouchpadFinger(IntPtr gamepad, int touchpad, int finger, out SDLBool down, out float x, out float y, out float pressure);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GamepadHasSensor(IntPtr gamepad, SdlSensor.SDL_SensorType type);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetGamepadSensorEnabled(IntPtr gamepad, SdlSensor.SDL_SensorType type, SDLBool enabled);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GamepadSensorEnabled(IntPtr gamepad, SdlSensor.SDL_SensorType type);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial float SDL_GetGamepadSensorDataRate(IntPtr gamepad, SdlSensor.SDL_SensorType type);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetGamepadSensorData(IntPtr gamepad, SdlSensor.SDL_SensorType type, float* data, int num_values);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RumbleGamepad(IntPtr gamepad, ushort low_frequency_rumble, ushort high_frequency_rumble, uint duration_ms);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RumbleGamepadTriggers(IntPtr gamepad, ushort left_rumble, ushort right_rumble, uint duration_ms);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetGamepadLED(IntPtr gamepad, byte red, byte green, byte blue);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SendGamepadEffect(IntPtr gamepad, IntPtr data, int size);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_CloseGamepad(IntPtr gamepad);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadAppleSFSymbolsNameForButton(IntPtr gamepad, SDL_GamepadButton button);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetGamepadAppleSFSymbolsNameForAxis(IntPtr gamepad, SDL_GamepadAxis axis);

}
