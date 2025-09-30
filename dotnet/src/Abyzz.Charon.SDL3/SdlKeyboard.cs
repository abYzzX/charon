using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlKeyboard
{
    private const string NativeLibName = SDL.NativeLibName;

	public const string SDL_PROP_TEXTINPUT_TYPE_NUMBER = "SDL.textinput.type";
	public const string SDL_PROP_TEXTINPUT_CAPITALIZATION_NUMBER = "SDL.textinput.capitalization";
	public const string SDL_PROP_TEXTINPUT_AUTOCORRECT_BOOLEAN = "SDL.textinput.autocorrect";
	public const string SDL_PROP_TEXTINPUT_MULTILINE_BOOLEAN = "SDL.textinput.multiline";
	public const string SDL_PROP_TEXTINPUT_ANDROID_INPUTTYPE_NUMBER = "SDL.textinput.android.inputtype";

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HasKeyboard();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetKeyboards(out int count);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetKeyboardNameForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetKeyboardFocus();

	public static Span<SDLBool> SDL_GetKeyboardState()
	{
		var result = SDL_GetKeyboardState(out var numkeys);
		return new Span<SDLBool>((void*) result, numkeys);
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetKeyboardState(out int numkeys);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_ResetKeyboard();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlKeycode.SDL_Keymod SDL_GetModState();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_SetModState(SdlKeycode.SDL_Keymod modstate);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetKeyFromScancode(SdlScancode.SDL_Scancode scancode, SdlKeycode.SDL_Keymod modstate, SDLBool key_event);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlScancode.SDL_Scancode SDL_GetScancodeFromKey(uint key, IntPtr modstate);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetScancodeName(SdlScancode.SDL_Scancode scancode, string name);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetScancodeName(SdlScancode.SDL_Scancode scancode);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SdlScancode.SDL_Scancode SDL_GetScancodeFromName(string name);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetKeyName(uint key);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetKeyFromName(string name);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_StartTextInput(IntPtr window);

	public enum SDL_TextInputType
	{
		SDL_TEXTINPUT_TYPE_TEXT = 0,
		SDL_TEXTINPUT_TYPE_TEXT_NAME = 1,
		SDL_TEXTINPUT_TYPE_TEXT_EMAIL = 2,
		SDL_TEXTINPUT_TYPE_TEXT_USERNAME = 3,
		SDL_TEXTINPUT_TYPE_TEXT_PASSWORD_HIDDEN = 4,
		SDL_TEXTINPUT_TYPE_TEXT_PASSWORD_VISIBLE = 5,
		SDL_TEXTINPUT_TYPE_NUMBER = 6,
		SDL_TEXTINPUT_TYPE_NUMBER_PASSWORD_HIDDEN = 7,
		SDL_TEXTINPUT_TYPE_NUMBER_PASSWORD_VISIBLE = 8,
	}

	public enum SDL_Capitalization
	{
		SDL_CAPITALIZE_NONE = 0,
		SDL_CAPITALIZE_SENTENCES = 1,
		SDL_CAPITALIZE_WORDS = 2,
		SDL_CAPITALIZE_LETTERS = 3,
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_StartTextInputWithProperties(IntPtr window, uint props);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_TextInputActive(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_StopTextInput(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ClearComposition(IntPtr window);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetTextInputArea(IntPtr window, ref SdlRect.SDL_Rect rect, int cursor);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetTextInputArea(IntPtr window, out SdlRect.SDL_Rect rect, out int cursor);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HasScreenKeyboardSupport();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ScreenKeyboardShown(IntPtr window);

}
