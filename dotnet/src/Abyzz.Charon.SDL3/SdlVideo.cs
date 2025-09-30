using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlVideo
{
    private const string NativeLibName = SDL.NativeLibName;

	public const string SDL_PROP_GLOBAL_VIDEO_WAYLAND_WL_DISPLAY_POINTER = "SDL.video.wayland.wl_display";
	public const string SDL_PROP_DISPLAY_HDR_ENABLED_BOOLEAN = "SDL.display.HDR_enabled";
	public const string SDL_PROP_DISPLAY_KMSDRM_PANEL_ORIENTATION_NUMBER = "SDL.display.KMSDRM.panel_orientation";
	public const string SDL_PROP_WINDOW_CREATE_ALWAYS_ON_TOP_BOOLEAN = "SDL.window.create.always_on_top";
	public const string SDL_PROP_WINDOW_CREATE_BORDERLESS_BOOLEAN = "SDL.window.create.borderless";
	public const string SDL_PROP_WINDOW_CREATE_FOCUSABLE_BOOLEAN = "SDL.window.create.focusable";
	public const string SDL_PROP_WINDOW_CREATE_EXTERNAL_GRAPHICS_CONTEXT_BOOLEAN = "SDL.window.create.external_graphics_context";
	public const string SDL_PROP_WINDOW_CREATE_FLAGS_NUMBER = "SDL.window.create.flags";
	public const string SDL_PROP_WINDOW_CREATE_FULLSCREEN_BOOLEAN = "SDL.window.create.fullscreen";
	public const string SDL_PROP_WINDOW_CREATE_HEIGHT_NUMBER = "SDL.window.create.height";
	public const string SDL_PROP_WINDOW_CREATE_HIDDEN_BOOLEAN = "SDL.window.create.hidden";
	public const string SDL_PROP_WINDOW_CREATE_HIGH_PIXEL_DENSITY_BOOLEAN = "SDL.window.create.high_pixel_density";
	public const string SDL_PROP_WINDOW_CREATE_MAXIMIZED_BOOLEAN = "SDL.window.create.maximized";
	public const string SDL_PROP_WINDOW_CREATE_MENU_BOOLEAN = "SDL.window.create.menu";
	public const string SDL_PROP_WINDOW_CREATE_METAL_BOOLEAN = "SDL.window.create.metal";
	public const string SDL_PROP_WINDOW_CREATE_MINIMIZED_BOOLEAN = "SDL.window.create.minimized";
	public const string SDL_PROP_WINDOW_CREATE_MODAL_BOOLEAN = "SDL.window.create.modal";
	public const string SDL_PROP_WINDOW_CREATE_MOUSE_GRABBED_BOOLEAN = "SDL.window.create.mouse_grabbed";
	public const string SDL_PROP_WINDOW_CREATE_OPENGL_BOOLEAN = "SDL.window.create.opengl";
	public const string SDL_PROP_WINDOW_CREATE_PARENT_POINTER = "SDL.window.create.parent";
	public const string SDL_PROP_WINDOW_CREATE_RESIZABLE_BOOLEAN = "SDL.window.create.resizable";
	public const string SDL_PROP_WINDOW_CREATE_TITLE_STRING = "SDL.window.create.title";
	public const string SDL_PROP_WINDOW_CREATE_TRANSPARENT_BOOLEAN = "SDL.window.create.transparent";
	public const string SDL_PROP_WINDOW_CREATE_TOOLTIP_BOOLEAN = "SDL.window.create.tooltip";
	public const string SDL_PROP_WINDOW_CREATE_UTILITY_BOOLEAN = "SDL.window.create.utility";
	public const string SDL_PROP_WINDOW_CREATE_VULKAN_BOOLEAN = "SDL.window.create.vulkan";
	public const string SDL_PROP_WINDOW_CREATE_WIDTH_NUMBER = "SDL.window.create.width";
	public const string SDL_PROP_WINDOW_CREATE_X_NUMBER = "SDL.window.create.x";
	public const string SDL_PROP_WINDOW_CREATE_Y_NUMBER = "SDL.window.create.y";
	public const string SDL_PROP_WINDOW_CREATE_COCOA_WINDOW_POINTER = "SDL.window.create.cocoa.window";
	public const string SDL_PROP_WINDOW_CREATE_COCOA_VIEW_POINTER = "SDL.window.create.cocoa.view";
	public const string SDL_PROP_WINDOW_CREATE_WAYLAND_SURFACE_ROLE_CUSTOM_BOOLEAN = "SDL.window.create.wayland.surface_role_custom";
	public const string SDL_PROP_WINDOW_CREATE_WAYLAND_CREATE_EGL_WINDOW_BOOLEAN = "SDL.window.create.wayland.create_egl_window";
	public const string SDL_PROP_WINDOW_CREATE_WAYLAND_WL_SURFACE_POINTER = "SDL.window.create.wayland.wl_surface";
	public const string SDL_PROP_WINDOW_CREATE_WIN32_HWND_POINTER = "SDL.window.create.win32.hwnd";
	public const string SDL_PROP_WINDOW_CREATE_WIN32_PIXEL_FORMAT_HWND_POINTER = "SDL.window.create.win32.pixel_format_hwnd";
	public const string SDL_PROP_WINDOW_CREATE_X11_WINDOW_NUMBER = "SDL.window.create.x11.window";
	public const string SDL_PROP_WINDOW_SHAPE_POINTER = "SDL.window.shape";
	public const string SDL_PROP_WINDOW_HDR_ENABLED_BOOLEAN = "SDL.window.HDR_enabled";
	public const string SDL_PROP_WINDOW_SDR_WHITE_LEVEL_FLOAT = "SDL.window.SDR_white_level";
	public const string SDL_PROP_WINDOW_HDR_HEADROOM_FLOAT = "SDL.window.HDR_headroom";
	public const string SDL_PROP_WINDOW_ANDROID_WINDOW_POINTER = "SDL.window.android.window";
	public const string SDL_PROP_WINDOW_ANDROID_SURFACE_POINTER = "SDL.window.android.surface";
	public const string SDL_PROP_WINDOW_UIKIT_WINDOW_POINTER = "SDL.window.uikit.window";
	public const string SDL_PROP_WINDOW_UIKIT_METAL_VIEW_TAG_NUMBER = "SDL.window.uikit.metal_view_tag";
	public const string SDL_PROP_WINDOW_UIKIT_OPENGL_FRAMEBUFFER_NUMBER = "SDL.window.uikit.opengl.framebuffer";
	public const string SDL_PROP_WINDOW_UIKIT_OPENGL_RENDERBUFFER_NUMBER = "SDL.window.uikit.opengl.renderbuffer";
	public const string SDL_PROP_WINDOW_UIKIT_OPENGL_RESOLVE_FRAMEBUFFER_NUMBER = "SDL.window.uikit.opengl.resolve_framebuffer";
	public const string SDL_PROP_WINDOW_KMSDRM_DEVICE_INDEX_NUMBER = "SDL.window.kmsdrm.dev_index";
	public const string SDL_PROP_WINDOW_KMSDRM_DRM_FD_NUMBER = "SDL.window.kmsdrm.drm_fd";
	public const string SDL_PROP_WINDOW_KMSDRM_GBM_DEVICE_POINTER = "SDL.window.kmsdrm.gbm_dev";
	public const string SDL_PROP_WINDOW_COCOA_WINDOW_POINTER = "SDL.window.cocoa.window";
	public const string SDL_PROP_WINDOW_COCOA_METAL_VIEW_TAG_NUMBER = "SDL.window.cocoa.metal_view_tag";
	public const string SDL_PROP_WINDOW_OPENVR_OVERLAY_ID = "SDL.window.openvr.overlay_id";
	public const string SDL_PROP_WINDOW_VIVANTE_DISPLAY_POINTER = "SDL.window.vivante.display";
	public const string SDL_PROP_WINDOW_VIVANTE_WINDOW_POINTER = "SDL.window.vivante.window";
	public const string SDL_PROP_WINDOW_VIVANTE_SURFACE_POINTER = "SDL.window.vivante.surface";
	public const string SDL_PROP_WINDOW_WIN32_HWND_POINTER = "SDL.window.win32.hwnd";
	public const string SDL_PROP_WINDOW_WIN32_HDC_POINTER = "SDL.window.win32.hdc";
	public const string SDL_PROP_WINDOW_WIN32_INSTANCE_POINTER = "SDL.window.win32.instance";
	public const string SDL_PROP_WINDOW_WAYLAND_DISPLAY_POINTER = "SDL.window.wayland.display";
	public const string SDL_PROP_WINDOW_WAYLAND_SURFACE_POINTER = "SDL.window.wayland.surface";
	public const string SDL_PROP_WINDOW_WAYLAND_VIEWPORT_POINTER = "SDL.window.wayland.viewport";
	public const string SDL_PROP_WINDOW_WAYLAND_EGL_WINDOW_POINTER = "SDL.window.wayland.egl_window";
	public const string SDL_PROP_WINDOW_WAYLAND_XDG_SURFACE_POINTER = "SDL.window.wayland.xdg_surface";
	public const string SDL_PROP_WINDOW_WAYLAND_XDG_TOPLEVEL_POINTER = "SDL.window.wayland.xdg_toplevel";
	public const string SDL_PROP_WINDOW_WAYLAND_XDG_TOPLEVEL_EXPORT_HANDLE_STRING = "SDL.window.wayland.xdg_toplevel_export_handle";
	public const string SDL_PROP_WINDOW_WAYLAND_XDG_POPUP_POINTER = "SDL.window.wayland.xdg_popup";
	public const string SDL_PROP_WINDOW_WAYLAND_XDG_POSITIONER_POINTER = "SDL.window.wayland.xdg_positioner";
	public const string SDL_PROP_WINDOW_X11_DISPLAY_POINTER = "SDL.window.x11.display";
	public const string SDL_PROP_WINDOW_X11_SCREEN_NUMBER = "SDL.window.x11.screen";
	public const string SDL_PROP_WINDOW_X11_WINDOW_NUMBER = "SDL.window.x11.window";

	public enum SDL_SystemTheme
	{
		SDL_SYSTEM_THEME_UNKNOWN = 0,
		SDL_SYSTEM_THEME_LIGHT = 1,
		SDL_SYSTEM_THEME_DARK = 2,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_DisplayMode
	{
		public uint displayID;
		public SdlPixels.SDL_PixelFormat format;
		public int w;
		public int h;
		public float pixel_density;
		public float refresh_rate;
		public int refresh_rate_numerator;
		public int refresh_rate_denominator;
		public IntPtr @internal;
	}

	public enum SDL_DisplayOrientation
	{
		SDL_ORIENTATION_UNKNOWN = 0,
		SDL_ORIENTATION_LANDSCAPE = 1,
		SDL_ORIENTATION_LANDSCAPE_FLIPPED = 2,
		SDL_ORIENTATION_PORTRAIT = 3,
		SDL_ORIENTATION_PORTRAIT_FLIPPED = 4,
	}

	[Flags]
	public enum SDL_WindowFlags : ulong
	{
		SDL_WINDOW_FULLSCREEN = 0x1,
		SDL_WINDOW_OPENGL = 0x2,
		SDL_WINDOW_OCCLUDED = 0x4,
		SDL_WINDOW_HIDDEN = 0x08,
		SDL_WINDOW_BORDERLESS = 0x10,
		SDL_WINDOW_RESIZABLE = 0x20,
		SDL_WINDOW_MINIMIZED = 0x40,
		SDL_WINDOW_MAXIMIZED = 0x080,
		SDL_WINDOW_MOUSE_GRABBED = 0x100,
		SDL_WINDOW_INPUT_FOCUS = 0x200,
		SDL_WINDOW_MOUSE_FOCUS = 0x400,
		SDL_WINDOW_EXTERNAL = 0x0800,
		SDL_WINDOW_MODAL = 0x1000,
		SDL_WINDOW_HIGH_PIXEL_DENSITY = 0x2000,
		SDL_WINDOW_MOUSE_CAPTURE = 0x4000,
		SDL_WINDOW_MOUSE_RELATIVE_MODE = 0x08000,
		SDL_WINDOW_ALWAYS_ON_TOP = 0x10000,
		SDL_WINDOW_UTILITY = 0x20000,
		SDL_WINDOW_TOOLTIP = 0x40000,
		SDL_WINDOW_POPUP_MENU = 0x080000,
		SDL_WINDOW_KEYBOARD_GRABBED = 0x100000,
		SDL_WINDOW_VULKAN = 0x10000000,
		SDL_WINDOW_METAL = 0x20000000,
		SDL_WINDOW_TRANSPARENT = 0x40000000,
		SDL_WINDOW_NOT_FOCUSABLE = 0x080000000,
	}

	public enum SDL_FlashOperation
	{
		SDL_FLASH_CANCEL = 0,
		SDL_FLASH_BRIEFLY = 1,
		SDL_FLASH_UNTIL_FOCUSED = 2,
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr SDL_EGLAttribArrayCallback();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr SDL_EGLIntArrayCallback();

	public enum SDL_GLAttr
	{
		SDL_GL_RED_SIZE = 0,
		SDL_GL_GREEN_SIZE = 1,
		SDL_GL_BLUE_SIZE = 2,
		SDL_GL_ALPHA_SIZE = 3,
		SDL_GL_BUFFER_SIZE = 4,
		SDL_GL_DOUBLEBUFFER = 5,
		SDL_GL_DEPTH_SIZE = 6,
		SDL_GL_STENCIL_SIZE = 7,
		SDL_GL_ACCUM_RED_SIZE = 8,
		SDL_GL_ACCUM_GREEN_SIZE = 9,
		SDL_GL_ACCUM_BLUE_SIZE = 10,
		SDL_GL_ACCUM_ALPHA_SIZE = 11,
		SDL_GL_STEREO = 12,
		SDL_GL_MULTISAMPLEBUFFERS = 13,
		SDL_GL_MULTISAMPLESAMPLES = 14,
		SDL_GL_ACCELERATED_VISUAL = 15,
		SDL_GL_RETAINED_BACKING = 16,
		SDL_GL_CONTEXT_MAJOR_VERSION = 17,
		SDL_GL_CONTEXT_MINOR_VERSION = 18,
		SDL_GL_CONTEXT_FLAGS = 19,
		SDL_GL_CONTEXT_PROFILE_MASK = 20,
		SDL_GL_SHARE_WITH_CURRENT_CONTEXT = 21,
		SDL_GL_FRAMEBUFFER_SRGB_CAPABLE = 22,
		SDL_GL_CONTEXT_RELEASE_BEHAVIOR = 23,
		SDL_GL_CONTEXT_RESET_NOTIFICATION = 24,
		SDL_GL_CONTEXT_NO_ERROR = 25,
		SDL_GL_FLOATBUFFERS = 26,
		SDL_GL_EGL_PLATFORM = 27,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetNumVideoDrivers();

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetVideoDriver(int index);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetCurrentVideoDriver();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_SystemTheme SDL_GetSystemTheme();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetDisplays(out int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetPrimaryDisplay();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetDisplayProperties(uint displayID);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetDisplayName(uint displayID);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetDisplayBounds(uint displayID, out SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetDisplayUsableBounds(uint displayID, out SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_DisplayOrientation SDL_GetNaturalDisplayOrientation(uint displayID);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_DisplayOrientation SDL_GetCurrentDisplayOrientation(uint displayID);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial float SDL_GetDisplayContentScale(uint displayID);

	public static Span<IntPtr> SDL_GetFullscreenDisplayModes(uint displayID)
	{
		var result = SDL_GetFullscreenDisplayModes(displayID, out var count);
		return new Span<IntPtr>((void*) result, count);
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetFullscreenDisplayModes(uint displayID, out int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetClosestFullscreenDisplayMode(uint displayID, int w, int h, float refresh_rate, SDLBool include_high_density_modes, out SDL_DisplayMode closest);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_DisplayMode* SDL_GetDesktopDisplayMode(uint displayID);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_DisplayMode* SDL_GetCurrentDisplayMode(uint displayID);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetDisplayForPoint(ref SdlRect.SDL_Point point);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetDisplayForRect(ref SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetDisplayForWindow(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial float SDL_GetWindowPixelDensity(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial float SDL_GetWindowDisplayScale(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowFullscreenMode(IntPtr window, ref SDL_DisplayMode mode);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_DisplayMode* SDL_GetWindowFullscreenMode(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetWindowICCProfile(IntPtr window, out UIntPtr size);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlPixels.SDL_PixelFormat SDL_GetWindowPixelFormat(IntPtr window);

	public static Span<IntPtr> SDL_GetWindows()
	{
		var result = SDL_GetWindows(out var count);
		return new Span<IntPtr>((void*) result, count);
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetWindows(out int count);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateWindow(string title, int w, int h, SDL_WindowFlags flags);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreatePopupWindow(IntPtr parent, int offset_x, int offset_y, int w, int h, SDL_WindowFlags flags);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateWindowWithProperties(uint props);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetWindowID(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetWindowFromID(uint id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetWindowParent(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetWindowProperties(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_WindowFlags SDL_GetWindowFlags(IntPtr window);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowTitle(IntPtr window, string title);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetWindowTitle(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowIcon(IntPtr window, IntPtr icon);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowPosition(IntPtr window, int x, int y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowPosition(IntPtr window, out int x, out int y);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowSize(IntPtr window, int w, int h);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowSize(IntPtr window, out int w, out int h);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowSafeArea(IntPtr window, out SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowAspectRatio(IntPtr window, float min_aspect, float max_aspect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowAspectRatio(IntPtr window, out float min_aspect, out float max_aspect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowBordersSize(IntPtr window, out int top, out int left, out int bottom, out int right);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowSizeInPixels(IntPtr window, out int w, out int h);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowMinimumSize(IntPtr window, int min_w, int min_h);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowMinimumSize(IntPtr window, out int w, out int h);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowMaximumSize(IntPtr window, int max_w, int max_h);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowMaximumSize(IntPtr window, out int w, out int h);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowBordered(IntPtr window, SDLBool bordered);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowResizable(IntPtr window, SDLBool resizable);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowAlwaysOnTop(IntPtr window, SDLBool on_top);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ShowWindow(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HideWindow(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RaiseWindow(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_MaximizeWindow(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_MinimizeWindow(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RestoreWindow(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowFullscreen(IntPtr window, SDLBool fullscreen);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SyncWindow(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_WindowHasSurface(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlSurface.SDL_Surface* SDL_GetWindowSurface(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowSurfaceVSync(IntPtr window, int vsync);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowSurfaceVSync(IntPtr window, out int vsync);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_UpdateWindowSurface(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_UpdateWindowSurfaceRects(IntPtr window, Span<SdlRect.SDL_Rect> rects, int numrects);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_DestroyWindowSurface(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowKeyboardGrab(IntPtr window, SDLBool grabbed);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowMouseGrab(IntPtr window, SDLBool grabbed);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowKeyboardGrab(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetWindowMouseGrab(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetGrabbedWindow();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowMouseRect(IntPtr window, ref SdlRect.SDL_Rect rect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlRect.SDL_Rect* SDL_GetWindowMouseRect(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowOpacity(IntPtr window, float opacity);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial float SDL_GetWindowOpacity(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowParent(IntPtr window, IntPtr parent);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowModal(IntPtr window, SDLBool modal);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowFocusable(IntPtr window, SDLBool focusable);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ShowWindowSystemMenu(IntPtr window, int x, int y);

	public enum SDL_HitTestResult
	{
		SDL_HITTEST_NORMAL = 0,
		SDL_HITTEST_DRAGGABLE = 1,
		SDL_HITTEST_RESIZE_TOPLEFT = 2,
		SDL_HITTEST_RESIZE_TOP = 3,
		SDL_HITTEST_RESIZE_TOPRIGHT = 4,
		SDL_HITTEST_RESIZE_RIGHT = 5,
		SDL_HITTEST_RESIZE_BOTTOMRIGHT = 6,
		SDL_HITTEST_RESIZE_BOTTOM = 7,
		SDL_HITTEST_RESIZE_BOTTOMLEFT = 8,
		SDL_HITTEST_RESIZE_LEFT = 9,
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate SDL_HitTestResult SDL_HitTest(IntPtr win, SdlRect.SDL_Point* area, IntPtr data);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowHitTest(IntPtr window, SDL_HitTest callback, IntPtr callback_data);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetWindowShape(IntPtr window, IntPtr shape);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_FlashWindow(IntPtr window, SDL_FlashOperation operation);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DestroyWindow(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ScreenSaverEnabled();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_EnableScreenSaver();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_DisableScreenSaver();

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GL_LoadLibrary(string path);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GL_GetProcAddress(string proc);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_EGL_GetProcAddress(string proc);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_GL_UnloadLibrary();

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GL_ExtensionSupported(string extension);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_GL_ResetAttributes();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GL_SetAttribute(SDL_GLAttr attr, int value);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GL_GetAttribute(SDL_GLAttr attr, out int value);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GL_CreateContext(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GL_MakeCurrent(IntPtr window, IntPtr context);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GL_GetCurrentWindow();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GL_GetCurrentContext();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_EGL_GetCurrentDisplay();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_EGL_GetCurrentConfig();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_EGL_GetWindowSurface(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_EGL_SetAttributeCallbacks(SDL_EGLAttribArrayCallback platformAttribCallback, SDL_EGLIntArrayCallback surfaceAttribCallback, SDL_EGLIntArrayCallback contextAttribCallback, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GL_SetSwapInterval(int interval);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GL_GetSwapInterval(out int interval);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GL_SwapWindow(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GL_DestroyContext(IntPtr context);

}
