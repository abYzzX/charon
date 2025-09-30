using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Charon;

public class SceneManager : ISceneManager, IGlobalService
{
    public required IOptions<SceneManagerSettings> Settings { protected get; init; }
    public required IServiceScopeFactory ScopeFactory { protected get; init; }
    public required ILogger<SceneManager> Logger { protected get; init; }   
    
    public IScene? CurrentScene { get; protected set; }

    public int Order { get; } = 0;
    
    public void ChangeScene<TScene>()
        where TScene : class, IScene
    {
        ChangeScene(typeof(TScene));       
    }

    public void ChangeScene(Type sceneType)
    {
        if (!sceneType.IsAssignableTo<IScene>())
        {
            Logger.LogCritical("Scene type must implement IScene interface. Type: {SceneType}", sceneType.FullName ?? "null");       
            throw new CharonSceneException("Scene type must implement IScene interface");
        }

        if (CurrentScene != null)
        {
            Logger.LogInformation("Dispose current scene. Type: {SceneType}", CurrentScene);       
            CurrentScene?.Dispose();
        }

        Logger.LogInformation("Change scene to {SceneType}", sceneType.FullName ?? "null");      
        var scope = ScopeFactory.CreateScope();
        var scene = scope.ServiceProvider.GetRequiredService(sceneType) as IScene;
        CurrentScene = new SceneDisposeWrapper(scene!, scope);
        CurrentScene.Initialize();       
    }


    public void Initialize()
    {
        if (Settings.Value.MainSceneType == null)
        {
            Logger.LogCritical("Main scene type is not set. Use CharonGameBuilder.UseMainScene<TScene>() to set main scene type.");
            throw new CharonSceneException("Main scene type is not set");       
        }
        ChangeScene(Settings.Value.MainSceneType);           
    }

    public void Update(IGameTime gameTime)
    {
        CurrentScene?.Update(gameTime);
    }
    
    public void Render()
    {
        CurrentScene?.Render();
    }
    
    private sealed class SceneDisposeWrapper : IScene
    {
        public IScene Scene { get; }
        public IServiceScope Scope { get; }

        public SceneDisposeWrapper(IScene scene, IServiceScope scope)
        {
            Scene = scene;
            Scope = scope;
        }

        public void Dispose()
        {
            Scene.Dispose();
            Scope.Dispose();       
        }

        public void Initialize()
        {
            Scene.Initialize();
        }

        public void Update(IGameTime gameTime)
        {
            Scene.Update(gameTime);
        }

        public void Render()
        {
            Scene.Render();       
        }

        public override string ToString()
        {
            return $"{nameof(Scene)}: {Scene}";
        }
    }
}
