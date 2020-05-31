using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Linq;

namespace Bomberman
{
    public partial class Info : Form
    {
        private static AboutGame mainWindow;
        private static readonly string infoPath = Path.Combine(Program.SlnPath, "Objects");
        private static readonly DirectoryInfo backgrounds = new DirectoryInfo(infoPath);
        private static FileInfo bombIcon = backgrounds.GetFiles("Bomb.png").First();
        private static FileInfo bonusesIcon = backgrounds.GetFiles("Bonuses.png").First();
        private static FileInfo doorIcon = backgrounds.GetFiles("Door.png").First();
        private static FileInfo dynamiteIcon = backgrounds.GetFiles("Dynamite.png").First();
        private static FileInfo playerIcon = backgrounds.GetFiles("Player.png").First();
        private static FileInfo plateIcon = backgrounds.GetFiles("Plate.png").First();
        private static FileInfo remoteControlIcon = backgrounds.GetFiles("RemoteControl.png").First();
        private static FileInfo robotsIcon = backgrounds.GetFiles("Robots.png").First();
        private static FileInfo forceFieldIcon = backgrounds.GetFiles("ForceField.png").First();
        private static FileInfo wallsIcon = backgrounds.GetFiles("Walls.png").First();
        
        public Info()
        {
            InitializeComponent();
        }
        
        public Info(AboutGame aboutGame)
        {
            mainWindow = aboutGame;
            InitializeComponent();
            ClientSize = mainWindow.Size;
        }

        public void SetRequiredBack(string name)
        {
            switch (name)
            {
                case "Bomb":
                    BackgroundImage = Image.FromFile(bombIcon.FullName);
                    Title.Text = "Бомба";
                    break;
                case "Bonuses":
                    BackgroundImage = Image.FromFile(bonusesIcon.FullName);
                    Title.Text = "Бонусы";
                    break;
                case "Door":
                    BackgroundImage = Image.FromFile(doorIcon.FullName);
                    Title.Text = "Дверь";
                    break;
                case "Dynamite":
                    BackgroundImage = Image.FromFile(dynamiteIcon.FullName);
                    Title.Text = "Динамит";
                    break;
                case "Player":
                    BackgroundImage = Image.FromFile(playerIcon.FullName);
                    Title.Text = "Игрок";
                    break;
                case "Plate":
                    BackgroundImage = Image.FromFile(plateIcon.FullName);
                    Title.Text = "Кнопка";
                    break;
                case "RemoteControl":
                    BackgroundImage = Image.FromFile(remoteControlIcon.FullName);
                    Title.Text = "Пульт управления";
                    break;
                case "Robots":
                    BackgroundImage = Image.FromFile(robotsIcon.FullName);
                    Title.Text = "Роботы";
                    break;
                case "ForceField":
                    BackgroundImage = Image.FromFile(forceFieldIcon.FullName);
                    Title.Text = "Силовое поле и блок";
                    break;
                case "Walls":
                    BackgroundImage = Image.FromFile(wallsIcon.FullName);
                    Title.Text = "Стены";
                    break;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            mainWindow.Show();
            Hide();
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