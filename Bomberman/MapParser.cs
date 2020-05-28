using System;
using System.Collections.Generic;
using Bomberman.Bonuses;
using Bomberman.Doors;
using Bomberman.FinalObjects;

namespace Bomberman
{
    public static class MapParser
    {
        private static readonly HashSet<char> MonstersAsLetters = new HashSet<char>{'0', '1', '2', '3'};
    
        public static ICreature[,][] GetMapFromText(string text)
        {
            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var map = new ICreature[lines[0].Length, lines.Length][];
            var playersCount = 0;

            for (var y = 0; y < lines.Length; y++)
            {
                for (var x = 0; x < lines[0].Length; x++)
                {
                    if (lines[y][x] == 'P')
                        playersCount++;
                    if (MonstersAsLetters.Contains(lines[y][x]))
                        Game.MonstersCount++;
                    if (lines[y][x] == 'X')
                        Game.PlatesCount++;
                    
                    map[x, y] = lines[y][x] switch
                    {
                        'H' => Helpers.Array<Hole>(),
                        'X' => Helpers.Array<Plate>(),
                        'B' => Helpers.Array<Block>(),
                        'P' => Helpers.Array<Player>(),
                        'D' => Helpers.Array<Dynamite>(),
                        'O' => Helpers.Array<OpenDoor>(),
                        'C' => Helpers.Array<ClosedDoor>(),
                        'S' => Helpers.Array<SpecialWall>(),
                        'R' => Helpers.Array<RemoteControl>(),
                        'W' => Helpers.Array<BreakableWall>(),
                        '#' => Helpers.Array<UnbreakableWall>(),
                        '0' => Helpers.Array<PredictableMonster>(),
                        '1' => Helpers.Array<RandomMonster>(),
                        '2' => Helpers.Array<SmartMonster>(),
                        '3' => Helpers.Array<WideSearchMonster>(),
                        'Q' => new ICreature[] {new BreakableWall(), new ClosedDoor()},
                        'b' => Helpers.Array<PlusBomb>(),
                        's' => Helpers.Array<PlusSplash>(),
                        ' ' => new ICreature[] { },
                         _  => throw new ArgumentException($"wrong character for map {lines[y][x]}")
                    };
                }
            }
            
            if (playersCount != 1)
                throw new ArgumentException("There must be exactly 1 player on the map");

            return map;
        }
    }
}