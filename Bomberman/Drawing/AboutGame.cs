using System;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class AboutGame : Form
    {
        private static StartWindow mainMenu;
        private static Info info;
        
        public AboutGame()
        {
            InitializeComponent();
        }

        public AboutGame(StartWindow startWindow)
        {
            mainMenu = startWindow;
            InitializeComponent();
            info = new Info(this);
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

        private void Bomb_Click(object sender, EventArgs e)
        {
            info.SetRequiredBack("Bomb");
            Hide();
            info.Show();
        }

        private void Bonuses_Click(object sender, EventArgs e)
        {
            info.SetRequiredBack("Bonuses");
            Hide();
            info.Show();
        }

        private void Door_Click(object sender, EventArgs e)
        {
            info.SetRequiredBack("Door");
            Hide();
            info.Show();
        }

        private void Dynamite_Click(object sender, EventArgs e)
        {
            info.SetRequiredBack("Dynamite");
            Hide();
            info.Show();
        }

        private void Player_Click(object sender, EventArgs e)
        {
            info.SetRequiredBack("Player");
            Hide();
            info.Show();
        }

        private void Plate_Click(object sender, EventArgs e)
        {
            info.SetRequiredBack("Plate");
            Hide();
            info.Show();
        }

        private void RemoteControl_Click(object sender, EventArgs e)
        {
            info.SetRequiredBack("RemoteControl");
            Hide();
            info.Show();
        }

        private void Robots_Click(object sender, EventArgs e)
        {
            info.SetRequiredBack("Robots");
            Hide();
            info.Show();
        }

        private void ForceField_Click(object sender, EventArgs e)
        {
            info.SetRequiredBack("ForceField");
            Hide();
            info.Show();
        }

        private void Walls_Click(object sender, EventArgs e)
        {
            info.SetRequiredBack("Walls");
            Hide();
            info.Show();
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