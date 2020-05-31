using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Bomberman
{
    partial class Info
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
            Back = new Button();
            Title = new Label();
            //
            // Back
            //
            Back.FlatStyle = FlatStyle.Flat;
            Back.Font = new Font("Snowcard Gotic", 15F, FontStyle.Bold);
            Back.Margin = new Padding(3, 2, 3, 2);
            Back.Name = "Back";
            Back.Size = new Size(200, 40);
            Back.TabIndex = 0;
            Back.Text = "Назад";
            Back.UseVisualStyleBackColor = true;
            Back.FlatAppearance.BorderColor = Color.FromArgb(156, 34, 93);
            Back.BackColor = Color.FromArgb(213, 100, 124); 
            Back.Click += new System.EventHandler(this.Back_Click);
            //
            // Name
            //
            Title.BackColor = Color.Transparent;
            Title.Font = new Font("Elephant", 27F, FontStyle.Bold,
                GraphicsUnit.Point, ((byte) (0)));
            Title.ForeColor = Color.DeepPink; 
            Title.Name = "Title";
            Title.Size = new Size(500, 70);
            Title.TabStop = true;
            Title.BorderStyle = BorderStyle.None;
            Title.TextAlign = ContentAlignment.TopLeft;
            Title.AllowDrop = false;
            Title.Cursor = DefaultCursor;
            //
            // Info
            //
            AutoScaleMode = AutoScaleMode.Font;
            Text = "Info";
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            Size = new Size(900, 500);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Controls.Add(Back);
            Controls.Add(Title);
            StartPosition = FormStartPosition.CenterScreen;
            
            Title.Location = new Point(60, 80);
            Back.Location = new Point((Width - Back.Width) / 2, Height - Back.Height - 5);
        }

        #endregion

        private Button Back;
        private Label Title;
    }
}