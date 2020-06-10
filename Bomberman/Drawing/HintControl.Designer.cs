using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Bomberman
{
    partial class HintControl
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

        #region Component Designer generated code
        private static string hint1 = "Уничтожай роботов бомбами.\r\nПоставить бомбу - клавиша пробел. Она взорвется через 2 секунды после того, как ты её установишь.";
        private static string hint2 = "Собирай бонусы и увеличивай радиус взрыва своих бомб и их количество, которое можно поставить за раз.\r\nЭти параметры в данный момент можно отслеживать на верхней панели.";
        private static string hint3 = "Ставь бомбу рядом с динамитом и взрывай его! Но будь осторожен: динамит не имеет ограничений по радиусу взрыва.";
        private static string hint4 = "Ставь бомбу рядом с передвижным блоком и двигай его с помощью силы взрыва.\r\nБлок давит монстров и игрока.\r\n Интересно, что будет, если они одновременно поедут в одну клетку?";
        private static string hint5 = "Нажми все кнопки, чтобы открыть дверь.\r\nКнопки нажимаются с помощью блоков. Не обязательно держать блок на кнопке после нажатия.";
        private void InitializeComponent()
        {
            OK = new Button();
            HintTitle = new Label();
            HintText = new Label();
            //
            // HintText
            //
            HintText.BackColor = Color.Transparent;
            HintText.Font = new Font("Latin", 13.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0)));
            HintText.ForeColor = Color.Cyan;
            HintText.BorderStyle = BorderStyle.FixedSingle;
            HintText.TabStop = true;
            HintText.Name = "PauseText";
            HintText.Size = new Size(450, 250);
            HintText.TabStop = true;
            HintText.BorderStyle = BorderStyle.None;
            HintText.TextAlign = ContentAlignment.TopCenter;
            HintText.AllowDrop = false;
            HintText.Cursor = DefaultCursor;
            //
            // HintTitle
            //
            HintTitle.BackColor = Color.Transparent;
            HintTitle.Font = new Font("Elephant", 36F, FontStyle.Bold,
                GraphicsUnit.Point, ((byte) (0)));
            HintTitle.ForeColor = Color.Cyan;
            HintTitle.Name = "HintTitle";
            HintTitle.Size = new Size(400, 60);
            HintTitle.TabStop = true;
            HintTitle.Text = "ПОДСКАЗКА";
            HintTitle.BorderStyle = BorderStyle.None;
            HintTitle.TextAlign = ContentAlignment.TopCenter;
            HintTitle.AllowDrop = false;
            HintTitle.Cursor = DefaultCursor;
            //
            // Next
            //
            OK.FlatStyle = FlatStyle.Flat;
            OK.Font = new Font("Snowcard Gotic", 15F);
            OK.Margin = new Padding(3, 2, 3, 2);
            OK.Name = "OK";
            OK.Size = new Size(200, 40);
            OK.TabIndex = 0;
            OK.Text = "Продолжить";
            OK.UseVisualStyleBackColor = true;
            OK.BackColor = Color.Cyan;
            OK.FlatAppearance.BorderColor = Color.DarkCyan;
            OK.Click += new System.EventHandler(this.OK_Click);
            //
            // Congrats
            //
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(120, Color.Black);
            Size = new Size(500, 300);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HintWindow";
            Controls.Add(OK);
            Controls.Add(HintTitle);
            Controls.Add(HintText);

            OK.Location = new Point((this.Width - OK.Width) / 2, this.Height - OK.Height - 10);
            HintTitle.Location = new Point((Width - HintTitle.Width) / 2, 0);
            HintText.Location = new Point(25, 100);
        }

        #endregion

        private Button OK;
        private Label HintTitle;
        private static Label HintText;
    }
}