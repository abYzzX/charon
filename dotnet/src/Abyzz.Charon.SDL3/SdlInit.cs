using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlInit
{
    private const string NativeLibName = SDL.NativeLibName;

	public const string SDL_PROP_APP_METADATA_NAME_STRING = "SDL.app.metadata.name";
	public const string SDL_PROP_APP_METADATA_VERSION_STRING = "SDL.app.metadata.version";
	public const string SDL_PROP_APP_METADATA_IDENTIFIER_STRING = "SDL.app.metadata.identifier";
	public const string SDL_PROP_APP_METADATA_CREATOR_STRING = "SDL.app.metadata.creator";
	public const string SDL_PROP_APP_METADATA_COPYRIGHT_STRING = "SDL.app.metadata.copyright";
	public const string SDL_PROP_APP_METADATA_URL_STRING = "SDL.app.metadata.url";
	public const string SDL_PROP_APP_METADATA_TYPE_STRING = "SDL.app.metadata.type";

	[Flags]
	public enum SDL_InitFlags : uint
	{
		SDL_INIT_TIMER = 0x1,
		SDL_INIT_AUDIO = 0x10,
		SDL_INIT_VIDEO = 0x20,
		SDL_INIT_JOYSTICK = 0x200,
		SDL_INIT_HAPTIC = 0x1000,
		SDL_INIT_GAMEPAD = 0x2000,
		SDL_INIT_EVENTS = 0x4000,
		SDL_INIT_SENSOR = 0x08000,
		SDL_INIT_CAMERA = 0x10000,
	}

	public enum SDL_AppResult
	{
		SDL_APP_CONTINUE = 0,
		SDL_APP_SUCCESS = 1,
		SDL_APP_FAILURE = 2,
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate SDL_AppResult SDL_AppInit_func(IntPtr appstate, int argc, IntPtr argv);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate SDL_AppResult SDL_AppIterate_func(IntPtr appstate);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate SDL_AppResult SDL_AppEvent_func(IntPtr appstate, SdlEvents.SDL_Event* evt);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SDL_AppQuit_func(IntPtr appstate, SDL_AppResult result);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_Init(SDL_InitFlags flags);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_InitSubSystem(SDL_InitFlags flags);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_QuitSubSystem(SDL_InitFlags flags);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_InitFlags SDL_WasInit(SDL_InitFlags flags);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_Quit();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_IsMainThread();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SDL_MainThreadCallback(IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RunOnMainThread(SDL_MainThreadCallback callback, IntPtr userdata, SDLBool wait_complete);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAppMetadata(string appname, string appversion, string appidentifier);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAppMetadataProperty(string name, string value);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetAppMetadataProperty(string name);

}
