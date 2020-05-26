﻿using System;
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

        public static bool ContainsHole(this IEnumerable<ICreature> cell)
        {
            return cell.OfType<Hole>().Any();
        }
        
        public static bool ContainsMonster(this IEnumerable<ICreature> cell)
        {
            return cell.Any(creature => creature is Monster);
        }

        public static ICreature[] Array<T>() where T : ICreature, new() => new ICreature[] { new T() };
    }
}