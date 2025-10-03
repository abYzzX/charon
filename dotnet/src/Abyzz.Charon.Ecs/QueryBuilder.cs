using Charon.Modularity;
using Charon.Modularity.Attributes;

namespace Charon.Ecs;

[ExposeServices(typeof(IQueryBuilder))]
internal class QueryBuilder : IQueryBuilder, ITransientDependency
{
    private readonly List<Type> _all = new();
    private readonly List<Type> _one = new();
    private readonly List<Type> _exclude = new();

    public required IEntityManager Manager { private get; init; }
    
    public IQueryBuilder All<T>() where T : struct, IComponent
    {
        _all.Add(typeof(T));
        return this;
    }

    public IQueryBuilder One<T>() where T : struct, IComponent
    {
        _one.Add(typeof(T));
        return this;
    }

    public IQueryBuilder Exclude<T>() where T : struct, IComponent
    {
        _exclude.Add(typeof(T));
        return this;
    }

    public IEntityQuery Build()
    {
        var query = new EntityQuery(Manager, _all, _one, _exclude);
        _all.Clear();
        _one.Clear();
        _exclude.Clear();
        return query;
    }
}
