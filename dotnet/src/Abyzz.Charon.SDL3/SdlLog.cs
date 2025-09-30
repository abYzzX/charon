using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlLog
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_LogCategory
	{
		SDL_LOG_CATEGORY_APPLICATION = 0,
		SDL_LOG_CATEGORY_ERROR = 1,
		SDL_LOG_CATEGORY_ASSERT = 2,
		SDL_LOG_CATEGORY_SYSTEM = 3,
		SDL_LOG_CATEGORY_AUDIO = 4,
		SDL_LOG_CATEGORY_VIDEO = 5,
		SDL_LOG_CATEGORY_RENDER = 6,
		SDL_LOG_CATEGORY_INPUT = 7,
		SDL_LOG_CATEGORY_TEST = 8,
		SDL_LOG_CATEGORY_GPU = 9,
		SDL_LOG_CATEGORY_RESERVED2 = 10,
		SDL_LOG_CATEGORY_RESERVED3 = 11,
		SDL_LOG_CATEGORY_RESERVED4 = 12,
		SDL_LOG_CATEGORY_RESERVED5 = 13,
		SDL_LOG_CATEGORY_RESERVED6 = 14,
		SDL_LOG_CATEGORY_RESERVED7 = 15,
		SDL_LOG_CATEGORY_RESERVED8 = 16,
		SDL_LOG_CATEGORY_RESERVED9 = 17,
		SDL_LOG_CATEGORY_RESERVED10 = 18,
		SDL_LOG_CATEGORY_CUSTOM = 19,
	}

	public enum SDL_LogPriority
	{
		SDL_LOG_PRIORITY_INVALID = 0,
		SDL_LOG_PRIORITY_TRACE = 1,
		SDL_LOG_PRIORITY_VERBOSE = 2,
		SDL_LOG_PRIORITY_DEBUG = 3,
		SDL_LOG_PRIORITY_INFO = 4,
		SDL_LOG_PRIORITY_WARN = 5,
		SDL_LOG_PRIORITY_ERROR = 6,
		SDL_LOG_PRIORITY_CRITICAL = 7,
		SDL_LOG_PRIORITY_COUNT = 8,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_SetLogPriorities(SDL_LogPriority priority);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_SetLogPriority(int category, SDL_LogPriority priority);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_LogPriority SDL_GetLogPriority(int category);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_ResetLogPriorities();

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetLogPriorityPrefix(SDL_LogPriority priority, string prefix);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_Log(string fmt);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_LogTrace(int category, string fmt);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_LogVerbose(int category, string fmt);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_LogDebug(int category, string fmt);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_LogInfo(int category, string fmt);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_LogWarn(int category, string fmt);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_LogError(int category, string fmt);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_LogCritical(int category, string fmt);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_LogMessage(int category, SDL_LogPriority priority, string fmt);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SDL_LogOutputFunction(IntPtr userdata, int category, SDL_LogPriority priority, byte* message);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_LogOutputFunction SDL_GetDefaultLogOutputFunction();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_GetLogOutputFunction(out SDL_LogOutputFunction callback, out IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_SetLogOutputFunction(SDL_LogOutputFunction callback, IntPtr userdata);

}
