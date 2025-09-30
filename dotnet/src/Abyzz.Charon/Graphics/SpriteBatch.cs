using Charon.Geom;
using Charon.Modularity;
using Charon.Modularity.Attributes;

namespace Charon;

[ExposeServices(typeof(ISpriteBatch))]
public class SpriteBatch : ISpriteBatch, IScopedDependency
{
    protected readonly struct SpriteRenderData
    {
        public ITexture Texture { get; init; }
        public Vector2 Position { get; init; }
        public Rectangle SourceRectangle { get; init; }
        public Vector2 Origin { get; init; }
        public float Rotation { get; init; }
        public Vector2 Scale { get; init; }
        public bool FlipHorizontally { get; init; }
        public bool FlipVertically { get; init; }
        public Color Color { get; init; }
    }

    private readonly List<SpriteRenderData> _renderData = new();
    private bool _isBeginCalled = false;
    
    protected IReadOnlyList<SpriteRenderData> RenderData { get => _renderData; }

    public required IRenderBatch RenderBatch { protected get; init; }

    public IDisposable UseProjection(Matrix2D projection)
    {
        return RenderBatch.UseProjection(projection);       
    }

    public IDisposable Begin()
    {
        if (_isBeginCalled)
        {
            throw new InvalidOperationException("Begin must be called only once");
        }

        _isBeginCalled = true;
        _renderData.Clear();

        return new DisposableAction(Flush);
    }

    public ISpriteBatch DrawSprite(Sprite sprite)
    {
        AddRenderData(new SpriteRenderData()
        {
            Texture = sprite.Texture,
            Position = sprite.Position,
            SourceRectangle = sprite.TextureSourceRectangle,
            Origin = sprite.Origin,
            Rotation = sprite.Rotation,
            Scale = sprite.Scale,
            FlipHorizontally = sprite.FlipHorizontally,
            FlipVertically = sprite.FlipVertically,
            Color = sprite.Color,
        });

        return this;
    }

    public ISpriteBatch DrawSprite(ITexture texture, Vector2 position, Color color)
    {
        AddRenderData(new SpriteRenderData()
        {
            Texture = texture,
            Position = position,
            Color = color,
            SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height),
            Origin = Vector2.Zero,
            Rotation = 0,
            Scale = Vector2.One,
            FlipHorizontally = false,
            FlipVertically = false,
        });

        return this;
    }

    public ISpriteBatch DrawSprite(ITexture texture, Vector2 position, Color color, Rectangle sourceRectangle,
        Vector2 origin,
        float rotation, Vector2 scale, bool flipHorizontally, bool flipVertically)
    {
        AddRenderData(new SpriteRenderData()
        {
            Texture = texture,
            Position = position,
            Color = color,
            SourceRectangle = sourceRectangle,
            Origin = origin,
            Rotation = rotation,
            Scale = scale,
            FlipHorizontally = flipHorizontally,
            FlipVertically = flipVertically,
        });

        return this;
    }

    public void Flush()
    {
        if (!_isBeginCalled)
        {
            throw new InvalidOperationException("Begin must be called before flushing");
        }

        var textureGroups = _renderData.GroupBy(x => x.Texture);

        foreach (var textureGroup in textureGroups)
        {
            using (RenderBatch.Begin(textureGroup.Key))
            {
                foreach (var renderData in textureGroup)
                {
                    var rectangle =
                        new Rectangle(Vector2.Zero, 
                            renderData.SourceRectangle.Size);
                    using (RenderBatch.UseProjection(GetTransformMatrix(renderData)))
                    {
                        RenderBatch.FillTexturedShape(rectangle, renderData.SourceRectangle, renderData.Color);
                    }
                }
            }
        }
        _renderData.Clear();
        _isBeginCalled = false;
    }

    protected virtual Matrix2D GetTransformMatrix(SpriteRenderData sprite)
    {
        var pivot = sprite.Origin * sprite.SourceRectangle.Size;
        var scaleX = sprite.FlipHorizontally ? -sprite.Scale.X : sprite.Scale.X;
        var scaleY = sprite.FlipVertically ? -sprite.Scale.Y : sprite.Scale.Y;

        var matrix = Matrix2D.Identity;
        matrix *= Matrix2D.CreateTranslation(-pivot);                      // Pivot in Ursprung
        matrix *= Matrix2D.CreateScale(new Vector2(scaleX, scaleY));       // Skalierung & Flip
        matrix *= Matrix2D.CreateRotation(sprite.Rotation);               // Rotation
        matrix *= Matrix2D.CreateTranslation(sprite.Position);            // Sprite an Position

        return matrix;
    }    
    
    protected virtual void AddRenderData(SpriteRenderData data)
    {
        if (!_isBeginCalled)
        {
            throw new InvalidOperationException("Begin must be called before adding render data");
        }

        _renderData.Add(data);
    }
}
