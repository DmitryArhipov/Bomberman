using System.Windows.Forms;

namespace Bomberman
{
    public static class Game
    {
        private const string MapExample = "P"; // убрать

        public static ICreature[,] Map;
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