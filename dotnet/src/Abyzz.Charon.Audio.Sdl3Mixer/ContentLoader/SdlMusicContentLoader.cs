using System.Runtime.InteropServices;
using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.Logging;
using SDL;

namespace Charon.Audio;

[ExposeServices(typeof(IContentLoader))]
internal class SdlMusicContentLoader : IContentLoader, ITransientDependency
{
    public Type ContentType { get; } = typeof(IMusicPlayer);
    public string Name { get; } = "SDL Music loader";
    public IReadOnlyCollection<string> SupportedExtensions { get; } = [".wav", ".ogg", ".mp3", ".flac", ".mod"];

    public required ILogger<SdlMusicContentLoader> Logger { private get; init; }
    public required Sdl3Mixer Mixer { private get; init; }

    public unsafe object? Load(Stream stream, string filename)
    {
        var data = new byte[stream.Length];
        _ = stream.Read(data);
        var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
        try
        {
            var ptr = handle.AddrOfPinnedObject();

            var io = SDL3.SDL_IOFromMem(ptr, new UIntPtr((uint)data.Length));
            if (io == null)
            {
                var ex = new CharonSdl3MixerException();
                Logger.LogError(ex, "Failed to create SDL_IO");
                throw ex;
            }

            var audio = SDL3_mixer.MIX_LoadAudio_IO(Mixer.Mixer, io, true, true);
            if (audio == null)
            {
                var ex = new CharonSdl3MixerException();
                Logger.LogError(ex, "Failed to load audio: {msg}", SDL3.SDL_GetError());
                throw ex;
            }

            return new SdlMusicPlayer(Mixer, audio);
        }
        finally
        {
            handle.Free();
        }
    }
}
