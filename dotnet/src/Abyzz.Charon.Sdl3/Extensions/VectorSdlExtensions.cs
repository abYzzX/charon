using Charon.Math;
using SDL;

namespace Charon.Sdl3;

internal static class VectorSdlExtensions
{
    public static SDL_FPoint ToFPoint(this Vector2 v)
    {
        return new SDL_FPoint() { x = v.X, y = v.Y };
    }

    public static SDL_Vertex ToSdlVertex(this Vector2 v, SDL_FColor color,
        Vector2? texCoord = null)
    {
        return new SDL_Vertex()
        {
            color = color,
            position = v.ToFPoint(),
            tex_coord = texCoord.HasValue ? texCoord.Value.ToFPoint() : default
        };
    }
}
