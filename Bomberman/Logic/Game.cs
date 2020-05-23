using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Windows.Forms;

namespace Bomberman
{
    public class Game
    {
        public static ICreature[,][] Map;
        public static bool IsOver = false;
        public static bool CanGoToNextLevel = false;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        public static bool[,] WantToMoveMonster;
        public static int MonstersCount;
        public static int Level = 1;
        public static bool PlayerIsDead;
        
        public static void CreateMap(string map)
        {
            Map = MapParser.GetMapFromText(map);
            WantToMoveMonster = new bool[MapWidth, MapHeight];
        }
    }
}