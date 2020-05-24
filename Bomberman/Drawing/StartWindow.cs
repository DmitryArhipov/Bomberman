using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class StartWindow : Form
    {
        private static readonly string ImagesPath = Path.Combine(Program.ProjectPath, "Drawing", "Images");
        private static readonly Size ButtonSize = new Size(300, 70);
        public StartWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e) => Application.Exit();

        private void NewGame_Click(object sender, EventArgs e)
        {
            Hide();
            var gameWindow = new Window(this, new DirectoryInfo(ImagesPath));
            gameWindow.Show();
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

        private void Saving_Click(object sender, EventArgs e)
        {
        }
        private void StartWindow_Load(object sender, EventArgs e)
        {
        }

        private void AboutGame_Click(object sender, EventArgs e)
        {
        }

        private void Rules_Click(object sender, EventArgs e)
        {
        }
    }
}