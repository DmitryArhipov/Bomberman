using System;
using System.Collections.Generic;
using Bomberman.Bonuses;
using Bomberman.Doors;

namespace Bomberman
{
    public static class MapParser
    {
        private static readonly HashSet<char> MonstersAsLetters = new HashSet<char>{'M', 'S'};
    
        public static ICreature[,][] GetMapFromText(string text)
        {
            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var map = new ICreature[lines[0].Length, lines.Length][];

            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[0].Length; x++)
                {
                    if (MonstersAsLetters.Contains(lines[y][x]))
                        Game.MonstersCount++;
                    
                    map[x, y] = lines[y][x] switch
                    {
                        'B' => Helpers.Array<Block>(),
                        'P' => Helpers.Array<Player>(),
                        'D' => Helpers.Array<Dynamite>(),
                        'C' => Helpers.Array<ClosedDoor>(),
                        'S' => Helpers.Array<WideSearchMonster>(),
                        'W' => Helpers.Array<BreakableWall>(),
                        '#' => Helpers.Array<UnbreakableWall>(),
                        'M' => Helpers.Array<PredictableMonster>(),
                        'Q' => new ICreature[] {new BreakableWall(), new ClosedDoor()},
                        'b' => Helpers.Array<PlusBomb>(),
                        's' => Helpers.Array<PlusSplash>(),
                        ' ' => new ICreature[] { },
                         _  => throw new Exception($"wrong character for map {lines[y][x]}")
                    };
                }
            }

            return map;
        }
    }
}