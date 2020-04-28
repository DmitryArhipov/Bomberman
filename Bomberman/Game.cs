using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Windows.Forms;

namespace Bomberman
{
    public static class Game
    {
        private const string MapExample = @"
###########
#         #
#  M      #
#P       W#
###########"; // убрать
        
        public static readonly DirectoryInfo Maps = new DirectoryInfo(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Maps"));
        
        public static IEnumerable<ICreature>[,] Map;
        public static bool IsOver;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);

        public static void CreateMap()
        {
            Map = MapParser.GetMapFromText(MapExample);
        }
    }
}