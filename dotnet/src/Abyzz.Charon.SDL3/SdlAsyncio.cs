using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlAsyncio
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_AsyncIOTaskType
	{
		SDL_ASYNCIO_TASK_READ = 0,
		SDL_ASYNCIO_TASK_WRITE = 1,
		SDL_ASYNCIO_TASK_CLOSE = 2,
	}

	public enum SDL_AsyncIOResult
	{
		SDL_ASYNCIO_COMPLETE = 0,
		SDL_ASYNCIO_FAILURE = 1,
		SDL_ASYNCIO_CANCELED = 2,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_AsyncIOOutcome
	{
		public IntPtr asyncio;
		public SDL_AsyncIOTaskType type;
		public SDL_AsyncIOResult result;
		public IntPtr buffer;
		public ulong offset;
		public ulong bytes_requested;
		public ulong bytes_transferred;
		public IntPtr userdata;
	}

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_AsyncIOFromFile(string file, string mode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial long SDL_GetAsyncIOSize(IntPtr asyncio);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ReadAsyncIO(IntPtr asyncio, IntPtr ptr, ulong offset, ulong size, IntPtr queue, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_WriteAsyncIO(IntPtr asyncio, IntPtr ptr, ulong offset, ulong size, IntPtr queue, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CloseAsyncIO(IntPtr asyncio, SDLBool flush, IntPtr queue, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateAsyncIOQueue();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DestroyAsyncIOQueue(IntPtr queue);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetAsyncIOResult(IntPtr queue, out SDL_AsyncIOOutcome outcome);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_WaitAsyncIOResult(IntPtr queue, out SDL_AsyncIOOutcome outcome, int timeoutMS);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_SignalAsyncIOQueue(IntPtr queue);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_LoadFileAsync(string file, IntPtr queue, IntPtr userdata);

}
