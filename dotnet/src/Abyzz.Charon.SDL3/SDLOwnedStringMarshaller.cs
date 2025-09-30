using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Charon.SDL3;

[CustomMarshaller(typeof(string), MarshalMode.ManagedToUnmanagedOut, typeof(SDLOwnedStringMarshaller))]
public static unsafe class SDLOwnedStringMarshaller
{
    /// <summary>
    /// Converts an unmanaged string to a managed version.
    /// </summary>
    /// <returns>A managed string.</returns>
    public static string ConvertToManaged(byte* unmanaged)
        => Marshal.PtrToStringUTF8((IntPtr) unmanaged);
}
