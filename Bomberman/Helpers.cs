using System.Collections.Generic;

namespace Bomberman
{
    public static class Helpers
    {
        public static bool IsWallOrBomb(this IEnumerable<ICreature> cell)
        {
            foreach (var creature in cell)
            {
                if (creature is Bomb || creature is BreakableWall || creature is UnbreakableWall)
                    return true;
            }
            return false;
        }
    }
}