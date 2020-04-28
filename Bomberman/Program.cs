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
        [STAThread]
        static void Main()
        {
            var path = Directory.GetCurrentDirectory();
            var projectPath = Path.Combine(path, "..", "..");
            var imagesPath = Path.Combine(projectPath, "Drawing", "Images");
            
            Game.CreateMap();
            Application.Run(new Window(new DirectoryInfo(imagesPath)));
        }
    }
}
