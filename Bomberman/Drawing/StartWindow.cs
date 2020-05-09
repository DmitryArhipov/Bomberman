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
            var gameWindow = new Window(new DirectoryInfo(ImagesPath));
            gameWindow.Show();
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