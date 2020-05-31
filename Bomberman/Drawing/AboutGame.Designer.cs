using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Bomberman
{
    partial class AboutGame
    {
        private static FileInfo bombIcon = Window.Icons.GetFiles("Bomb.png").First();
        private static FileInfo background = Window.Icons.GetFiles("AboutGame.png").First();
        private static FileInfo bonusesIcon = Window.Icons.GetFiles("Bonuses.png").First();
        private static FileInfo doorIcon = Window.Icons.GetFiles("Door.png").First();
        private static FileInfo dynamiteIcon = Window.Icons.GetFiles("Dynamite.png").First();
        private static FileInfo playerIcon = Window.Icons.GetFiles("Player.png").First();
        private static FileInfo plateIcon = Window.Icons.GetFiles("Plate.png").First();
        private static FileInfo remoteControlIcon = Window.Icons.GetFiles("RemoteControl.png").First();
        private static FileInfo robotsIcon = Window.Icons.GetFiles("Robots.png").First();
        private static FileInfo forceFieldIcon = Window.Icons.GetFiles("ForceField.png").First();
        private static FileInfo wallsIcon = Window.Icons.GetFiles("Walls.png").First();
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Back = new Button();
            Bomb = new Button();
            Bonuses = new Button();
            Door = new Button();
            Dynamite = new Button();
            Player = new Button();
            Plate = new Button();
            RemoteControl = new Button();
            Robots = new Button();
            ForceField = new Button();
            Walls = new Button();
            //
            // ButtonPattern
            //
            var flatStyle = FlatStyle.Flat;
            var backgroundImageLayot = ImageLayout.Stretch;
            var margin = new Padding(3, 2, 3, 2);
            var size = new Size(115, 115);
            var borderColor = Color.DeepPink;
            var backColor = Color.Wheat;
            //
            // Bomb
            //
            Bomb.FlatStyle = flatStyle;
            Bomb.BackgroundImage = Image.FromFile(bombIcon.FullName);
            Bomb.BackgroundImageLayout = backgroundImageLayot;
            Bomb.Margin = margin;
            Bomb.Name = "Bomb";
            Bomb.Size = size;
            Bomb.TabIndex = 0;
            Bomb.FlatAppearance.BorderColor = borderColor;
            Bomb.UseVisualStyleBackColor = true;
            Bomb.BackColor = backColor;
            Bomb.Click += new System.EventHandler(this.Bomb_Click);
            //
            // Bonuses
            //
            Bonuses.FlatStyle = flatStyle;
            Bonuses.BackgroundImage = Image.FromFile(bonusesIcon.FullName);
            Bonuses.BackgroundImageLayout = backgroundImageLayot;
            Bonuses.Margin = margin;
            Bonuses.Name = "Bonuses";
            Bonuses.Size = size;
            Bonuses.TabIndex = 1;
            Bonuses.FlatAppearance.BorderColor = borderColor;
            Bonuses.UseVisualStyleBackColor = true;
            Bonuses.BackColor = backColor; 
            Bonuses.Click += new System.EventHandler(this.Bonuses_Click);
            //
            // Door
            //
            Door.FlatStyle = flatStyle;
            Door.BackgroundImage = Image.FromFile(doorIcon.FullName);
            Door.BackgroundImageLayout = backgroundImageLayot;
            Door.Margin = margin;
            Door.Name = "Door";
            Door.Size = size;
            Door.TabIndex = 2;
            Door.FlatAppearance.BorderColor = borderColor;
            Door.UseVisualStyleBackColor = true;
            Door.BackColor = backColor; 
            Door.Click += new System.EventHandler(this.Door_Click);
            //
            // Dynamite
            //
            Dynamite.FlatStyle = flatStyle;
            Dynamite.BackgroundImage = Image.FromFile(dynamiteIcon.FullName);
            Dynamite.BackgroundImageLayout = backgroundImageLayot;
            Dynamite.Margin = margin;
            Dynamite.Name = "Dynamite";
            Dynamite.Size = size;
            Dynamite.TabIndex = 3;
            Dynamite.FlatAppearance.BorderColor = borderColor;
            Dynamite.UseVisualStyleBackColor = true;
            Dynamite.BackColor = backColor; 
            Dynamite.Click += new System.EventHandler(this.Dynamite_Click);
            //
            // Player
            //
            Player.FlatStyle = flatStyle;
            Player.BackgroundImage = Image.FromFile(playerIcon.FullName);
            Player.BackgroundImageLayout = backgroundImageLayot;
            Player.Margin = margin;
            Player.Name = "Player";
            Player.Size = size;
            Player.TabIndex = 4;
            Player.FlatAppearance.BorderColor = borderColor;
            Player.UseVisualStyleBackColor = true;
            Player.BackColor = backColor; 
            Player.Click += new System.EventHandler(this.Player_Click);
            //
            // Plate
            //
            Plate.FlatStyle = flatStyle;
            Plate.BackgroundImage = Image.FromFile(plateIcon.FullName);
            Plate.BackgroundImageLayout = backgroundImageLayot;
            Plate.Margin = margin;
            Plate.Name = "Plate";
            Plate.Size = size;
            Plate.TabIndex = 5;
            Plate.FlatAppearance.BorderColor = borderColor;
            Plate.UseVisualStyleBackColor = true;
            Plate.BackColor = backColor; 
            Plate.Click += new System.EventHandler(this.Plate_Click);
            //
            // RemoteControl
            //
            RemoteControl.FlatStyle = flatStyle;
            RemoteControl.BackgroundImage = Image.FromFile(remoteControlIcon.FullName);
            RemoteControl.BackgroundImageLayout = backgroundImageLayot;
            RemoteControl.Margin = margin;
            RemoteControl.Name = "RemoteControl";
            RemoteControl.Size = size;
            RemoteControl.TabIndex = 6;
            RemoteControl.FlatAppearance.BorderColor = borderColor;
            RemoteControl.UseVisualStyleBackColor = true;
            RemoteControl.BackColor = backColor; 
            RemoteControl.Click += new System.EventHandler(this.RemoteControl_Click);
            //
            // Robots
            //
            Robots.FlatStyle = flatStyle;
            Robots.BackgroundImage = Image.FromFile(robotsIcon.FullName);
            Robots.BackgroundImageLayout = backgroundImageLayot;
            Robots.Margin = margin;
            Robots.Name = "Robots";
            Robots.Size = size;
            Robots.TabIndex = 7;
            Robots.FlatAppearance.BorderColor = borderColor;
            Robots.UseVisualStyleBackColor = true;
            Robots.BackColor = backColor; 
            Robots.Click += new System.EventHandler(this.Robots_Click);
            //
            // ForceField
            //
            ForceField.FlatStyle = flatStyle;
            ForceField.BackgroundImage = Image.FromFile(forceFieldIcon.FullName);
            ForceField.BackgroundImageLayout = backgroundImageLayot;
            ForceField.Margin = margin;
            ForceField.Name = "ForceField";
            ForceField.Size = size;
            ForceField.TabIndex = 8;
            ForceField.FlatAppearance.BorderColor = borderColor;
            ForceField.UseVisualStyleBackColor = true;
            ForceField.BackColor = backColor; 
            ForceField.Click += new System.EventHandler(this.ForceField_Click);
            //
            // Walls
            //
            Walls.FlatStyle = flatStyle;
            Walls.BackgroundImage = Image.FromFile(wallsIcon.FullName);
            Walls.BackgroundImageLayout = backgroundImageLayot;
            Walls.Margin = margin;
            Walls.Name = "Walls";
            Walls.Size = size;
            Walls.TabIndex = 9;
            Walls.FlatAppearance.BorderColor = borderColor;
            Walls.UseVisualStyleBackColor = true;
            Walls.BackColor = backColor; 
            Walls.Click += new System.EventHandler(this.Walls_Click);
            //
            // Back
            //
            Back.FlatStyle = FlatStyle.Flat;
            Back.Font = new Font("Snowcard Gotic", 15F, FontStyle.Bold);
            Back.Margin = new Padding(3, 2, 3, 2);
            Back.Name = "Back";
            Back.Size = new Size(200, 40);
            Back.TabIndex = 10;
            Back.Text = "Назад";
            Back.UseVisualStyleBackColor = true;
            Back.FlatAppearance.BorderColor = Color.FromArgb(156, 34, 93);
            Back.BackColor = Color.FromArgb(213, 100, 124); 
            Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // AboutGame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Image.FromFile(background.FullName);
            BackgroundImageLayout = ImageLayout.Stretch;
            Size = new Size(900, 500);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "AboutGame";
            Controls.Add(Back);
            Controls.Add(Bomb);
            Controls.Add(Bonuses);
            Controls.Add(Door);
            Controls.Add(Dynamite);
            Controls.Add(Player);
            Controls.Add(Plate);
            Controls.Add(RemoteControl);
            Controls.Add(Robots);
            Controls.Add(ForceField);
            Controls.Add(Walls);
            StartPosition = FormStartPosition.CenterScreen;
            
            Back.Location = new Point((Width - Back.Width) / 2, Height - Back.Height - 5);
            Bomb.Location = new Point(64, 76);
            Bonuses.Location = new Point(Bomb.Location.X + 153, Bomb.Location.Y);
            Door.Location = new Point(Bonuses.Location.X + 167, Bomb.Location.Y);
            Dynamite.Location = new Point(Door.Location.X + 175, Bomb.Location.Y);
            Player.Location = new Point(Dynamite.Location.X + 161, Bomb.Location.Y);
            Plate.Location = new Point(Bomb.Location.X, Bomb.Location.Y + 180);
            RemoteControl.Location = new Point(Bonuses.Location.X, Plate.Location.Y);
            Robots.Location = new Point(Door.Location.X, Plate.Location.Y);
            ForceField.Location = new Point(Dynamite.Location.X, Plate.Location.Y);
            Walls.Location = new Point(Player.Location.X, Plate.Location.Y);
        }

        #endregion

        private Button Back;
        private Button Bomb;
        private Button Bonuses;
        private Button Door;
        private Button Dynamite;
        private Button Player;
        private Button Plate;
        private Button RemoteControl;
        private Button Robots;
        private Button ForceField;
        private Button Walls;
    }
}