using Charon;
using Charon.ContentPipeline;
using Charon.Debugging;
using Charon.Ecs;
using Charon.Ecs.Components;
using Charon.Font;
using Charon.Geom;
using Charon.Input;
using Charon.Math;
using Microsoft.Extensions.Logging;

namespace Abyzz.Charon.Demo;

public class DemoScene : IScene
{
    private IRenderBatch _renderBatch;
    private ISpriteBatch _spriteBatch;
    private IFont _font;
    private IEntity _entity;
    private IQueryBuilder _queryBuilder;

    public required IKeyboardInputService KeyboardInputService { private get; init; }
    public required IMouseInputService MouseInputService { private get; init; }
    public required ICharonGame Game { private get; init; }
    public required Func<IRenderBatch> RenderBatchFactory { private get; init; }
    public required Func<ISpriteBatch> SpriteBatchFactory { private get; init; }
    public required IContentManager ContentManager { private get; init; }
    public required IFpsCounter FpsCounter { private get; init; }

    public required IEntityManager EntityManager { private get; init; }
    public required Func<IQueryBuilder> QueryBuilderFactory { private get; init; }


    public void Initialize()
    {
        _renderBatch = RenderBatchFactory();
        _spriteBatch = SpriteBatchFactory();

        _font = ContentManager.LoadFont("image_font.cfnt");

        _entity = EntityManager.CreateEntity();
        EntityManager.Add(_entity, new ShapeComponent { Shape = new Rectangle(0, 0, 100, 100) });
        EntityManager.Add(_entity,
            new TransformComponent
            {
                Position = new Vector2(100, 100),
                Origin = new Vector2(50, 50),
                Rotation = 0,
                Scale = new Vector2(1, 1)
            });

        _queryBuilder = QueryBuilderFactory();
        _queryBuilder
            .All<ShapeComponent>()
            .All<TransformComponent>();
    }

    public void Update(IGameTime gameTime)
    {
        if (KeyboardInputService.IsKeyDown(Keys.KeyEscape))
        {
            Game.Shutdown();
        }
        
        EntityManager.GetComponent<TransformComponent>(_entity).Rotation += 0.001f;
        // EntityManager.GetComponent<TransformComponent>(_entity).Scale += 0.001f;
    }

    public void Render()
    {
        using (_renderBatch.Begin())
        {
            foreach (var entity in _queryBuilder.Build())
            {
                var shape = EntityManager.GetComponent<ShapeComponent>(entity).Shape;
                var transform = EntityManager.GetComponent<TransformComponent>(entity);

                using (_renderBatch.UseProjection(
                           Matrix2D.CreateTransform(transform.Position, 
                               transform.Rotation, 
                               transform.Scale,
                               transform.Origin)))
                {
                    _renderBatch.DrawShape(shape, Color.Red);
                }
            }
        }
    }

    public void Dispose()
    {
    }
}
