using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlError
{
    private const string NativeLibName = SDL.NativeLibName;

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetError(string fmt);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_OutOfMemory();

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetError();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ClearError();

}
