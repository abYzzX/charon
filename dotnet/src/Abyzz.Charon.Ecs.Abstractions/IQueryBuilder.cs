namespace Charon.Ecs;

public interface IQueryBuilder
{
    IQueryBuilder All<T>() where T : struct, IComponent;
    IQueryBuilder One<T>() where T : struct, IComponent;
    IQueryBuilder Exclude<T>() where T : struct, IComponent;
    IEntityQuery Build();
}
