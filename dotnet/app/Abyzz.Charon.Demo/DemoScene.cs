using Charon;
using Charon.Ecs;
using Charon.Font;
using Charon.Input;

namespace Abyzz.Charon.Demo;

public class DemoScene : IScene
{
    private IRenderBatch _renderBatch;
    private ISpriteBatch _spriteBatch;
    private IEntity _entity;
    private IQueryBuilder _queryBuilder;
    private IEntityQuery _query;

    public required IKeyboardInputService KeyboardInputService { private get; init; }
    public required IMouseInputService MouseInputService { private get; init; }
    public required ICharonGame Game { private get; init; }
    public required Func<IRenderBatch> RenderBatchFactory { private get; init; }
    public required Func<ISpriteBatch> SpriteBatchFactory { private get; init; }
    public required IContentManager ContentManager { private get; init; }
    public required IFpsCounter FpsCounter { private get; init; }
    public required IEntityManager EntityManager { private get; init; }
    public required IQueryBuilder QueryBuilder { private get; init; }


    public void Initialize()
    {
        _renderBatch = RenderBatchFactory();
        _spriteBatch = SpriteBatchFactory();
    }

    public void Update(IGameTime gameTime)
    {
        if (KeyboardInputService.IsKeyDown(Keys.KeyEscape))
        {
            Game.Shutdown();
        }
    }

    public void Render()
    {
        using (_renderBatch.Begin())
        {
        }
    }

    public void Dispose()
    {
    }
}
