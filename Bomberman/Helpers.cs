using System.Collections.Generic;
using System.Linq;

namespace Bomberman
{
    public static class Helpers
    {
        public static bool IsWallOrBomb(this IEnumerable<ICreature> cell)
        {
            return cell.Any(creature => creature is Bomb || creature is BreakableWall || creature is UnbreakableWall);
        }

        public static bool IsFire(this IEnumerable<ICreature> cell)
        {
            return cell.OfType<Fire>().Any();
        }
        
        public static bool IsMonster(this IEnumerable<ICreature> cell)
        {
            return cell.OfType<Monster>().Any();
        }
    }
}