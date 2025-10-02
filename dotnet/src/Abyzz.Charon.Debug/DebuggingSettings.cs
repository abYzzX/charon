using Charon.Font;
using Charon.Input;

namespace Charon.Debugging;

public class DebuggingSettings
{
    public bool Enabled { get; set; } = true;
    public string? DefaultFont { get; set; }
    public Color DefaultColor { get; set; } = Color.LimeGreen;
    public Keys ToggleKey { get; set; } = Keys.KeyF12;
}
