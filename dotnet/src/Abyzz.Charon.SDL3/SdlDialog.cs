using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlDialog
{
    private const string NativeLibName = SDL.NativeLibName;

	public const string SDL_PROP_FILE_DIALOG_FILTERS_POINTER = "SDL.filedialog.filters";
	public const string SDL_PROP_FILE_DIALOG_NFILTERS_NUMBER = "SDL.filedialog.nfilters";
	public const string SDL_PROP_FILE_DIALOG_WINDOW_POINTER = "SDL.filedialog.window";
	public const string SDL_PROP_FILE_DIALOG_LOCATION_STRING = "SDL.filedialog.location";
	public const string SDL_PROP_FILE_DIALOG_MANY_BOOLEAN = "SDL.filedialog.many";
	public const string SDL_PROP_FILE_DIALOG_TITLE_STRING = "SDL.filedialog.title";
	public const string SDL_PROP_FILE_DIALOG_ACCEPT_STRING = "SDL.filedialog.accept";
	public const string SDL_PROP_FILE_DIALOG_CANCEL_STRING = "SDL.filedialog.cancel";

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_DialogFileFilter
	{
		public byte* name;
		public byte* pattern;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SDL_DialogFileCallback(IntPtr userdata, IntPtr filelist, int filter);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_ShowOpenFileDialog(SDL_DialogFileCallback callback, IntPtr userdata, IntPtr window, Span<SDL_DialogFileFilter> filters, int nfilters, string default_location, SDLBool allow_many);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_ShowSaveFileDialog(SDL_DialogFileCallback callback, IntPtr userdata, IntPtr window, Span<SDL_DialogFileFilter> filters, int nfilters, string default_location);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_ShowOpenFolderDialog(SDL_DialogFileCallback callback, IntPtr userdata, IntPtr window, string default_location, SDLBool allow_many);

	public enum SDL_FileDialogType
	{
		SDL_FILEDIALOG_OPENFILE = 0,
		SDL_FILEDIALOG_SAVEFILE = 1,
		SDL_FILEDIALOG_OPENFOLDER = 2,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_ShowFileDialogWithProperties(SDL_FileDialogType type, SDL_DialogFileCallback callback, IntPtr userdata, uint props);

}
