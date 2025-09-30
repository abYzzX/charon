using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlLocale
{
    private const string NativeLibName = SDL.NativeLibName;

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_Locale
	{
		public byte* language;
		public byte* country;
	}

	public static Span<IntPtr> SDL_GetPreferredLocales()
	{
		var result = SDL_GetPreferredLocales(out var count);
		return new Span<IntPtr>((void*) result, count);
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetPreferredLocales(out int count);

}
