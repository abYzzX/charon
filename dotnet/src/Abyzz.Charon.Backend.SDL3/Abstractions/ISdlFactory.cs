namespace Charon.Sdl3;

public interface ISdlFactory
{
    public void InitializeSdl();
    IWindow CreateWindow();
    IRenderer CreateRenderer(IWindow window);
    IGpuDevice CreateGpuDevice();
}
