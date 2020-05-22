using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Windows.Forms;

namespace Bomberman
{
    public class Game
    {
        public const string MapExample = @"
############
#P         #
# #WWWWWW W#
# #WW#WWW W#
# #WW   M W#
# #WW W#WWW#
# #WW WWM#W#
#         M#
############"; // убрать
        public static ICreature[,][] Map;
        public static bool IsOver;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        public static bool[,] WantToMoveMonster;
        public static int MonstersCount;
        public static bool PlayerIsDead;
        
        public static void CreateMap(string map)
        {
            Map = MapParser.GetMapFromText(map);
            WantToMoveMonster = new bool[MapWidth, MapHeight];
        }
    }
}