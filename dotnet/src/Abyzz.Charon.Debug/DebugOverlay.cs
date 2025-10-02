using System.Text;
using Charon.Font;
using Charon.Modularity;
using Charon.Modularity.Attributes;
using Microsoft.Extensions.Options;

namespace Charon.Debugging;

[ReplaceService(typeof(IDebugOverlay))]
[ExposeServices(typeof(IDebugOverlay), typeof(IGlobalService))]
public class DebugOverlay : IDebugOverlay, IGlobalService, ISingletonDependency
{
    private sealed record DebugText(string Text, Color Color);
    
    private readonly List<DebugText> _debugTexts = new();
    private ISpriteBatch _spriteBatch;
    private IFont _font;

    public required IOptions<DebuggingSettings> Settings { private get; init; }
    public required Func<ISpriteBatch> SpriteBatchFactory { private get; init; }
    public required Func<IContentManager> ContentManagerFactory { private get; init; }

    public int Order { get; } = int.MaxValue;

    public IDebugOverlay AddElement(IDebugOverlayElement element)
    {
        return this;
    }

    public IDebugOverlay AddElement<TElement>() where TElement : class, IDebugOverlayElement
    {
        return this;
    }

    public void Initialize()
    {
        _spriteBatch = SpriteBatchFactory();
        var contentManager = ContentManagerFactory();
        if (string.IsNullOrWhiteSpace(Settings.Value.DefaultFont))
        {
            var assembly = typeof(CharonDebugModule).Assembly;
            using var asmStream = assembly.GetManifestResourceStream("Charon.Debugging.Content.default_font.bdf");
            _font = contentManager.LoadFont("default_font.bdf", asmStream);
        }
        else
        {
            _font = contentManager.LoadFont(Settings.Value.DefaultFont);       
        }
    }

    public void Update(IGameTime gameTime)
    {
        if (!Settings.Value.Enabled)
        {
            return;
        }
    }

    public void Render()
    {
        if (!Settings.Value.Enabled)
        {
            return;
        }

        using (_spriteBatch.Begin())
        {
            var y = 2;
            foreach (var debugText in _debugTexts)
            {
                _spriteBatch.DrawString(_font, debugText.Text, new Vector2(2, y), debugText.Color);
                y += _font.LineHeight + 2;           
            }
        }
        
        _debugTexts.Clear();
    }

    public IDebugOverlay AddText(string text, Color? color = null)
    {
        _debugTexts.Add(new DebugText(text, color ?? Settings.Value.DefaultColor));
        return this;
    }
}
