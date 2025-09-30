using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlAssert
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_AssertState
	{
		SDL_ASSERTION_RETRY = 0,
		SDL_ASSERTION_BREAK = 1,
		SDL_ASSERTION_ABORT = 2,
		SDL_ASSERTION_IGNORE = 3,
		SDL_ASSERTION_ALWAYS_IGNORE = 4,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_AssertData
	{
		public SDLBool always_ignore;
		public uint trigger_count;
		public byte* condition;
		public byte* filename;
		public int linenum;
		public byte* function;
		public SDL_AssertData* next;
	}

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_AssertState SDL_ReportAssertion(ref SDL_AssertData data, string func, string file, int line);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate SDL_AssertState SDL_AssertionHandler(SDL_AssertData* data, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_SetAssertionHandler(SDL_AssertionHandler handler, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_AssertionHandler SDL_GetDefaultAssertionHandler();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_AssertionHandler SDL_GetAssertionHandler(out IntPtr puserdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_AssertData* SDL_GetAssertionReport();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_ResetAssertionReport();

}
