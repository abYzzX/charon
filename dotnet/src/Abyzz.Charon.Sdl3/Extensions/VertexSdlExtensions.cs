using Charon.Math;
using SDL;

namespace Charon.Sdl3;

internal static class VertexSdlExtensions
{
    public static SDL_Vertex ToSdlVertex(this Vertex vertex, Matrix2D? projection = null)
    {
        return new()
        {
            color = vertex.Color.ToFColor(),
            position = projection == null 
                ? vertex.Position.ToFPoint()
                : projection.Value.Transform(vertex.Position).ToFPoint(),
            tex_coord = vertex.TextureCoord?.ToFPoint() ?? default
        };
    }
    
}
