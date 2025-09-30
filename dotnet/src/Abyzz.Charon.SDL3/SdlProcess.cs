using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlProcess
{
    private const string NativeLibName = SDL.NativeLibName;

	public const string SDL_PROP_PROCESS_CREATE_ARGS_POINTER = "SDL.process.create.args";
	public const string SDL_PROP_PROCESS_CREATE_ENVIRONMENT_POINTER = "SDL.process.create.environment";
	public const string SDL_PROP_PROCESS_CREATE_STDIN_NUMBER = "SDL.process.create.stdin_option";
	public const string SDL_PROP_PROCESS_CREATE_STDIN_POINTER = "SDL.process.create.stdin_source";
	public const string SDL_PROP_PROCESS_CREATE_STDOUT_NUMBER = "SDL.process.create.stdout_option";
	public const string SDL_PROP_PROCESS_CREATE_STDOUT_POINTER = "SDL.process.create.stdout_source";
	public const string SDL_PROP_PROCESS_CREATE_STDERR_NUMBER = "SDL.process.create.stderr_option";
	public const string SDL_PROP_PROCESS_CREATE_STDERR_POINTER = "SDL.process.create.stderr_source";
	public const string SDL_PROP_PROCESS_CREATE_STDERR_TO_STDOUT_BOOLEAN = "SDL.process.create.stderr_to_stdout";
	public const string SDL_PROP_PROCESS_CREATE_BACKGROUND_BOOLEAN = "SDL.process.create.background";
	public const string SDL_PROP_PROCESS_PID_NUMBER = "SDL.process.pid";
	public const string SDL_PROP_PROCESS_STDIN_POINTER = "SDL.process.stdin";
	public const string SDL_PROP_PROCESS_STDOUT_POINTER = "SDL.process.stdout";
	public const string SDL_PROP_PROCESS_STDERR_POINTER = "SDL.process.stderr";
	public const string SDL_PROP_PROCESS_BACKGROUND_BOOLEAN = "SDL.process.background";

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateProcess(IntPtr args, SDLBool pipe_stdio);

	public enum SDL_ProcessIO
	{
		SDL_PROCESS_STDIO_INHERITED = 0,
		SDL_PROCESS_STDIO_NULL = 1,
		SDL_PROCESS_STDIO_APP = 2,
		SDL_PROCESS_STDIO_REDIRECT = 3,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateProcessWithProperties(uint props);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetProcessProperties(IntPtr process);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_ReadProcess(IntPtr process, out UIntPtr datasize, out int exitcode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetProcessInput(IntPtr process);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetProcessOutput(IntPtr process);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_KillProcess(IntPtr process, SDLBool force);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_WaitProcess(IntPtr process, SDLBool block, out int exitcode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DestroyProcess(IntPtr process);

}
