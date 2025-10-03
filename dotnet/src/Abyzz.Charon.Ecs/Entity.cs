namespace Charon.Ecs;

internal readonly struct Entity(int id) : IEntity
{
    public int Id { get; } = id;
}
