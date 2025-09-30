namespace Charon;

public interface IGlobalService
{
    int Order { get; }   
    void Initialize();
    void Update(IGameTime gameTime);
    void Render();
}
