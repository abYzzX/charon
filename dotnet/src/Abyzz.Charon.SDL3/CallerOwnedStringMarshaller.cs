using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

[CustomMarshaller(typeof(string), MarshalMode.ManagedToUnmanagedOut, typeof(CallerOwnedStringMarshaller))]
public static unsafe class CallerOwnedStringMarshaller
{
    /// <summary>
    /// Converts an unmanaged string to a managed version.
    /// </summary>
    /// <returns>A managed string.</returns>
    public static string ConvertToManaged(byte* unmanaged)
        => Marshal.PtrToStringUTF8((IntPtr) unmanaged);

    /// <summary>
    /// Free the memory for a specified unmanaged string.
    /// </summary>
    public static void Free(byte* unmanaged)
        => SdlStdinc.SDL_free((IntPtr) unmanaged);
}
