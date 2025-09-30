using Charon.Modularity;

namespace Charon;

public interface IScene: IDisposable
{
    void Initialize();
    void Update(IGameTime gameTime);
    void Render();
}

