using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlPower
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_PowerState
	{
		SDL_POWERSTATE_ERROR = -1,
		SDL_POWERSTATE_UNKNOWN = 0,
		SDL_POWERSTATE_ON_BATTERY = 1,
		SDL_POWERSTATE_NO_BATTERY = 2,
		SDL_POWERSTATE_CHARGING = 3,
		SDL_POWERSTATE_CHARGED = 4,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_PowerState SDL_GetPowerInfo(out int seconds, out int percent);

}
