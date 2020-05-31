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
            Hide();
        }
        
        protected override void OnClosed(EventArgs e)
        {
            Back_Click(null, e);
        }
        
        protected override CreateParams CreateParams 
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            } 
        }
    }
}