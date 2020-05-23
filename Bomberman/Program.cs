using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bomberman
{
    static class Program
    {
        public static string currentLevel;
        public static Queue<string> levels = new Queue<string>();
        public static readonly string SlnPath = Directory.GetCurrentDirectory();
        public static readonly string ProjectPath = Path.Combine(SlnPath, "..", "..");
        private static readonly string MapsPath = Path.Combine(ProjectPath, "Maps");
        private static readonly DirectoryInfo Maps = new DirectoryInfo(MapsPath);

        [STAThread]
        static void Main()
        {
            foreach (var level in Maps.GetFiles("*txt"))
            {
                using StreamReader sr = level.OpenText();
                levels.Enqueue(sr.ReadToEnd());
            }

            currentLevel = levels.Dequeue();
            Game.CreateMap(currentLevel);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartWindow()); 
        }
    }
}
