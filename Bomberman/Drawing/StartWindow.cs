using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class StartWindow : Form
    {
        private static readonly string ImagesPath = Path.Combine(Program.SlnPath, "Images");
        private static readonly Size ButtonSize = new Size(300, 70);
        public static FileInfo volumeIcon = Window.Icons.GetFiles("Volume.png").First();
        public static FileInfo volumeMuteIcon = Window.Icons.GetFiles("VolumeMute.png").First();
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

        private void Saving_Click(object sender, EventArgs e)
        {
            if (File.Exists(Program.SavePath))
            {
                var save = File.ReadAllText(Program.SavePath);
                if (int.TryParse(save, out var levelId))
                    for (int i = 0; i < levelId; i++)
                    {
                        Program.LevelsToPlay.Dequeue();
                        Game.Level++;
                    }
            }
            Hide();
            var gameWindow = new Window(this, new DirectoryInfo(ImagesPath));
            gameWindow.Show();
        }

        private void AboutGame_Click(object sender, EventArgs e)
        {
        }

        private void Rules_Click(object sender, EventArgs e)
        {
        }

        private void VolumeButton_Click(object sender, EventArgs e)
        {
            if (Program.EnableSound)
            {
                VolumeButton.BackgroundImage = Image.FromFile(volumeMuteIcon.FullName);
                VolumeButton.BackgroundImageLayout = ImageLayout.Stretch;
                Program.EnableSound = false;
            }
            else
            {
                VolumeButton.BackgroundImage = Image.FromFile(volumeIcon.FullName);
                VolumeButton.BackgroundImageLayout = ImageLayout.Stretch;
                Program.EnableSound = true;
            }
        }

        private void StartWindow_Load(object sender, EventArgs e)
        {
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