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
        public static readonly string SlnPath = Directory.GetCurrentDirectory();
        public static readonly string ProjectPath = Path.Combine(SlnPath, "..", "..");
        //private static readonly string MapsPath = Path.Combine(ProjectPath, "Maps");

        [STAThread]
        static void Main()
        {
            Game.CreateMap(Game.MapExample);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartWindow());
        }
    }
}
