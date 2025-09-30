using Charon.Math;

namespace Charon;

public interface IShape
{
    AABB GetAABB();
    Vector2[] GetPoints();
}
