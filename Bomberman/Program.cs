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
            Game.CreateMap();
            Application.Run(new Window(new DirectoryInfo(@"C:\Users\dasha\RiderProjects\BombermanNew\Bomberman\Drawing\Images")));
        }
    }
}
