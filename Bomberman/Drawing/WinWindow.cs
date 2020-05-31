using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class WinWindow : Form
    {
        private static FileInfo backgroundImage = Window.Icons.GetFiles("WinWindow.jpg").First();
        private static StartWindow mainMenu;
        public WinWindow()
        {
            InitializeComponent();
        }
        
        public WinWindow(StartWindow startWindow)
        {
            mainMenu = startWindow;
            InitializeComponent();
        }
        
        private void Exit_Click(object sender, EventArgs e) => Application.Exit();
        
        private void InMainMenu_Click(object sender, EventArgs e)
        {
            Hide();
            mainMenu.Show();
        }
        
        protected override void OnClosed(EventArgs e)
        {
            Environment.Exit(0);
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