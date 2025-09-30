using Charon;
using Charon.ContentPipeline;
using Charon.Debugging;
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

    public required IKeyboardInputService KeyboardInputService { private get; init; }
    public required IMouseInputService MouseInputService { private get; init; }
    public required ICharonGame Game { private get; init; }
    public required Func<IRenderBatch> RenderBatchFactory { private get; init; }
    public required Func<ISpriteBatch> SpriteBatchFactory { private get; init; }
    
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
    }

    public void Dispose()
    {
    }
}
