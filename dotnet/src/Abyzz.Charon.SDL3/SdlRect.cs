using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlRect
{
    private const string NativeLibName = SDL.NativeLibName;

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_Point
	{
		public int x;
		public int y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_FPoint
	{
		public float x;
		public float y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_Rect
	{
		public int x;
		public int y;
		public int w;
		public int h;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_FRect
	{
		public float x;
		public float y;
		public float w;
		public float h;
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HasRectIntersection(ref SDL_Rect A, ref SDL_Rect B);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRectIntersection(ref SDL_Rect A, ref SDL_Rect B, out SDL_Rect result);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRectUnion(ref SDL_Rect A, ref SDL_Rect B, out SDL_Rect result);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRectEnclosingPoints(Span<SDL_Point> points, int count, ref SDL_Rect clip, out SDL_Rect result);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRectAndLineIntersection(ref SDL_Rect rect, ref int X1, ref int Y1, ref int X2, ref int Y2);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HasRectIntersectionFloat(ref SDL_FRect A, ref SDL_FRect B);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRectIntersectionFloat(ref SDL_FRect A, ref SDL_FRect B, out SDL_FRect result);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRectUnionFloat(ref SDL_FRect A, ref SDL_FRect B, out SDL_FRect result);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRectEnclosingPointsFloat(Span<SDL_FPoint> points, int count, ref SDL_FRect clip, out SDL_FRect result);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRectAndLineIntersectionFloat(ref SDL_FRect rect, ref float X1, ref float Y1, ref float X2, ref float Y2);

}
