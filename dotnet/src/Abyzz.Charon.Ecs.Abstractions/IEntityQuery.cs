namespace Charon.Ecs;

public interface IEntityQuery : IEnumerable<IEntity>
{
    int Count { get; }   
}
