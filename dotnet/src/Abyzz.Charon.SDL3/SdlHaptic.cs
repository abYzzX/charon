using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlHaptic
{
    private const string NativeLibName = SDL.NativeLibName;

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_HapticDirection
	{
		public byte type;
		public fixed int dir[3];
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_HapticConstant
	{
		public ushort type;
		public SDL_HapticDirection direction;
		public uint length;
		public ushort delay;
		public ushort button;
		public ushort interval;
		public short level;
		public ushort attack_length;
		public ushort attack_level;
		public ushort fade_length;
		public ushort fade_level;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_HapticPeriodic
	{
		public ushort type;
		public SDL_HapticDirection direction;
		public uint length;
		public ushort delay;
		public ushort button;
		public ushort interval;
		public ushort period;
		public short magnitude;
		public short offset;
		public ushort phase;
		public ushort attack_length;
		public ushort attack_level;
		public ushort fade_length;
		public ushort fade_level;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_HapticCondition
	{
		public ushort type;
		public SDL_HapticDirection direction;
		public uint length;
		public ushort delay;
		public ushort button;
		public ushort interval;
		public fixed ushort right_sat[3];
		public fixed ushort left_sat[3];
		public fixed short right_coeff[3];
		public fixed short left_coeff[3];
		public fixed ushort deadband[3];
		public fixed short center[3];
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_HapticRamp
	{
		public ushort type;
		public SDL_HapticDirection direction;
		public uint length;
		public ushort delay;
		public ushort button;
		public ushort interval;
		public short start;
		public short end;
		public ushort attack_length;
		public ushort attack_level;
		public ushort fade_length;
		public ushort fade_level;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_HapticLeftRight
	{
		public ushort type;
		public uint length;
		public ushort large_magnitude;
		public ushort small_magnitude;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_HapticCustom
	{
		public ushort type;
		public SDL_HapticDirection direction;
		public uint length;
		public ushort delay;
		public ushort button;
		public ushort interval;
		public byte channels;
		public ushort period;
		public ushort samples;
		public ushort* data;
		public ushort attack_length;
		public ushort attack_level;
		public ushort fade_length;
		public ushort fade_level;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct SDL_HapticEffect
	{
		[FieldOffset(0)]
		public ushort type;
		[FieldOffset(0)]
		public SDL_HapticConstant constant;
		[FieldOffset(0)]
		public SDL_HapticPeriodic periodic;
		[FieldOffset(0)]
		public SDL_HapticCondition condition;
		[FieldOffset(0)]
		public SDL_HapticRamp ramp;
		[FieldOffset(0)]
		public SDL_HapticLeftRight leftright;
		[FieldOffset(0)]
		public SDL_HapticCustom custom;
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetHaptics(out int count);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetHapticNameForID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_OpenHaptic(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetHapticFromID(uint instance_id);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetHapticID(IntPtr haptic);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetHapticName(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_IsMouseHaptic();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_OpenHapticFromMouse();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_IsJoystickHaptic(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_OpenHapticFromJoystick(IntPtr joystick);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_CloseHaptic(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetMaxHapticEffects(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetMaxHapticEffectsPlaying(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetHapticFeatures(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetNumHapticAxes(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HapticEffectSupported(IntPtr haptic, ref SDL_HapticEffect effect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_CreateHapticEffect(IntPtr haptic, ref SDL_HapticEffect effect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_UpdateHapticEffect(IntPtr haptic, int effect, ref SDL_HapticEffect data);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_RunHapticEffect(IntPtr haptic, int effect, uint iterations);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_StopHapticEffect(IntPtr haptic, int effect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DestroyHapticEffect(IntPtr haptic, int effect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetHapticEffectStatus(IntPtr haptic, int effect);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetHapticGain(IntPtr haptic, int gain);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetHapticAutocenter(IntPtr haptic, int autocenter);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_PauseHaptic(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ResumeHaptic(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_StopHapticEffects(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_HapticRumbleSupported(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_InitHapticRumble(IntPtr haptic);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_PlayHapticRumble(IntPtr haptic, float strength, uint length);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_StopHapticRumble(IntPtr haptic);

}
