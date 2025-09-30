using System.Reflection;
using System.Runtime.CompilerServices;

namespace Charon.Abstractions;

public abstract class SceneBase : IScene
{
    private readonly List<ISceneUpdatableService> _updatableServices = new();
    private readonly List<ISceneRenderableService> _renderableServices = new();

    protected bool AutoRegisterServices { get; set; } = true;
    protected IReadOnlyCollection<ISceneUpdatableService> UpdatableServices { get => _updatableServices; }
    protected IReadOnlyCollection<ISceneRenderableService> RenderableServices { get => _renderableServices; }

    public virtual void Initialize()
    {
        RegisterPropertyInjectedServices();
    }

    private List<ISceneService> GetPropertyServices()
    {
        return GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(prop =>
            {
                if (prop.GetCustomAttribute<RequiredMemberAttribute>() == null)
                {
                    return false;
                }

                if (prop.SetMethod == null ||
                    !prop.SetMethod.ReturnParameter
                        .GetRequiredCustomModifiers()
                        .Contains(typeof(IsExternalInit)))
                {
                    return false;
                }
                
                return prop.PropertyType.IsAssignableTo<ISceneService>();
            })
            .Select(x => x.GetValue(this) as ISceneService)
            .ToList()!;
    }

    protected void RegisterPropertyInjectedServices()
    {
        if (AutoRegisterServices)
        {
            var injectedList = GetPropertyServices();
            foreach (var initializable in injectedList.OfType<ISceneInitializableService>())
            {
                initializable.Initialize();
            }

            _updatableServices.AddRange(injectedList.OfType<ISceneUpdatableService>());
            _renderableServices.AddRange(injectedList.OfType<ISceneRenderableService>());
        }        
    }
    
    public virtual void Update(IGameTime gameTime)
    {
        foreach (var updatableService in UpdatableServices)
        {
            updatableService.Update(gameTime);
        }

        OnUpdate(gameTime);
    }

    public virtual void Render()
    {
        var userRendered = false;
        foreach (var renderableService in RenderableServices)
        {
            if (renderableService.ZLevel == 0 && !userRendered)
            {
                OnRender();
                userRendered = true;
            }

            renderableService.Render();
        }
    }

    protected virtual void AddUpdatableService(ISceneUpdatableService service)
    {
        _updatableServices.Add(service);
    }

    protected virtual void AddRenderableService(ISceneRenderableService service)
    {
        _renderableServices.Add(service);
    }

    protected virtual void OnUpdate(IGameTime gameTime)
    {
    }

    protected virtual void OnRender()
    {
    }

    protected virtual void Dispose(bool disposing)
    {
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);       
    }
}
