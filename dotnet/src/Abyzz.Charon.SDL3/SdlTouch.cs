using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlTouch
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_TouchDeviceType
	{
		SDL_TOUCH_DEVICE_INVALID = -1,
		SDL_TOUCH_DEVICE_DIRECT = 0,
		SDL_TOUCH_DEVICE_INDIRECT_ABSOLUTE = 1,
		SDL_TOUCH_DEVICE_INDIRECT_RELATIVE = 2,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_Finger
	{
		public ulong id;
		public float x;
		public float y;
		public float pressure;
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetTouchDevices(out int count);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetTouchDeviceName(ulong touchID);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_TouchDeviceType SDL_GetTouchDeviceType(ulong touchID);

	public static Span<IntPtr> SDL_GetTouchFingers(ulong touchID)
	{
		var result = SDL_GetTouchFingers(touchID, out var count);
		return new Span<IntPtr>((void*) result, count);
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetTouchFingers(ulong touchID, out int count);

}
