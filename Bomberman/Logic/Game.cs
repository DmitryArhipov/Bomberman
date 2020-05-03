using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Windows.Forms;

namespace Bomberman
{
    public static class Game
    {
        public const string MapExample = @"
###########
#         #
#  M      #
#P       W#
###########"; // убрать

        public static ICreature[,][] Map;
        public static bool IsOver;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);

        public static void CreateMap(string map)
        {
            Map = MapParser.GetMapFromText(map);
        }
    }
}