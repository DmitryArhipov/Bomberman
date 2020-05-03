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
        private static readonly string SlnPath = Directory.GetCurrentDirectory();
        private static readonly string ProjectPath = Path.Combine(SlnPath, "..", "..");
        private static readonly string ImagesPath = Path.Combine(ProjectPath, "Drawing", "Images");
        private static readonly string MapsPath = Path.Combine(ProjectPath, "Maps");
        
        
        [STAThread]
        static void Main()
        {
            Game.CreateMap(Game.MapExample);
            Application.Run(new Window(new DirectoryInfo(ImagesPath)));
        }
    }
}
