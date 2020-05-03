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
                map[x, y] = lines[y][x] switch
                {
                    'P' => Helpers.Array<Player>(),
                    'W' => Helpers.Array<BreakableWall>(),
                    '#' => Helpers.Array<UnbreakableWall>(),
                    'M' => Helpers.Array<PredictableMonster>(),
                    'B' => new ICreature[] {new Bomb(null)},
                    ' ' => new ICreature[] { },
                    _ => throw new Exception($"wrong character for map {lines[y][x]}")
                };
            return map;
        }
    }
}