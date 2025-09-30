using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlTimer
{
    private const string NativeLibName = SDL.NativeLibName;

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ulong SDL_GetTicks();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ulong SDL_GetTicksNS();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ulong SDL_GetPerformanceCounter();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial ulong SDL_GetPerformanceFrequency();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_Delay(uint ms);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DelayNS(ulong ns);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DelayPrecise(ulong ns);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate uint SDL_TimerCallback(IntPtr userdata, uint timerID, uint interval);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_AddTimer(uint interval, SDL_TimerCallback callback, IntPtr userdata);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate ulong SDL_NSTimerCallback(IntPtr userdata, uint timerID, ulong interval);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_AddTimerNS(ulong interval, SDL_NSTimerCallback callback, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RemoveTimer(uint id);

}
