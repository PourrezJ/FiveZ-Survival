using AltV.Net.Data;

namespace FiveZ.Utils.Extensions
{
    public static class PositionExtensions
    {
        public static float Distance2D(this Position point, Position position)
        {
            Position lhs = new Position(point.X, point.Y, 0.0f);
            Position rhs = new Position(position.X, position.Y, 0.0f);

            return lhs.Distance(rhs);
        }
    }
}
