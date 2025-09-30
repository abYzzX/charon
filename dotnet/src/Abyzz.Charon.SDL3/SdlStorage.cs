using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlStorage
{
    private const string NativeLibName = SDL.NativeLibName;

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_StorageInterface
	{
		public uint version;
		public IntPtr close; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr ready; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr enumerate; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr info; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr read_file; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr write_file; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr mkdir; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr remove; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr rename; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr copy; // WARN_ANONYMOUS_FUNCTION_POINTER
		public IntPtr space_remaining; // WARN_ANONYMOUS_FUNCTION_POINTER
	}

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_OpenTitleStorage(string @override, uint props);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_OpenUserStorage(string org, string app, uint props);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_OpenFileStorage(string path);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_OpenStorage(ref SDL_StorageInterface iface, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CloseStorage(IntPtr storage);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_StorageReady(IntPtr storage);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetStorageFileSize(IntPtr storage, string path, out ulong length);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ReadStorageFile(IntPtr storage, string path, IntPtr destination, ulong length);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_WriteStorageFile(IntPtr storage, string path, IntPtr source, ulong length);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CreateStorageDirectory(IntPtr storage, string path);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_EnumerateStorageDirectory(IntPtr storage, string path, SdlFilesystem.SDL_EnumerateDirectoryCallback callback, IntPtr userdata);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RemoveStoragePath(IntPtr storage, string path);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenameStoragePath(IntPtr storage, string oldpath, string newpath);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CopyStorageFile(IntPtr storage, string oldpath, string newpath);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetStoragePathInfo(IntPtr storage, string path, out SdlFilesystem.SDL_PathInfo info);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ulong SDL_GetStorageSpaceRemaining(IntPtr storage);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GlobStorageDirectory(IntPtr storage, string path, string pattern, SdlFilesystem.SDL_GlobFlags flags, out int count);

}
