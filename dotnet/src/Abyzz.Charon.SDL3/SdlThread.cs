using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlThread
{
    private const string NativeLibName = SDL.NativeLibName;

	public const string SDL_PROP_THREAD_CREATE_ENTRY_FUNCTION_POINTER = "SDL.thread.create.entry_function";
	public const string SDL_PROP_THREAD_CREATE_NAME_STRING = "SDL.thread.create.name";
	public const string SDL_PROP_THREAD_CREATE_USERDATA_POINTER = "SDL.thread.create.userdata";
	public const string SDL_PROP_THREAD_CREATE_STACKSIZE_NUMBER = "SDL.thread.create.stacksize";

	public enum SDL_ThreadPriority
	{
		SDL_THREAD_PRIORITY_LOW = 0,
		SDL_THREAD_PRIORITY_NORMAL = 1,
		SDL_THREAD_PRIORITY_HIGH = 2,
		SDL_THREAD_PRIORITY_TIME_CRITICAL = 3,
	}

	public enum SDL_ThreadState
	{
		SDL_THREAD_UNKNOWN = 0,
		SDL_THREAD_ALIVE = 1,
		SDL_THREAD_DETACHED = 2,
		SDL_THREAD_COMPLETE = 3,
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate int SDL_ThreadFunction(IntPtr data);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateThreadRuntime(SDL_ThreadFunction fn, string name, IntPtr data, IntPtr pfnBeginThread, IntPtr pfnEndThread);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateThreadWithPropertiesRuntime(uint props, IntPtr pfnBeginThread, IntPtr pfnEndThread);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetThreadName(IntPtr thread);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ulong SDL_GetCurrentThreadID();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ulong SDL_GetThreadID(IntPtr thread);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetCurrentThreadPriority(SDL_ThreadPriority priority);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_WaitThread(IntPtr thread, IntPtr status);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_ThreadState SDL_GetThreadState(IntPtr thread);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DetachThread(IntPtr thread);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetTLS(IntPtr id);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SDL_TLSDestructorCallback(IntPtr value);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetTLS(IntPtr id, IntPtr value, SDL_TLSDestructorCallback destructor);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_CleanupTLS();

}
