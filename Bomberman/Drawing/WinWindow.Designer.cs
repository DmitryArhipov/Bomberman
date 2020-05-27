using System.ComponentModel;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Bomberman
{
    partial class WinWindow
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
            WinText = new Label();
            CloseButton = new Button();
            SuspendLayout();
            //
            // CloseButton
            // 
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Font = new Font("Snowcard Gotic", 15F);
            CloseButton.Margin = new Padding(3, 2, 3, 2);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(80, 50);
            CloseButton.TabIndex = 0;
            CloseButton.Text = "X";
            CloseButton.Font = new Font(FontFamily.GenericSerif, 9F);
            CloseButton.BackColor = Color.Red;
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.FlatAppearance.BorderColor = Color.Brown;
            CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // WinText
            // 
            WinText.BackColor = Color.ForestGreen;
            WinText.Font = new Font("Showcard Gothic", 48F, FontStyle.Bold,
                GraphicsUnit.Point, ((byte) (0)));
            WinText.Location = new Point(125, 135);
            WinText.Name = "WinText";
            WinText.Size = new Size(550, 130);
            WinText.TabStop = true;
            WinText.Text = "YOU WIN";
            WinText.BorderStyle = BorderStyle.None;
            WinText.TextAlign = ContentAlignment.TopCenter;
            WinText.Cursor = DefaultCursor;
            // 
            // WinWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(800, 400);
            ControlBox = false;
            Controls.Add(this.WinText);
            Controls.Add(CloseButton);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "WinWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WinWindow";
            ResumeLayout(false);
            PerformLayout();
            
            CloseButton.Location = new Point(this.Width - CloseButton.Width, 0);
        }

        #endregion

        private Label WinText;
        private Button CloseButton;
    }
}