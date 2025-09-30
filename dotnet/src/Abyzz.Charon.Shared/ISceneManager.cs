namespace Charon;

public interface ISceneManager
{
    IScene? CurrentScene { get; }

    void ChangeScene<TScene>() where TScene : class, IScene;

    void ChangeScene(Type sceneType);
    void Initialize();
    void Update(IGameTime gameTime);
    void Render();
}
