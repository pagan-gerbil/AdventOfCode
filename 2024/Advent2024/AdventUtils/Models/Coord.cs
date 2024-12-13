using System.Diagnostics;

namespace AdventUtils.Models;

[DebuggerDisplay("x = {X} y = {Y}")]
public class Coord(long x, long y)
{
    public long X { get; } = x;
    public long Y { get; } = y;

    public override bool Equals(object? obj)
    {
        if (obj != null && obj is Coord c)
        {
            return this.X == c.X && this.Y == c.Y;
        }

        return false;
    }

    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7) + X.GetHashCode();
        hash = (hash * 7) + Y.GetHashCode();

        return hash;
    }
}
