using Charon.Abstractions;
using Charon.Geom;
using Charon.Math;
using Charon.Modularity;
using Charon.Modularity.Attributes;
using SDL;

namespace Charon.Sdl3;

[ExposeServices(typeof(IRenderBatch))]
public unsafe class SdlRenderBatch : RenderBatchBase, IScopedDependency
{
    private readonly SdlRenderer _renderer;
    private readonly List<SDL_Vertex> _vertices = new();
    private readonly List<int> _indices = new();
    private bool _beginCalled = false;

    private SdlTexture? _texture = null;
    private SDL_BlendMode _srcBlendMode = SDL_BlendMode.SDL_BLENDMODE_BLEND;
    private SDL_BlendMode _destBlendMode = SDL_BlendMode.SDL_BLENDMODE_BLEND;

    public SdlRenderBatch(IRendererAccessor rendererAccessor)
    {
        if (rendererAccessor.Renderer is not SdlRenderer sdlRenderer)
        {
            throw new CharonInitializationException("SdlRenderer is required.");
        }

        _renderer = sdlRenderer;
    }

    public override IDisposable Begin(ITexture? texture = null, BlendMode? srcBlendMode = null, BlendMode? destBlendMode = null)
    {
        if (_beginCalled)
        {
            throw new InvalidOperationException("Begin called twice");
        }

        if (texture != null && texture is not SdlTexture)
        {
            throw new ArgumentException("SdlTexture required.");
        }

        _srcBlendMode = (srcBlendMode ?? BlendMode.Blend).ToSDLBlendMode();
        _destBlendMode = (destBlendMode ?? BlendMode.Blend).ToSDLBlendMode();
        _texture = texture as SdlTexture;
        _vertices.Clear();
        _indices.Clear();
        _beginCalled = true;
        return new DisposableAction(Flush);
    }

    public override IRenderBatch DrawVerticies(Vertex[] vertices, int[] indices)
    {
        if (!_beginCalled)
        {
            throw new InvalidOperationException("Begin must be called before adding vertices");
        }

        var verticesOffset = _vertices.Count;
        _vertices.AddRange(vertices.Select(v => v.ToSdlVertex(Projection)));
        _indices.AddRange(indices.Select(i => i + verticesOffset));
        return this;
    }

    public override IRenderBatch DrawPoint(Vector2 position, Color color)
    {
        _renderer.Color = color;
        SDL3.SDL_RenderPoint(_renderer.Handle, position.X, position.Y);
        return this;
    }

    public override IRenderBatch DrawPoints(Color color, params Vector2[] points)
    {
        _renderer.Color = color;
        var sdlPoints = points.Select(v => v.ToFPoint()).ToArray();
        fixed (SDL_FPoint* pointsPtr = sdlPoints)
        {
            SDL3.SDL_RenderPoints(_renderer.Handle, pointsPtr, sdlPoints.Length);
        }

        return this;
    }

    public override IRenderBatch DrawLines(Color color, params Line[] lines)
    {
        _renderer.Color = color;
        var sdlPoints = lines
            .SelectMany<Line, Vector2>(l => [l.Start, l.End])
            .Select(p => Projection.Transform(p))
            .Select(p => p.ToFPoint())
            .ToArray();

        fixed (SDL_FPoint* pointsPtr = sdlPoints)
        {
            SDL3.SDL_RenderLines(_renderer.Handle, pointsPtr, sdlPoints.Length);
        }

        return this;
    }

    public override IRenderBatch DrawShape(IShape shape, Color color)
    {
        _renderer.Color = color;
        var points = shape.GetPoints();
        if (!Projection.IsIdentity)
        {
            points = points.Select(p => Projection.Transform(p)).ToArray();
        }

        var sdlPoints = new SDL_FPoint[points.Length + 1];
        Array.Copy(points.Select(x => x.ToFPoint()).ToArray(), sdlPoints, points.Length);
        sdlPoints[^1] = points[0].ToFPoint();

        fixed (SDL_FPoint* pointsPtr = sdlPoints)
        {
            SDL3.SDL_RenderLines(_renderer.Handle, pointsPtr, sdlPoints.Length);
        }

        return this;
    }

    public override IRenderBatch FillShape(IShape shape, Color color)
    {
        var points = shape.GetPoints();
        if (GeometryMath.IsConvexPolygon(points))
        {
            FillConvexPolygon(points, color);
        }
        else
        {
            throw new NotImplementedException("Filling non-convex polygons is not implemented yet.");
        }

        return this;
    }

    public override IRenderBatch FillTexturedShape(IShape shape, Rectangle? sourceRect = null, Color? color = null)
    {
        if (_texture == null)
        {
            throw new InvalidOperationException("Texture is not set");
        }

        var points = shape.GetPoints();
        if (GeometryMath.IsConvexPolygon(points))
        {
            FillConvexPolygon(points, color ?? Color.White, true, sourceRect ?? new Rectangle(0, 0, _texture.Width, _texture.Height));
        }
        else
        {
            throw new NotImplementedException("Filling non-convex polygons is not implemented yet.");
        }

        return this;
    }

    private void FillConvexPolygon(Vector2[] points, Color color, bool useTexture = false,
        Rectangle? textureSourceRect = null)
    {
        var col = color.ToFColor();
        SDL_Vertex[] verts = [];

        if (useTexture)
        {
            var texSourceRect = textureSourceRect ?? new Rectangle(0, 0, _texture.Width, _texture.Height);
            var minX = points.Min(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxX = points.Max(p => p.X);
            var maxY = points.Max(p => p.Y);

            var width = System.Math.Max(0.0001f, maxX - minX);
            var height = System.Math.Max(0.0001f, maxY - minY);

            verts = points.Select(p =>
            {
                var u = (p.X - minX) / width; // 0 bis 1
                var v = (p.Y - minY) / height; // 0 bis 1
                u = (texSourceRect.X + u * texSourceRect.Width) / _texture.Width;
                v = (texSourceRect.Y + v * texSourceRect.Height) / _texture.Height;

                return new SDL_Vertex()
                {
                    color = col,
                    position = Projection.Transform(p).ToFPoint(),
                    tex_coord = new SDL_FPoint() { x = u, y = v }
                };
            }).ToArray();
        }
        else
        {
            verts =
                points
                    .Select(p => Projection.Transform(p))
                    .Select(p => p.ToSdlVertex(col)).ToArray();
        }

        var indices = GeometryMath.TriangulateConvex(points);

        fixed (SDL_Vertex* vertsPtr = verts)
        {
            fixed (int* indicesPtr = indices)
            {
                if (useTexture && _texture != null)
                {
                    SDL3.SDL_RenderGeometry(_renderer.Handle, _texture.Handle, vertsPtr, verts.Length, indicesPtr, indices.Length);
                }
                else
                {
                    SDL3.SDL_RenderGeometry(_renderer.Handle, null, vertsPtr, verts.Length, indicesPtr, indices.Length);
                    
                }
            }
        }
    }

    public override void Flush()
    {
        _beginCalled = false;
        if (_vertices.Count == 0) return;

        fixed (SDL_Vertex* vertsPtr = _vertices.ToArray())
        {
            fixed (int* indicesPtr = _indices.ToArray())
            {
                SDL_Texture* textureHandle = null;
                if (_texture != null)
                {
                    textureHandle = _texture.Handle;
                    SDL3.SDL_SetTextureBlendMode(textureHandle, _srcBlendMode);
                }

                SDL3.SDL_SetRenderDrawBlendMode(_renderer.Handle, _destBlendMode);
                SDL3.SDL_RenderGeometry(
                    _renderer.Handle,
                    textureHandle,
                    vertsPtr,
                    _vertices.Count,
                    indicesPtr,
                    _indices.Count);
            }
        }

        _vertices.Clear();
        _indices.Clear();
    }
}
