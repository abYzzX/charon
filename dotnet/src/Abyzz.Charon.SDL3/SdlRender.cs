using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlRender
{
    private const string NativeLibName = SDL.NativeLibName;

	public const string SDL_PROP_RENDERER_CREATE_NAME_STRING = "SDL.renderer.create.name";
	public const string SDL_PROP_RENDERER_CREATE_WINDOW_POINTER = "SDL.renderer.create.window";
	public const string SDL_PROP_RENDERER_CREATE_SURFACE_POINTER = "SDL.renderer.create.surface";
	public const string SDL_PROP_RENDERER_CREATE_OUTPUT_COLORSPACE_NUMBER = "SDL.renderer.create.output_colorspace";
	public const string SDL_PROP_RENDERER_CREATE_PRESENT_VSYNC_NUMBER = "SDL.renderer.create.present_vsync";
	public const string SDL_PROP_RENDERER_CREATE_VULKAN_INSTANCE_POINTER = "SDL.renderer.create.vulkan.instance";
	public const string SDL_PROP_RENDERER_CREATE_VULKAN_SURFACE_NUMBER = "SDL.renderer.create.vulkan.surface";
	public const string SDL_PROP_RENDERER_CREATE_VULKAN_PHYSICAL_DEVICE_POINTER = "SDL.renderer.create.vulkan.physical_device";
	public const string SDL_PROP_RENDERER_CREATE_VULKAN_DEVICE_POINTER = "SDL.renderer.create.vulkan.device";
	public const string SDL_PROP_RENDERER_CREATE_VULKAN_GRAPHICS_QUEUE_FAMILY_INDEX_NUMBER = "SDL.renderer.create.vulkan.graphics_queue_family_index";
	public const string SDL_PROP_RENDERER_CREATE_VULKAN_PRESENT_QUEUE_FAMILY_INDEX_NUMBER = "SDL.renderer.create.vulkan.present_queue_family_index";
	public const string SDL_PROP_RENDERER_NAME_STRING = "SDL.renderer.name";
	public const string SDL_PROP_RENDERER_WINDOW_POINTER = "SDL.renderer.window";
	public const string SDL_PROP_RENDERER_SURFACE_POINTER = "SDL.renderer.surface";
	public const string SDL_PROP_RENDERER_VSYNC_NUMBER = "SDL.renderer.vsync";
	public const string SDL_PROP_RENDERER_MAX_TEXTURE_SIZE_NUMBER = "SDL.renderer.max_texture_size";
	public const string SDL_PROP_RENDERER_TEXTURE_FORMATS_POINTER = "SDL.renderer.texture_formats";
	public const string SDL_PROP_RENDERER_OUTPUT_COLORSPACE_NUMBER = "SDL.renderer.output_colorspace";
	public const string SDL_PROP_RENDERER_HDR_ENABLED_BOOLEAN = "SDL.renderer.HDR_enabled";
	public const string SDL_PROP_RENDERER_SDR_WHITE_POINT_FLOAT = "SDL.renderer.SDR_white_point";
	public const string SDL_PROP_RENDERER_HDR_HEADROOM_FLOAT = "SDL.renderer.HDR_headroom";
	public const string SDL_PROP_RENDERER_D3D9_DEVICE_POINTER = "SDL.renderer.d3d9.device";
	public const string SDL_PROP_RENDERER_D3D11_DEVICE_POINTER = "SDL.renderer.d3d11.device";
	public const string SDL_PROP_RENDERER_D3D11_SWAPCHAIN_POINTER = "SDL.renderer.d3d11.swap_chain";
	public const string SDL_PROP_RENDERER_D3D12_DEVICE_POINTER = "SDL.renderer.d3d12.device";
	public const string SDL_PROP_RENDERER_D3D12_SWAPCHAIN_POINTER = "SDL.renderer.d3d12.swap_chain";
	public const string SDL_PROP_RENDERER_D3D12_COMMAND_QUEUE_POINTER = "SDL.renderer.d3d12.command_queue";
	public const string SDL_PROP_RENDERER_VULKAN_INSTANCE_POINTER = "SDL.renderer.vulkan.instance";
	public const string SDL_PROP_RENDERER_VULKAN_SURFACE_NUMBER = "SDL.renderer.vulkan.surface";
	public const string SDL_PROP_RENDERER_VULKAN_PHYSICAL_DEVICE_POINTER = "SDL.renderer.vulkan.physical_device";
	public const string SDL_PROP_RENDERER_VULKAN_DEVICE_POINTER = "SDL.renderer.vulkan.device";
	public const string SDL_PROP_RENDERER_VULKAN_GRAPHICS_QUEUE_FAMILY_INDEX_NUMBER = "SDL.renderer.vulkan.graphics_queue_family_index";
	public const string SDL_PROP_RENDERER_VULKAN_PRESENT_QUEUE_FAMILY_INDEX_NUMBER = "SDL.renderer.vulkan.present_queue_family_index";
	public const string SDL_PROP_RENDERER_VULKAN_SWAPCHAIN_IMAGE_COUNT_NUMBER = "SDL.renderer.vulkan.swapchain_image_count";
	public const string SDL_PROP_RENDERER_GPU_DEVICE_POINTER = "SDL.renderer.gpu.device";
	public const string SDL_PROP_TEXTURE_CREATE_COLORSPACE_NUMBER = "SDL.texture.create.colorspace";
	public const string SDL_PROP_TEXTURE_CREATE_FORMAT_NUMBER = "SDL.texture.create.format";
	public const string SDL_PROP_TEXTURE_CREATE_ACCESS_NUMBER = "SDL.texture.create.access";
	public const string SDL_PROP_TEXTURE_CREATE_WIDTH_NUMBER = "SDL.texture.create.width";
	public const string SDL_PROP_TEXTURE_CREATE_HEIGHT_NUMBER = "SDL.texture.create.height";
	public const string SDL_PROP_TEXTURE_CREATE_SDR_WHITE_POINT_FLOAT = "SDL.texture.create.SDR_white_point";
	public const string SDL_PROP_TEXTURE_CREATE_HDR_HEADROOM_FLOAT = "SDL.texture.create.HDR_headroom";
	public const string SDL_PROP_TEXTURE_CREATE_D3D11_TEXTURE_POINTER = "SDL.texture.create.d3d11.texture";
	public const string SDL_PROP_TEXTURE_CREATE_D3D11_TEXTURE_U_POINTER = "SDL.texture.create.d3d11.texture_u";
	public const string SDL_PROP_TEXTURE_CREATE_D3D11_TEXTURE_V_POINTER = "SDL.texture.create.d3d11.texture_v";
	public const string SDL_PROP_TEXTURE_CREATE_D3D12_TEXTURE_POINTER = "SDL.texture.create.d3d12.texture";
	public const string SDL_PROP_TEXTURE_CREATE_D3D12_TEXTURE_U_POINTER = "SDL.texture.create.d3d12.texture_u";
	public const string SDL_PROP_TEXTURE_CREATE_D3D12_TEXTURE_V_POINTER = "SDL.texture.create.d3d12.texture_v";
	public const string SDL_PROP_TEXTURE_CREATE_METAL_PIXELBUFFER_POINTER = "SDL.texture.create.metal.pixelbuffer";
	public const string SDL_PROP_TEXTURE_CREATE_OPENGL_TEXTURE_NUMBER = "SDL.texture.create.opengl.texture";
	public const string SDL_PROP_TEXTURE_CREATE_OPENGL_TEXTURE_UV_NUMBER = "SDL.texture.create.opengl.texture_uv";
	public const string SDL_PROP_TEXTURE_CREATE_OPENGL_TEXTURE_U_NUMBER = "SDL.texture.create.opengl.texture_u";
	public const string SDL_PROP_TEXTURE_CREATE_OPENGL_TEXTURE_V_NUMBER = "SDL.texture.create.opengl.texture_v";
	public const string SDL_PROP_TEXTURE_CREATE_OPENGLES2_TEXTURE_NUMBER = "SDL.texture.create.opengles2.texture";
	public const string SDL_PROP_TEXTURE_CREATE_OPENGLES2_TEXTURE_UV_NUMBER = "SDL.texture.create.opengles2.texture_uv";
	public const string SDL_PROP_TEXTURE_CREATE_OPENGLES2_TEXTURE_U_NUMBER = "SDL.texture.create.opengles2.texture_u";
	public const string SDL_PROP_TEXTURE_CREATE_OPENGLES2_TEXTURE_V_NUMBER = "SDL.texture.create.opengles2.texture_v";
	public const string SDL_PROP_TEXTURE_CREATE_VULKAN_TEXTURE_NUMBER = "SDL.texture.create.vulkan.texture";
	public const string SDL_PROP_TEXTURE_COLORSPACE_NUMBER = "SDL.texture.colorspace";
	public const string SDL_PROP_TEXTURE_FORMAT_NUMBER = "SDL.texture.format";
	public const string SDL_PROP_TEXTURE_ACCESS_NUMBER = "SDL.texture.access";
	public const string SDL_PROP_TEXTURE_WIDTH_NUMBER = "SDL.texture.width";
	public const string SDL_PROP_TEXTURE_HEIGHT_NUMBER = "SDL.texture.height";
	public const string SDL_PROP_TEXTURE_SDR_WHITE_POINT_FLOAT = "SDL.texture.SDR_white_point";
	public const string SDL_PROP_TEXTURE_HDR_HEADROOM_FLOAT = "SDL.texture.HDR_headroom";
	public const string SDL_PROP_TEXTURE_D3D11_TEXTURE_POINTER = "SDL.texture.d3d11.texture";
	public const string SDL_PROP_TEXTURE_D3D11_TEXTURE_U_POINTER = "SDL.texture.d3d11.texture_u";
	public const string SDL_PROP_TEXTURE_D3D11_TEXTURE_V_POINTER = "SDL.texture.d3d11.texture_v";
	public const string SDL_PROP_TEXTURE_D3D12_TEXTURE_POINTER = "SDL.texture.d3d12.texture";
	public const string SDL_PROP_TEXTURE_D3D12_TEXTURE_U_POINTER = "SDL.texture.d3d12.texture_u";
	public const string SDL_PROP_TEXTURE_D3D12_TEXTURE_V_POINTER = "SDL.texture.d3d12.texture_v";
	public const string SDL_PROP_TEXTURE_OPENGL_TEXTURE_NUMBER = "SDL.texture.opengl.texture";
	public const string SDL_PROP_TEXTURE_OPENGL_TEXTURE_UV_NUMBER = "SDL.texture.opengl.texture_uv";
	public const string SDL_PROP_TEXTURE_OPENGL_TEXTURE_U_NUMBER = "SDL.texture.opengl.texture_u";
	public const string SDL_PROP_TEXTURE_OPENGL_TEXTURE_V_NUMBER = "SDL.texture.opengl.texture_v";
	public const string SDL_PROP_TEXTURE_OPENGL_TEXTURE_TARGET_NUMBER = "SDL.texture.opengl.target";
	public const string SDL_PROP_TEXTURE_OPENGL_TEX_W_FLOAT = "SDL.texture.opengl.tex_w";
	public const string SDL_PROP_TEXTURE_OPENGL_TEX_H_FLOAT = "SDL.texture.opengl.tex_h";
	public const string SDL_PROP_TEXTURE_OPENGLES2_TEXTURE_NUMBER = "SDL.texture.opengles2.texture";
	public const string SDL_PROP_TEXTURE_OPENGLES2_TEXTURE_UV_NUMBER = "SDL.texture.opengles2.texture_uv";
	public const string SDL_PROP_TEXTURE_OPENGLES2_TEXTURE_U_NUMBER = "SDL.texture.opengles2.texture_u";
	public const string SDL_PROP_TEXTURE_OPENGLES2_TEXTURE_V_NUMBER = "SDL.texture.opengles2.texture_v";
	public const string SDL_PROP_TEXTURE_OPENGLES2_TEXTURE_TARGET_NUMBER = "SDL.texture.opengles2.target";
	public const string SDL_PROP_TEXTURE_VULKAN_TEXTURE_NUMBER = "SDL.texture.vulkan.texture";

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_Vertex
	{
		public SdlRect.SDL_FPoint position;
		public SdlPixels.SDL_FColor color;
		public SdlRect.SDL_FPoint tex_coord;
	}

	public enum SDL_TextureAccess
	{
		SDL_TEXTUREACCESS_STATIC = 0,
		SDL_TEXTUREACCESS_STREAMING = 1,
		SDL_TEXTUREACCESS_TARGET = 2,
	}

	public enum SDL_RendererLogicalPresentation
	{
		SDL_LOGICAL_PRESENTATION_DISABLED = 0,
		SDL_LOGICAL_PRESENTATION_STRETCH = 1,
		SDL_LOGICAL_PRESENTATION_LETTERBOX = 2,
		SDL_LOGICAL_PRESENTATION_OVERSCAN = 3,
		SDL_LOGICAL_PRESENTATION_INTEGER_SCALE = 4,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_Texture
	{
		public SdlPixels.SDL_PixelFormat format;
		public int w;
		public int h;
		public int refcount;
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetNumRenderDrivers();

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetRenderDriver(int index);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_CreateWindowAndRenderer(string title, int width, int height, SdlVideo.SDL_WindowFlags window_flags, out IntPtr window, out IntPtr renderer);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateRenderer(IntPtr window, string name);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateRendererWithProperties(uint props);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateSoftwareRenderer(IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetRenderer(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetRenderWindow(IntPtr renderer);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetRendererName(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetRendererProperties(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderOutputSize(IntPtr renderer, out int w, out int h);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetCurrentRenderOutputSize(IntPtr renderer, out int w, out int h);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Texture* SDL_CreateTexture(IntPtr renderer, SdlPixels.SDL_PixelFormat format, SDL_TextureAccess access, int w, int h);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Texture* SDL_CreateTextureFromSurface(IntPtr renderer, IntPtr surface);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Texture* SDL_CreateTextureWithProperties(IntPtr renderer, uint props);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetTextureProperties(IntPtr texture); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetRendererFromTexture(IntPtr texture); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetTextureSize(IntPtr texture, out float w, out float h); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetTextureColorMod(IntPtr texture, byte r, byte g, byte b); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetTextureColorModFloat(IntPtr texture, float r, float g, float b); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetTextureColorMod(IntPtr texture, out byte r, out byte g, out byte b); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetTextureColorModFloat(IntPtr texture, out float r, out float g, out float b); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetTextureAlphaMod(IntPtr texture, byte alpha); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetTextureAlphaModFloat(IntPtr texture, float alpha); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetTextureAlphaMod(IntPtr texture, out byte alpha); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetTextureAlphaModFloat(IntPtr texture, out float alpha); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetTextureBlendMode(IntPtr texture, uint blendMode); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetTextureBlendMode(IntPtr texture, IntPtr blendMode); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetTextureScaleMode(IntPtr texture, SdlSurface.SDL_ScaleMode scaleMode); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetTextureScaleMode(IntPtr texture, out SdlSurface.SDL_ScaleMode scaleMode); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_UpdateTexture(IntPtr texture, ref SdlRect.SDL_Rect rect, IntPtr pixels, int pitch); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_UpdateYUVTexture(IntPtr texture, ref SdlRect.SDL_Rect rect, IntPtr Yplane, int Ypitch, IntPtr Uplane, int Upitch, IntPtr Vplane, int Vpitch); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_UpdateNVTexture(IntPtr texture, ref SdlRect.SDL_Rect rect, IntPtr Yplane, int Ypitch, IntPtr UVplane, int UVpitch); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_LockTexture(IntPtr texture, ref SdlRect.SDL_Rect rect, out IntPtr pixels, out int pitch); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_LockTextureToSurface(IntPtr texture, ref SdlRect.SDL_Rect rect, out IntPtr surface); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_UnlockTexture(IntPtr texture); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetRenderTarget(IntPtr renderer, IntPtr texture); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_Texture* SDL_GetRenderTarget(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetRenderLogicalPresentation(IntPtr renderer, int w, int h, SDL_RendererLogicalPresentation mode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderLogicalPresentation(IntPtr renderer, out int w, out int h, out SDL_RendererLogicalPresentation mode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderLogicalPresentationRect(IntPtr renderer, out SdlRect.SDL_FRect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderCoordinatesFromWindow(IntPtr renderer, float window_x, float window_y, out float x, out float y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderCoordinatesToWindow(IntPtr renderer, float x, float y, out float window_x, out float window_y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ConvertEventToRenderCoordinates(IntPtr renderer, ref SdlEvents.SDL_Event @event);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetRenderViewport(IntPtr renderer, ref SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderViewport(IntPtr renderer, out SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderViewportSet(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderSafeArea(IntPtr renderer, out SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetRenderClipRect(IntPtr renderer, ref SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderClipRect(IntPtr renderer, out SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderClipEnabled(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetRenderScale(IntPtr renderer, float scaleX, float scaleY);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderScale(IntPtr renderer, out float scaleX, out float scaleY);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetRenderDrawColorFloat(IntPtr renderer, float r, float g, float b, float a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderDrawColorFloat(IntPtr renderer, out float r, out float g, out float b, out float a);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetRenderColorScale(IntPtr renderer, float scale);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderColorScale(IntPtr renderer, out float scale);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetRenderDrawBlendMode(IntPtr renderer, uint blendMode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderDrawBlendMode(IntPtr renderer, IntPtr blendMode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderClear(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderPoint(IntPtr renderer, float x, float y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderPoints(IntPtr renderer, Span<SdlRect.SDL_FPoint> points, int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderLine(IntPtr renderer, float x1, float y1, float x2, float y2);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderLines(IntPtr renderer, Span<SdlRect.SDL_FPoint> points, int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderRect(IntPtr renderer, ref SdlRect.SDL_FRect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderRects(IntPtr renderer, Span<SdlRect.SDL_FRect> rects, int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderFillRect(IntPtr renderer, ref SdlRect.SDL_FRect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderFillRects(IntPtr renderer, Span<SdlRect.SDL_FRect> rects, int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderTexture(IntPtr renderer, IntPtr texture, ref SdlRect.SDL_FRect srcrect, ref SdlRect.SDL_FRect dstrect); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderTextureRotated(IntPtr renderer, IntPtr texture, ref SdlRect.SDL_FRect srcrect, ref SdlRect.SDL_FRect dstrect, double angle, ref SdlRect.SDL_FPoint center, SdlSurface.SDL_FlipMode flip); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderTextureAffine(IntPtr renderer, IntPtr texture, in SdlRect.SDL_FRect srcrect, in SdlRect.SDL_FPoint origin, in SdlRect.SDL_FPoint right, in SdlRect.SDL_FPoint down);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderTextureTiled(IntPtr renderer, IntPtr texture, ref SdlRect.SDL_FRect srcrect, float scale, ref SdlRect.SDL_FRect dstrect); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderTexture9Grid(IntPtr renderer, IntPtr texture, ref SdlRect.SDL_FRect srcrect, float left_width, float right_width, float top_height, float bottom_height, float scale, ref SdlRect.SDL_FRect dstrect); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderGeometry(IntPtr renderer, IntPtr texture, Span<SDL_Vertex> vertices, int num_vertices, Span<int> indices, int num_indices); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderGeometryRaw(IntPtr renderer, IntPtr texture, IntPtr xy, int xy_stride, IntPtr color, int color_stride, IntPtr uv, int uv_stride, int num_vertices, IntPtr indices, int num_indices, int size_indices); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlSurface.SDL_Surface* SDL_RenderReadPixels(IntPtr renderer, ref SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderPresent(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DestroyTexture(IntPtr texture); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DestroyRenderer(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_FlushRenderer(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetRenderMetalLayer(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetRenderMetalCommandEncoder(IntPtr renderer);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_AddVulkanRenderSemaphores(IntPtr renderer, uint wait_stage_mask, long wait_semaphore, long signal_semaphore);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetRenderVSync(IntPtr renderer, int vsync);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetRenderVSync(IntPtr renderer, out int vsync);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderDebugText(IntPtr renderer, float x, float y, string str);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RenderDebugTextFormat(IntPtr renderer, float x, float y, string fmt);

}
