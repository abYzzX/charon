using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlFilesystem
{
    private const string NativeLibName = SDL.NativeLibName;

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetBasePath();

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(CallerOwnedStringMarshaller))]
	public static partial string SDL_GetPrefPath(string org, string app);

	public enum SDL_Folder
	{
		SDL_FOLDER_HOME = 0,
		SDL_FOLDER_DESKTOP = 1,
		SDL_FOLDER_DOCUMENTS = 2,
		SDL_FOLDER_DOWNLOADS = 3,
		SDL_FOLDER_MUSIC = 4,
		SDL_FOLDER_PICTURES = 5,
		SDL_FOLDER_PUBLICSHARE = 6,
		SDL_FOLDER_SAVEDGAMES = 7,
		SDL_FOLDER_SCREENSHOTS = 8,
		SDL_FOLDER_TEMPLATES = 9,
		SDL_FOLDER_VIDEOS = 10,
		SDL_FOLDER_COUNT = 11,
	}

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetUserFolder(SDL_Folder folder);

	public enum SDL_PathType
	{
		SDL_PATHTYPE_NONE = 0,
		SDL_PATHTYPE_FILE = 1,
		SDL_PATHTYPE_DIRECTORY = 2,
		SDL_PATHTYPE_OTHER = 3,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_PathInfo
	{
		public SDL_PathType type;
		public ulong size;
		public long create_time;
		public long modify_time;
		public long access_time;
	}

	[Flags]
	public enum SDL_GlobFlags : uint
	{
		SDL_GLOB_CASEINSENSITIVE = 0x1,
	}

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CreateDirectory(string path);

	public enum SDL_EnumerationResult
	{
		SDL_ENUM_CONTINUE = 0,
		SDL_ENUM_SUCCESS = 1,
		SDL_ENUM_FAILURE = 2,
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate SDL_EnumerationResult SDL_EnumerateDirectoryCallback(IntPtr userdata, byte* dirname, byte* fname);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_EnumerateDirectory(string path, SDL_EnumerateDirectoryCallback callback, IntPtr userdata);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RemovePath(string path);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenamePath(string oldpath, string newpath);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CopyFile(string oldpath, string newpath);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetPathInfo(string path, out SDL_PathInfo info);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GlobDirectory(string path, string pattern, SDL_GlobFlags flags, out int count);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(CallerOwnedStringMarshaller))]
	public static partial string SDL_GetCurrentDirectory();

}
