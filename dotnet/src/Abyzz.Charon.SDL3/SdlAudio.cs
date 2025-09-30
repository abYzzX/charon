using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

public static unsafe partial class SdlAudio
{
    private const string NativeLibName = SDL.NativeLibName;

	public enum SDL_AudioFormat
	{
		SDL_AUDIO_UNKNOWN = 0,
		SDL_AUDIO_U8 = 8,
		SDL_AUDIO_S8 = 32776,
		SDL_AUDIO_S16LE = 32784,
		SDL_AUDIO_S16BE = 36880,
		SDL_AUDIO_S32LE = 32800,
		SDL_AUDIO_S32BE = 36896,
		SDL_AUDIO_F32LE = 33056,
		SDL_AUDIO_F32BE = 37152,
		SDL_AUDIO_S16 = 32784,
		SDL_AUDIO_S32 = 32800,
		SDL_AUDIO_F32 = 33056,
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SDL_AudioSpec
	{
		public SDL_AudioFormat format;
		public int channels;
		public int freq;
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetNumAudioDrivers();

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetAudioDriver(int index);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetCurrentAudioDriver();

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetAudioPlaybackDevices(out int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetAudioRecordingDevices(out int count);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetAudioDeviceName(uint devid);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetAudioDeviceFormat(uint devid, out SDL_AudioSpec spec, out int sample_frames);

	public static Span<int> SDL_GetAudioDeviceChannelMap(uint devid)
	{
		var result = SDL_GetAudioDeviceChannelMap(devid, out var count);
		return new Span<int>((void*) result, count);
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetAudioDeviceChannelMap(uint devid, out int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_OpenAudioDevice(uint devid, ref SDL_AudioSpec spec);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_IsAudioDevicePhysical(uint devid);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_IsAudioDevicePlayback(uint devid);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_PauseAudioDevice(uint dev);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ResumeAudioDevice(uint dev);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_AudioDevicePaused(uint dev);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial float SDL_GetAudioDeviceGain(uint devid);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAudioDeviceGain(uint devid, float gain);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_CloseAudioDevice(uint devid);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_BindAudioStreams(uint devid, Span<IntPtr> streams, int num_streams);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_BindAudioStream(uint devid, IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_UnbindAudioStreams(Span<IntPtr> streams, int num_streams);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_UnbindAudioStream(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetAudioStreamDevice(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_CreateAudioStream(ref SDL_AudioSpec src_spec, ref SDL_AudioSpec dst_spec);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial uint SDL_GetAudioStreamProperties(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_GetAudioStreamFormat(IntPtr stream, out SDL_AudioSpec src_spec, out SDL_AudioSpec dst_spec);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAudioStreamFormat(IntPtr stream, ref SDL_AudioSpec src_spec, ref SDL_AudioSpec dst_spec);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial float SDL_GetAudioStreamFrequencyRatio(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAudioStreamFrequencyRatio(IntPtr stream, float ratio);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial float SDL_GetAudioStreamGain(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAudioStreamGain(IntPtr stream, float gain);

	public static Span<int> SDL_GetAudioStreamInputChannelMap(IntPtr stream)
	{
		var result = SDL_GetAudioStreamInputChannelMap(stream, out var count);
		return new Span<int>((void*) result, count);
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetAudioStreamInputChannelMap(IntPtr stream, out int count);

	public static Span<int> SDL_GetAudioStreamOutputChannelMap(IntPtr stream)
	{
		var result = SDL_GetAudioStreamOutputChannelMap(stream, out var count);
		return new Span<int>((void*) result, count);
	}

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_GetAudioStreamOutputChannelMap(IntPtr stream, out int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAudioStreamInputChannelMap(IntPtr stream, Span<int> chmap, int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAudioStreamOutputChannelMap(IntPtr stream, Span<int> chmap, int count);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_PutAudioStreamData(IntPtr stream, IntPtr buf, int len);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetAudioStreamData(IntPtr stream, IntPtr buf, int len);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetAudioStreamAvailable(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetAudioStreamQueued(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_FlushAudioStream(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ClearAudioStream(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_PauseAudioStreamDevice(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ResumeAudioStreamDevice(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_AudioStreamDevicePaused(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_LockAudioStream(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_UnlockAudioStream(IntPtr stream);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SDL_AudioStreamCallback(IntPtr userdata, IntPtr stream, int additional_amount, int total_amount);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAudioStreamGetCallback(IntPtr stream, SDL_AudioStreamCallback callback, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAudioStreamPutCallback(IntPtr stream, SDL_AudioStreamCallback callback, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial void SDL_DestroyAudioStream(IntPtr stream);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial IntPtr SDL_OpenAudioDeviceStream(uint devid, ref SDL_AudioSpec spec, SDL_AudioStreamCallback callback, IntPtr userdata);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SDL_AudioPostmixCallback(IntPtr userdata, SDL_AudioSpec* spec, float* buffer, int buflen);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_SetAudioPostmixCallback(uint devid, SDL_AudioPostmixCallback callback, IntPtr userdata);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_LoadWAV_IO(IntPtr src, SDLBool closeio, out SDL_AudioSpec spec, out IntPtr audio_buf, out uint audio_len);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_LoadWAV(string path, out SDL_AudioSpec spec, out IntPtr audio_buf, out uint audio_len);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_MixAudio(IntPtr dst, IntPtr src, SDL_AudioFormat format, uint len, float volume);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial SDLBool SDL_ConvertAudioSamples(ref SDL_AudioSpec src_spec, IntPtr src_data, int src_len, ref SDL_AudioSpec dst_spec, IntPtr dst_data, out int dst_len);

	[LibraryImport(NativeLibName, StringMarshalling = StringMarshalling.Utf8)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[return: MarshalUsing(typeof(SDLOwnedStringMarshaller))]
	public static partial string SDL_GetAudioFormatName(SDL_AudioFormat format);

	[LibraryImport(NativeLibName)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	public static partial int SDL_GetSilenceValueForFormat(SDL_AudioFormat format);

}
