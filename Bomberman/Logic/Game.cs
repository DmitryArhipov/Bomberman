﻿using System.Windows.Forms;

namespace Bomberman
{
    public class Game
    {
        public static ICreature[,][] Map;
        public static bool IsOver;
        public static bool CanGoToNextLevel;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        public static bool[,] WantToMoveMonster;
        public static int MonstersCount;
        public static int Level = 1;
        public static bool IsPlayerDead;
        
        public static void CreateMap(string map)
        {
            Map = MapParser.GetMapFromText(map);
            WantToMoveMonster = new bool[MapWidth, MapHeight];
        }
    }
}