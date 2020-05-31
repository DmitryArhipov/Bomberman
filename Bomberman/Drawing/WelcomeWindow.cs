using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class WelcomeWindow : Form
    {
        private static Window game;
        public static FileInfo background = Window.Icons.GetFiles("WelcomeWindow.png").First();
        
        public WelcomeWindow()
        {
            InitializeComponent();
        }
        
        public WelcomeWindow(Window gameWindow)
        {
            game = gameWindow;
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (Next.Text == "Начать")
            {
                game.Show();
                game.gameState.Unpause();
                game.timer.Start();
                Hide();
            }
            if (storyLine.Count > 0)
            {
                Story.Text = storyLine.Dequeue();
                if (storyLine.Count == 0)
                    Next.Text = "Начать";
            }
        }

        private void Scip_Click(object sender, EventArgs e)
        {
            game.Show();
            game.gameState.Unpause();
            game.timer.Start();
            Hide();
        }
        
        protected override void OnClosed(EventArgs e)
        {
            Scip_Click(null, e);
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