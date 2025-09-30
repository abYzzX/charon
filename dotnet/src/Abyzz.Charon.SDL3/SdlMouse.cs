using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlMouse
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_SystemCursor
	{
		SDL_SYSTEM_CURSOR_DEFAULT = 0,
		SDL_SYSTEM_CURSOR_TEXT = 1,
		SDL_SYSTEM_CURSOR_WAIT = 2,
		SDL_SYSTEM_CURSOR_CROSSHAIR = 3,
		SDL_SYSTEM_CURSOR_PROGRESS = 4,
		SDL_SYSTEM_CURSOR_NWSE_RESIZE = 5,
		SDL_SYSTEM_CURSOR_NESW_RESIZE = 6,
		SDL_SYSTEM_CURSOR_EW_RESIZE = 7,
		SDL_SYSTEM_CURSOR_NS_RESIZE = 8,
		SDL_SYSTEM_CURSOR_MOVE = 9,
		SDL_SYSTEM_CURSOR_NOT_ALLOWED = 10,
		SDL_SYSTEM_CURSOR_POINTER = 11,
		SDL_SYSTEM_CURSOR_NW_RESIZE = 12,
		SDL_SYSTEM_CURSOR_N_RESIZE = 13,
		SDL_SYSTEM_CURSOR_NE_RESIZE = 14,
		SDL_SYSTEM_CURSOR_E_RESIZE = 15,
		SDL_SYSTEM_CURSOR_SE_RESIZE = 16,
		SDL_SYSTEM_CURSOR_S_RESIZE = 17,
		SDL_SYSTEM_CURSOR_SW_RESIZE = 18,
		SDL_SYSTEM_CURSOR_W_RESIZE = 19,
		SDL_SYSTEM_CURSOR_COUNT = 20,
	}

	public enum SDL_MouseWheelDirection
	{
		SDL_MOUSEWHEEL_NORMAL = 0,
		SDL_MOUSEWHEEL_FLIPPED = 1,
	}

	[Flags]
	public enum SDL_MouseButtonFlags : uint
	{
		SDL_BUTTON_LMASK = 0x1,
		SDL_BUTTON_MMASK = 0x2,
		SDL_BUTTON_RMASK = 0x4,
		SDL_BUTTON_X1MASK = 0x08,
		SDL_BUTTON_X2MASK = 0x10,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HasMouse();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetMice(out int count);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetMouseNameForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetMouseFocus();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_MouseButtonFlags SDL_GetMouseState(out float x, out float y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_MouseButtonFlags SDL_GetGlobalMouseState(out float x, out float y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_MouseButtonFlags SDL_GetRelativeMouseState(out float x, out float y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_WarpMouseInWindow(IntPtr window, float x, float y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_WarpMouseGlobal(float x, float y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowRelativeMouseMode(IntPtr window, SDLBool enabled);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowRelativeMouseMode(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CaptureMouse(SDLBool enabled);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateCursor(IntPtr data, IntPtr mask, int w, int h, int hot_x, int hot_y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateColorCursor(IntPtr surface, int hot_x, int hot_y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateSystemCursor(SDL_SystemCursor id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetCursor(IntPtr cursor);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetCursor();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetDefaultCursor();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DestroyCursor(IntPtr cursor);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ShowCursor();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HideCursor();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CursorVisible();

}
