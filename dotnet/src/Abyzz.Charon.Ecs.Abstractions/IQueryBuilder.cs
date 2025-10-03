namespace Charon.Ecs;

public interface IQueryBuilder
{
    IQueryBuilder All<T>() where T : struct;
    IQueryBuilder One<T>() where T : struct;
    IQueryBuilder Exclude<T>() where T : struct;
    IEnumerable<IEntity> Build();
}
