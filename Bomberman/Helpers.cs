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

        public static bool IsUnbreakableWall(this IEnumerable<ICreature> cell)
        {
            return cell.OfType<UnbreakableWall>().Any();
        }
        
        public static bool IsMonster(this IEnumerable<ICreature> cell)
        {
            return cell.OfType<PredictableMonster>().Any();
        }
    }
}