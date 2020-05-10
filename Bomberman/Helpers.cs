﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomberman
{
    public static class Helpers
    {
        public static bool ContainsObstaclesOrBomb(this IEnumerable<ICreature> cell)
        {
            return cell.Any(creature => creature is Bomb || creature is BreakableWall
                                                         || creature is UnbreakableWall || creature is Dynamite);
        }

        public static bool ContainsUnbreakableWall(this IEnumerable<ICreature> cell)
        {
            return cell.OfType<UnbreakableWall>().Any();
        }
        
        public static bool ContainsMonster(this IEnumerable<ICreature> cell)
        {
            return cell.Any(creature => creature is PredictableMonster || creature is CleverMonster);
        }

        public static ICreature[] Array<T>() where T : ICreature, new() => new ICreature[] { new T() };
    }
}