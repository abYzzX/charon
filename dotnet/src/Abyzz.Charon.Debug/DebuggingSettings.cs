using Charon.Font;

namespace Charon.Debugging;

public class DebuggingSettings
{
    public bool Enabled { get; set; }
    public IFont? DefaultFont { get; set; }
    public Color DefaultColor { get; set; } = Color.LimeGreen;
}
