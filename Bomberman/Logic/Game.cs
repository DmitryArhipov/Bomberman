﻿using System.Windows.Forms;

namespace Bomberman
{
    public static class Game
    {
        public static ICreature[,][] Map;
        public static bool IsOver;
        public static bool CanGoToNextLevel;
        public static bool IsRemoteControl;
        public static bool RemoteControlInMap;

        public static bool Prompt1;
        public static bool Prompt2;
        public static bool Prompt3;
        public static bool Prompt4;
        public static bool Prompt5;
        
        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        public static bool[,] WantToMoveRobot;
        public static int RobotsCount;
        public static int PlatesCount;
        public static int Level;
        public static bool IsPlayerDead;

        public static void CreateMap(string map)
        {
            RobotsCount = 0;
            PlatesCount = 0;
            Map = MapParser.GetMapFromText(map);
            WantToMoveRobot = new bool[MapWidth, MapHeight];
        }
    }
}