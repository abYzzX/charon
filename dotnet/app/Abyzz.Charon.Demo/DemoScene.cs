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
    private ITexture _texture;

    public required IKeyboardInputService KeyboardInputService { private get; init; }
    public required IMouseInputService MouseInputService { private get; init; }
    public required ICharonGame Game { private get; init; }
    public required Func<IRenderBatch> RenderBatchFactory { private get; init; }
    public required Func<ISpriteBatch> SpriteBatchFactory { private get; init; }
    
    public required IFpsCounter FpsCounter { private get; init; }
    public required ILogger<DemoScene> Logger { private get; init; }
    public required IContentManager ContentManager { private get; init; }
    public required ITextureWriter TextureWriter { private get; init; }
    public required IDebugOverlay DebugOverlay { private get; init; }

    private Sprite _sprite;
    private IFont _font;
    
    public void Initialize()
    {
        _renderBatch = RenderBatchFactory();
        _spriteBatch = SpriteBatchFactory();
        _texture = ContentManager.LoadTexture("/home/ariakas/Pictures/Games/merge_maestro.jpg");
        _font = ContentManager.LoadFont(
            "/home/ariakas/Projects/Rider/abyzz.monogame.devon/dotnet/src/Abyzz.MonoGame.Charon.ContentPipelines.Bdf/Samples/10x20.bdf");
        
        _sprite = new Sprite(_texture, new Vector2(512, 384))
        {
            Origin = new Vector2(0.5f, 0.5f),
            Scale = new Vector2(0.5f, 0.5f),
            Rotation = rad,
            Color = Color.White
        };
    }

    public void Update(IGameTime gameTime)
    {
        if (KeyboardInputService.IsKeyDown(Keys.KeyEscape))
        {
            Game.Shutdown();
        }

        _sprite.Rotation += 0.01f;
        _sprite.Scale += 0.0001f;
        _sprite.FlipHorizontally = KeyboardInputService.IsKeyDown(Keys.KeyH);
        _sprite.FlipVertically = KeyboardInputService.IsKeyDown(Keys.KeyV);
    }

    private float rad = 0;

    public void Render()
    {
        using (_spriteBatch.Begin())
        {
            _spriteBatch.DrawString(_font, $"FPS: {FpsCounter.Fps} (min: {FpsCounter.MinFps} / max: {FpsCounter.MaxFps})", new Vector2(5, 5), Color.LimeGreen);
        }
    }

    public void Dispose()
    {
        (_texture as IDisposable)?.Dispose();
    }
}
