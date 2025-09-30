using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlMessagebox
{
    private const string NativeLibName = SDL.NativeLibName;

	[Flags]
	public enum SDL_MessageBoxFlags : uint
	{
		SDL_MESSAGEBOX_ERROR = 0x10,
		SDL_MESSAGEBOX_WARNING = 0x20,
		SDL_MESSAGEBOX_INFORMATION = 0x40,
		SDL_MESSAGEBOX_BUTTONS_LEFT_TO_RIGHT = 0x080,
		SDL_MESSAGEBOX_BUTTONS_RIGHT_TO_LEFT = 0x100,
	}

	[Flags]
	public enum SDL_MessageBoxButtonFlags : uint
	{
		SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT = 0x1,
		SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT = 0x2,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_MessageBoxButtonData
	{
		public SDL_MessageBoxButtonFlags flags;
		public int buttonID;
		public byte* text;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_MessageBoxColor
	{
		public byte r;
		public byte g;
		public byte b;
	}

	public enum SDL_MessageBoxColorType
	{
		SDL_MESSAGEBOX_COLOR_BACKGROUND = 0,
		SDL_MESSAGEBOX_COLOR_TEXT = 1,
		SDL_MESSAGEBOX_COLOR_BUTTON_BORDER = 2,
		SDL_MESSAGEBOX_COLOR_BUTTON_BACKGROUND = 3,
		SDL_MESSAGEBOX_COLOR_BUTTON_SELECTED = 4,
		SDL_MESSAGEBOX_COLOR_COUNT = 5,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_MessageBoxColorScheme
	{
		public SDL_MessageBoxColor colors0;
		public SDL_MessageBoxColor colors1;
		public SDL_MessageBoxColor colors2;
		public SDL_MessageBoxColor colors3;
		public SDL_MessageBoxColor colors4;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_MessageBoxData
	{
		public SDL_MessageBoxFlags flags;
		public IntPtr window;
		public byte* title;
		public byte* message;
		public int numbuttons;
		public SDL_MessageBoxButtonData* buttons;
		public SDL_MessageBoxColorScheme* colorScheme;
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ShowMessageBox(ref SDL_MessageBoxData messageboxdata, out int buttonid);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ShowSimpleMessageBox(SDL_MessageBoxFlags flags, string title, string message, IntPtr window);

}
