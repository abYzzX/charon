using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlGuid
{
    private const string NativeLibName = SDL.NativeLibName;

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_GUID
	{
		public fixed byte data[16];
	}

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_GUIDToString(SDL_GUID guid, string pszGUID, int cbGUID);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_GUID SDL_StringToGUID(string pchGUID);

}
