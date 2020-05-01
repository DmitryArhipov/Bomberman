using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomberman
{
    public class MapParser
    {
        public static ICreature[,][] GetMapFromText(string text)
        {
            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var map = new ICreature[lines[0].Length, lines.Length][];
            for (var y = 0; y < lines.Length; y++)
                for (var x = 0; x < lines[0].Length; x++)
                switch (lines[y][x])
                {
                    case 'P':
                        map[x,y] = new ICreature[]{ new Player() };
                        break;
                    case 'W':
                        map[x,y] = new ICreature[]{ new BreakableWall() };
                        break;
                    case '#':
                        map[x,y] = new ICreature[]{ new UnbreakableWall() };
                        break;
                    case 'M':
                        map[x,y] = new ICreature[]{ new PredictableMonster() };
                        break;
                    case ' ':
                        map[x,y] = new ICreature[]{};
                        break;
                    default:
                        throw new Exception($"wrong character for map {lines[y][x]}");
                }
            return map;
        }
    }
}