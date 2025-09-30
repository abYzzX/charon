using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlTime
{
    private const string NativeLibName = SDL.NativeLibName;

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_DateTime
	{
		public int year;
		public int month;
		public int day;
		public int hour;
		public int minute;
		public int second;
		public int nanosecond;
		public int day_of_week;
		public int utc_offset;
	}

	public enum SDL_DateFormat
	{
		SDL_DATE_FORMAT_YYYYMMDD = 0,
		SDL_DATE_FORMAT_DDMMYYYY = 1,
		SDL_DATE_FORMAT_MMDDYYYY = 2,
	}

	public enum SDL_TimeFormat
	{
		SDL_TIME_FORMAT_24HR = 0,
		SDL_TIME_FORMAT_12HR = 1,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetDateTimeLocalePreferences(out SDL_DateFormat dateFormat, out SDL_TimeFormat timeFormat);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetCurrentTime(IntPtr ticks);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_TimeToDateTime(long ticks, out SDL_DateTime dt, SDLBool localTime);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_DateTimeToTime(ref SDL_DateTime dt, IntPtr ticks);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_TimeToWindows(long ticks, out uint dwLowDateTime, out uint dwHighDateTime);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial long SDL_TimeFromWindows(uint dwLowDateTime, uint dwHighDateTime);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetDaysInMonth(int year, int month);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetDayOfYear(int year, int month, int day);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetDayOfWeek(int year, int month, int day);

}
