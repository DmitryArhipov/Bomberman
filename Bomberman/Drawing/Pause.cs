using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class Pause : Form
    {
        private StartWindow mainMenu;
        private Window game;
        public PauseBackground background;
        
        public Pause()
        {
            InitializeComponent();
        }

        public Pause(StartWindow startWindow, Window gameWindow)
        {
            mainMenu = startWindow;
            game = gameWindow;
            InitializeComponent();
            background = new PauseBackground(this);
        }
        
        protected override void OnClosed(EventArgs e)
        {
            BackInGame_Click(null, e);
        }

        private void BackInGame_Click(object sender, EventArgs e)
        {
            game.gameState.Unpause();
            game.timer.Start();
            background.Hide();
            Hide();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Program.SavePath, Game.Level.ToString());
        }

        private void InMainMenu_Click(object sender, EventArgs e)
        {
            game.Hide();
            background.Hide();
            Hide();
            Game.Level = 0;
            Program.LevelsToPlay.Clear();
            foreach (var level in Program.AllLevels)
            {
                Program.LevelsToPlay.Enqueue(level);
            }
            mainMenu.Show();
        }

        private void Exit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void VolumeButton_Click(object sender, EventArgs e)
        {
            if (Program.EnableSound)
            {
                VolumeButton.BackgroundImage = Image.FromFile(StartWindow.volumeMuteIcon.FullName);
                StartWindow.VolumeButton.BackgroundImage = Image.FromFile(StartWindow.volumeMuteIcon.FullName);
                Program.EnableSound = false;
            }
            else
            {
                VolumeButton.BackgroundImage = Image.FromFile(StartWindow.volumeIcon.FullName);
                StartWindow.VolumeButton.BackgroundImage = Image.FromFile(StartWindow.volumeIcon.FullName);
                Program.EnableSound = true;
            }
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