using System;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class CongratsWindow : Form
    {
        private static Window game;
        private static FileInfo background = Window.Icons.GetFiles("Congrats.jpg").First();
        private static readonly string soundFile = Path.Combine(Program.SoundsPath, "win.wav");
        private SoundPlayer player;
        
        public CongratsWindow()
        {
            InitializeComponent();
            
            if (File.Exists(soundFile) && Program.EnableSound)
            {
                player = new SoundPlayer(soundFile);
                player.Play();
            }
        }
        
        public CongratsWindow(Window gameWindow)
        {
            game = gameWindow;
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            game.gameState.Unpause();
            game.timer.Start();
            Hide();
        }
        
        protected override void OnClosed(EventArgs e)
        {
            Next_Click(null, e);
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