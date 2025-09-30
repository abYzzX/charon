namespace Charon;

public interface ITextureFactory
{
    ITexture Create(int width, int height, TextureFormat? format = null);
}
