using System;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class CongratsControl : UserControl
    {
        private static Window game;
        private static FileInfo background = Window.Icons.GetFiles("Congrats.jpg").First();
        private static readonly string soundFile = Path.Combine(Program.SoundsPath, "win.wav");
        private SoundPlayer player;
        
        public CongratsControl()
        {
            InitializeComponent();
        }
        
        public CongratsControl(Window gameWindow)
        {
            game = gameWindow;
            InitializeComponent();
            if (File.Exists(soundFile) && Program.EnableSound)
            {
                player = new SoundPlayer(soundFile);
                player.Play();
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            game.gameState.Unpause();
            game.timer.Start();
            Hide();
            game.Focus();
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