using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class Rules : Form
    {
        private static StartWindow mainMenu;
        private static FileInfo background = Window.Icons.GetFiles("Rules.png").First();
        
        public Rules()
        {
            InitializeComponent();
        }

        public Rules(StartWindow startWindow)
        {
            mainMenu = startWindow;
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            mainMenu.Show();
            Close();
        }
    }
}