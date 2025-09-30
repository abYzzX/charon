using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlAtomic
{
    private const string NativeLibName = SDL.NativeLibName;

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_TryLockSpinlock(IntPtr @lock);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_LockSpinlock(IntPtr @lock);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_UnlockSpinlock(IntPtr @lock);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_MemoryBarrierReleaseFunction();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_MemoryBarrierAcquireFunction();

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_AtomicInt
	{
		public int value;
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CompareAndSwapAtomicInt(ref SDL_AtomicInt a, int oldval, int newval);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_SetAtomicInt(ref SDL_AtomicInt a, int v);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetAtomicInt(ref SDL_AtomicInt a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_AddAtomicInt(ref SDL_AtomicInt a, int v);

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_AtomicU32
	{
		public uint value;
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CompareAndSwapAtomicU32(ref SDL_AtomicU32 a, uint oldval, uint newval);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_SetAtomicU32(ref SDL_AtomicU32 a, uint v);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetAtomicU32(ref SDL_AtomicU32 a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CompareAndSwapAtomicPointer(ref IntPtr a, IntPtr oldval, IntPtr newval);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_SetAtomicPointer(ref IntPtr a, IntPtr v);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetAtomicPointer(ref IntPtr a);

}
