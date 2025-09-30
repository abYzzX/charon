using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Charon.SDL3;

public static unsafe partial class SdlHidapi
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_hid_bus_type
	{
		SDL_HID_API_BUS_UNKNOWN = 0,
		SDL_HID_API_BUS_USB = 1,
		SDL_HID_API_BUS_BLUETOOTH = 2,
		SDL_HID_API_BUS_I2C = 3,
		SDL_HID_API_BUS_SPI = 4,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_hid_device_info
	{
		public byte* path;
		public ushort vendor_id;
		public ushort product_id;
		public byte* serial_number;
		public ushort release_number;
		public byte* manufacturer_string;
		public byte* product_string;
		public ushort usage_page;
		public ushort usage;
		public int interface_number;
		public int interface_class;
		public int interface_subclass;
		public int interface_protocol;
		public SDL_hid_bus_type bus_type;
		public SDL_hid_device_info* next;
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_init();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_exit();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_hid_device_change_count();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_hid_device_info* SDL_hid_enumerate(ushort vendor_id, ushort product_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_hid_free_enumeration(IntPtr devs); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_hid_open(ushort vendor_id, ushort product_id, string serial_number);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_hid_open_path(string path);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_write(IntPtr dev, IntPtr data, UIntPtr length); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_read_timeout(IntPtr dev, IntPtr data, UIntPtr length, int milliseconds); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_read(IntPtr dev, IntPtr data, UIntPtr length); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_set_nonblocking(IntPtr dev, int nonblock);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_send_feature_report(IntPtr dev, IntPtr data, UIntPtr length); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_get_feature_report(IntPtr dev, IntPtr data, UIntPtr length); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_get_input_report(IntPtr dev, IntPtr data, UIntPtr length); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_close(IntPtr dev);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_get_manufacturer_string(IntPtr dev, string @string, UIntPtr maxlen);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_get_product_string(IntPtr dev, string @string, UIntPtr maxlen);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_get_serial_number_string(IntPtr dev, string @string, UIntPtr maxlen);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_get_indexed_string(IntPtr dev, int string_index, string @string, UIntPtr maxlen);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDL_hid_device_info* SDL_hid_get_device_info(IntPtr dev);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_hid_get_report_descriptor(IntPtr dev, IntPtr buf, UIntPtr buf_size); // WARN_UNKNOWN_POINTER_PARAMETER

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_hid_ble_scan(SDLBool active);

}
