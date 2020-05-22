using System;
using System.Collections.Generic;
using System.Linq;
using Bomberman.Doors;

namespace Bomberman
{
    public static class Helpers
    {
        public static bool ContainsObstaclesOrBomb(this IEnumerable<ICreature> cell)
        {
            return cell.Any(creature => creature is Bomb || creature is BreakableWall || creature is UnbreakableWall
                                        || creature is Dynamite || creature is Block);
        }

        public static bool ContainsUnbreakableWall(this IEnumerable<ICreature> cell)
        {
            return cell.OfType<UnbreakableWall>().Any();
        }

        public static bool ContainsDoor(this IEnumerable<ICreature> cell)
        {
            return cell.Any(creature => creature is CloseDoor || creature is OpenDoor);
        }
        
        public static bool ContainsMonster(this IEnumerable<ICreature> cell)
        {
            return cell.Any(creature => creature is PredictableMonster || creature is SmartMonster);
        }

        public static ICreature[] Array<T>() where T : ICreature, new() => new ICreature[] { new T() };
    }
}