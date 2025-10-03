using Charon.Modularity;
using Charon.Modularity.Attributes;

namespace Charon.Ecs;

[ExposeServices(typeof(IQueryBuilder))]
internal class QueryBuilder : IQueryBuilder, ITransientDependency
{
    private readonly List<HashSet<int>> _all = new();
    private readonly List<HashSet<int>> _one = new();
    private readonly List<HashSet<int>> _exclude = new();

    public required IEntityManager Manager { private get; init; }
    
    public IQueryBuilder All<T>() where T : struct
    {
        _all.Add([..Manager.GetComponentStorage<T>().Entities]);
        return this;
    }

    public IQueryBuilder One<T>() where T : struct
    {
        _one.Add([..Manager.GetComponentStorage<T>().Entities]);
        return this;
    }

    public IQueryBuilder Exclude<T>() where T : struct
    {
        _exclude.Add([..Manager.GetComponentStorage<T>().Entities]);
        return this;
    }

    public IEnumerable<IEntity> Build()
    {
        var result = _all.Count > 0 ? new HashSet<int>(_all[0]) : new HashSet<int>();

        foreach (var set in _all.Skip(1))
            result.IntersectWith(set);

        if (_one.Count > 0)
        {
            var oneSet = new HashSet<int>();
            foreach (var set in _one) oneSet.UnionWith(set);
            result.IntersectWith(oneSet);
        }

        foreach (var set in _exclude)
            result.ExceptWith(set);

        foreach (var e in result)
            yield return new Entity(e);
    }
}
