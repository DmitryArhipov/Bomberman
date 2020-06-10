using System.Windows.Forms;
using System;
using System.IO;
using System.Linq;

namespace Bomberman
{
    public partial class HintControl : UserControl
    {
        private Window game;
        
        public HintControl(Window game)
        {
            InitializeComponent();
            Hide();
            this.game = game;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            game.gameState.Unpause();
            game.timer.Start();
            Hide();
            game.Focus();
        }

        public void SetHintText()
        {
            if (Game.Hint1)
            {
                HintText.Text = hint1;
                Game.Hint1 = false;
            }
            
            if (Game.Hint2)
            {
                HintText.Text = hint2;
                Game.Hint2 = false;
            }
            
            if (Game.Hint3)
            {
                HintText.Text = hint3;
                Game.Hint3 = false;
            }
            
            if (Game.Hint4)
            {
                HintText.Text = hint4;
                Game.Hint4 = false;
            }
            
            if (Game.Hint5)
            {
                HintText.Text = hint5;
                Game.Hint5 = false;
            }
        }
    }
}