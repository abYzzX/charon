namespace Charon;

public class Sdl3Settings
{
    public string Title { get; set; } = "Charon";
    public int WindowWidth { get; set; } = 800;
    public int WindowHeight { get; set; } = 600;
    public bool Fullscreen { get; set; } = false;
    public bool CaptureMouse { get; set; } = false;
    public bool VSync { get; set; } = false;
    public uint TargetFps { get; set; } = 120;
    public bool LimitFps { get; set; } = false;
    public bool IsResizable { get; set; } = true;
    public bool UseOpenGl { get; set; } = true;
    public bool UseVulkan { get; set; } = false;
    public Color ClearColor { get; set; } = Color.Black;
}
