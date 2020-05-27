﻿using System.ComponentModel;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Bomberman
{
    partial class StartWindow
    {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(StartWindow));
            CloseButton = new Button();
            NewGame = new Button();
            Saving = new Button();
            AboutGame = new Button();
            Rules = new Button();
            VolumeButton = new Button();
            SuspendLayout();
            //
            // CloseButton
            // 
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Font = new Font("Snowcard Gotic", 15F);
            CloseButton.Margin = new Padding(3, 2, 3, 2);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = ButtonSize;
            CloseButton.TabIndex = 0;
            CloseButton.Text = "Выход";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.FlatAppearance.BorderColor = Color.DarkSlateBlue;
            CloseButton.BackColor = Color.SlateBlue; 
            CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // NewGame
            // 
            NewGame.FlatStyle = FlatStyle.Flat;
            NewGame.Font = new Font("Snowcard Gotic", 15F);
            NewGame.Margin = new Padding(3, 2, 3, 2);
            NewGame.Name = "NewGame";
            NewGame.Size = ButtonSize;
            NewGame.TabIndex = 1;
            NewGame.Text = "Новая игра";
            NewGame.UseVisualStyleBackColor = true;
            NewGame.FlatAppearance.BorderColor = Color.DarkSlateBlue;
            NewGame.BackColor = Color.SlateBlue;
            NewGame.Click += new System.EventHandler(this.NewGame_Click);
            //
            // Saving
            //
            Saving.FlatStyle = FlatStyle.Flat;
            Saving.Font = new Font("Snowcard Gotic", 15F); Saving.Margin = new Padding(3, 2, 3, 2);
            Saving.Name = "Saving";
            Saving.Size = ButtonSize;
            Saving.TabIndex = 2;
            Saving.Text = "Загрузка";
            Saving.UseVisualStyleBackColor = true;
            Saving.FlatAppearance.BorderColor = Color.DarkSlateBlue;
            Saving.BackColor = Color.SlateBlue;
            Saving.Click += new System.EventHandler(this.Saving_Click);
            //
            // AboutGame
            //
            AboutGame.FlatStyle = FlatStyle.Flat;
            AboutGame.Font = new Font("Snowcard Gotic", 15F);
            AboutGame.Margin = new Padding(3, 2, 3, 2);
            AboutGame.Name = "AboutGame";
            AboutGame.Size = ButtonSize;
            AboutGame.TabIndex = 3;
            AboutGame.Text = "Об Игре";
            AboutGame.UseVisualStyleBackColor = true;
            AboutGame.FlatAppearance.BorderColor = Color.DarkSlateBlue;
            AboutGame.BackColor = Color.SlateBlue;
            AboutGame.Click += new System.EventHandler(this.AboutGame_Click);
            //
            // Rules
            //
            Rules.FlatStyle = FlatStyle.Flat;
            Rules.Font = new Font("Snowcard Gotic", 15F);
            Rules.Margin = new Padding(3, 2, 3, 2);
            Rules.Name = "Rules";
            Rules.Size = ButtonSize;
            Rules.TabIndex = 4;
            Rules.Text = "Правила";
            Rules.UseVisualStyleBackColor = true;
            Rules.FlatAppearance.BorderColor = Color.DarkSlateBlue;
            Rules.BackColor = Color.SlateBlue;
            Rules.Click += new System.EventHandler(this.Rules_Click);
            //
            // VolumeButton
            //
            VolumeButton.Size = new Size(70, 70);
            if (Program.EnableSound)
                VolumeButton.BackgroundImage = Image.FromFile(StartWindow.volumeIcon.FullName);
            else
                VolumeButton.BackgroundImage = Image.FromFile(StartWindow.volumeMuteIcon.FullName);
            VolumeButton.BackgroundImageLayout = ImageLayout.Stretch;
            VolumeButton.FlatStyle = FlatStyle.Popup;
            VolumeButton.FlatAppearance.BorderColor = Color.DarkSlateGray;
            VolumeButton.TabStop = true;
            VolumeButton.Name = "VolumeButton";
            VolumeButton.Click += new System.EventHandler(this.VolumeButton_Click);
            // 
            // StartWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = ((Image) (resources.GetObject("$this.BackgroundImage")));
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(2000, 1000);
            Controls.Add(NewGame);
            Controls.Add(CloseButton);
            Controls.Add(Saving);
            Controls.Add(AboutGame);
            Controls.Add(Rules);
            Controls.Add(VolumeButton);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "StartWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StartWindow";
            Load += new System.EventHandler(this.StartWindow_Load);
            ResumeLayout(false);

            NewGame.Location = new Point((Width - NewGame.Width) / 2,
                Height / 2 - ButtonSize.Height - 20);
            Saving.Location = new Point((Width - Saving.Width) / 2,
                NewGame.Location.Y + 45);
            AboutGame.Location = new Point((Width - Saving.Width) / 2,
                Saving.Location.Y + 45);
            Rules.Location = new Point((Width - Saving.Width) / 2, 
                AboutGame.Location.Y + 45);
            CloseButton.Location = new Point((Width - NewGame.Width) / 2,
                Rules.Location.Y + 45);
            VolumeButton.Location = new Point(Width - VolumeButton.Width, 0);
        }

        #endregion

        private Button CloseButton;
        private Button NewGame;
        private Button Saving;
        private Button AboutGame;
        private Button Rules;
        public static Button VolumeButton;
    }
}

