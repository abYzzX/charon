using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlSurface
{
    private const string NativeLibName = SDL.NativeLibName;

	public const string SDL_PROP_SURFACE_SDR_WHITE_POINT_FLOAT = "SDL.surface.SDR_white_point";
	public const string SDL_PROP_SURFACE_HDR_HEADROOM_FLOAT = "SDL.surface.HDR_headroom";
	public const string SDL_PROP_SURFACE_TONEMAP_OPERATOR_STRING = "SDL.surface.tonemap";
	public const string SDL_PROP_SURFACE_HOTSPOT_X_NUMBER = "SDL.surface.hotspot.x";
	public const string SDL_PROP_SURFACE_HOTSPOT_Y_NUMBER = "SDL.surface.hotspot.y";

	[Flags]
	public enum SDL_SurfaceFlags : uint
	{
		SDL_SURFACE_PREALLOCATED = 0x1,
		SDL_SURFACE_LOCK_NEEDED = 0x2,
		SDL_SURFACE_LOCKED = 0x4,
		SDL_SURFACE_SIMD_ALIGNED = 0x08,
	}

	public enum SDL_ScaleMode
	{
		SDL_SCALEMODE_NEAREST = 0,
		SDL_SCALEMODE_LINEAR = 1,
	}

	public enum SDL_FlipMode
	{
		SDL_FLIP_NONE = 0,
		SDL_FLIP_HORIZONTAL = 1,
		SDL_FLIP_VERTICAL = 2,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_Surface
	{
		public SDL_SurfaceFlags flags;
		public SdlPixels.SDL_PixelFormat format;
		public int w;
		public int h;
		public int pitch;
		public IntPtr pixels;
		public int refcount;
		public IntPtr reserved;
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* SDL_CreateSurface(int width, int height, SdlPixels.SDL_PixelFormat format);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* SDL_CreateSurfaceFrom(int width, int height, SdlPixels.SDL_PixelFormat format, IntPtr pixels, int pitch);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DestroySurface(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetSurfaceProperties(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetSurfaceColorspace(IntPtr surface, SdlPixels.SDL_Colorspace colorspace);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlPixels.SDL_Colorspace SDL_GetSurfaceColorspace(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlPixels.SDL_Palette* SDL_CreateSurfacePalette(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetSurfacePalette(IntPtr surface, IntPtr palette);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlPixels.SDL_Palette* SDL_GetSurfacePalette(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_AddSurfaceAlternateImage(IntPtr surface, IntPtr image);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SurfaceHasAlternateImages(IntPtr surface);

	public static Span<IntPtr> SDL_GetSurfaceImages(IntPtr surface)
	{
		var result = SDL_GetSurfaceImages(surface, out var count);
		return new Span<IntPtr>((void*) result, count);
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetSurfaceImages(IntPtr surface, out int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_RemoveSurfaceAlternateImages(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_LockSurface(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_UnlockSurface(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* SDL_LoadBMP_IO(IntPtr src, SDLBool closeio);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* SDL_LoadBMP(string file);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SaveBMP_IO(IntPtr surface, IntPtr dst, SDLBool closeio);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SaveBMP(IntPtr surface, string file);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetSurfaceRLE(IntPtr surface, SDLBool enabled);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SurfaceHasRLE(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetSurfaceColorKey(IntPtr surface, SDLBool enabled, uint key);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SurfaceHasColorKey(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetSurfaceColorKey(IntPtr surface, out uint key);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetSurfaceColorMod(IntPtr surface, byte r, byte g, byte b);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetSurfaceColorMod(IntPtr surface, out byte r, out byte g, out byte b);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetSurfaceAlphaMod(IntPtr surface, byte alpha);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetSurfaceAlphaMod(IntPtr surface, out byte alpha);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetSurfaceBlendMode(IntPtr surface, uint blendMode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetSurfaceBlendMode(IntPtr surface, IntPtr blendMode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetSurfaceClipRect(IntPtr surface, ref SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetSurfaceClipRect(IntPtr surface, out SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_FlipSurface(IntPtr surface, SDL_FlipMode flip);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* SDL_DuplicateSurface(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* SDL_ScaleSurface(IntPtr surface, int width, int height, SDL_ScaleMode scaleMode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* SDL_ConvertSurface(IntPtr surface, SdlPixels.SDL_PixelFormat format);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Surface* SDL_ConvertSurfaceAndColorspace(IntPtr surface, SdlPixels.SDL_PixelFormat format, IntPtr palette, SdlPixels.SDL_Colorspace colorspace, uint props);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ConvertPixels(int width, int height, SdlPixels.SDL_PixelFormat src_format, IntPtr src, int src_pitch, SdlPixels.SDL_PixelFormat dst_format, IntPtr dst, int dst_pitch);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ConvertPixelsAndColorspace(int width, int height, SdlPixels.SDL_PixelFormat src_format, SdlPixels.SDL_Colorspace src_colorspace, uint src_properties, IntPtr src, int src_pitch, SdlPixels.SDL_PixelFormat dst_format, SdlPixels.SDL_Colorspace dst_colorspace, uint dst_properties, IntPtr dst, int dst_pitch);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_PremultiplyAlpha(int width, int height, SdlPixels.SDL_PixelFormat src_format, IntPtr src, int src_pitch, SdlPixels.SDL_PixelFormat dst_format, IntPtr dst, int dst_pitch, SDLBool linear);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_PremultiplySurfaceAlpha(IntPtr surface, SDLBool linear);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ClearSurface(IntPtr surface, float r, float g, float b, float a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_FillSurfaceRect(IntPtr dst, IntPtr rect, uint color); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_FillSurfaceRects(IntPtr dst, Span<SdlRect.SDL_Rect> rects, int count, uint color);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_BlitSurface(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_BlitSurfaceUnchecked(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_BlitSurfaceScaled(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect, SDL_ScaleMode scaleMode); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_BlitSurfaceUncheckedScaled(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect, SDL_ScaleMode scaleMode); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_BlitSurfaceTiled(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_BlitSurfaceTiledWithScale(IntPtr src, IntPtr srcrect, float scale, SDL_ScaleMode scaleMode, IntPtr dst, IntPtr dstrect); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_BlitSurface9Grid(IntPtr src, IntPtr srcrect, int left_width, int right_width, int top_height, int bottom_height, float scale, SDL_ScaleMode scaleMode, IntPtr dst, IntPtr dstrect); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_MapSurfaceRGB(IntPtr surface, byte r, byte g, byte b);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_MapSurfaceRGBA(IntPtr surface, byte r, byte g, byte b, byte a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ReadSurfacePixel(IntPtr surface, int x, int y, out byte r, out byte g, out byte b, out byte a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ReadSurfacePixelFloat(IntPtr surface, int x, int y, out float r, out float g, out float b, out float a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_WriteSurfacePixel(IntPtr surface, int x, int y, byte r, byte g, byte b, byte a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_WriteSurfacePixelFloat(IntPtr surface, int x, int y, float r, float g, float b, float a);

}
