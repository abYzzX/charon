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
    private IFont _font;

    public required IKeyboardInputService KeyboardInputService { private get; init; }
    public required IMouseInputService MouseInputService { private get; init; }
    public required ICharonGame Game { private get; init; }
    public required Func<IRenderBatch> RenderBatchFactory { private get; init; }
    public required Func<ISpriteBatch> SpriteBatchFactory { private get; init; }
    public required IContentManager ContentManager { private get; init; }
    public required IFpsCounter FpsCounter { private get; init; } 
    
    public void Initialize()
    {
        _renderBatch = RenderBatchFactory();
        _spriteBatch = SpriteBatchFactory();

        _font = ContentManager.LoadFont("image_font.cfnt");
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
        using (_spriteBatch.Begin())
        {
            _spriteBatch.DrawString(_font, $"FPS: {FpsCounter.Fps:0.00}", new Vector2(100, 100), Color.Random());
            _spriteBatch.DrawString(_font, $"Uhrzeit: {DateTime.Now.ToLongTimeString()}", new Vector2(100, 130), Color.Random());
        }
    }

    public void Dispose()
    {
    }
}
