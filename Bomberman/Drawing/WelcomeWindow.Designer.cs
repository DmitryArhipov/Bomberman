using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Bomberman
{
    partial class WelcomeWindow
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
            storyLine = new Queue<string>();
            storyLine.Enqueue("       Однажды Бомбермен случайно узнал, что фабрика находится под контролем" +
                              " алчной и жестокой правительственной верхушки, и бомбы, к выпуску которых он " +
                              "имел непосредственное отношение, идут на достижение её коварных замыслов.");
            storyLine.Enqueue("       Тогда-то он решил во что бы то ни стало остановить производство и покинуть это место.\r\n       Поддержки в лице коллег-роботов Бомбермен не нашел, зато кто-то донёс на него руководству." +
                              "Теперь все рабочие настроены против него.");
            storyLine.Enqueue("       Ваша задача – помочь Бомберменy достичь его благой цели и, преодолевая противостояние бывших коллег и препятствия, заготовленные ему руководством, добраться до комнаты с пультом управления, который остановит производство и отключит всех роботов.");
            storyLine.Enqueue("       Уже сейчас за тобой начата погоня! Скорее убегай от разъярённых рабочих в открытую дверь, вооружайся своими логикой и терпением, и вперед проходить испытания!");
            Next = new Button();
            Scip = new Button();
            Story = new Label();
            SuspendLayout();
            //
            // Story
            //
            Story.BackColor = Color.Transparent;
            Story.Font = new Font("Latin", 13.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte) (0)));
            Story.ForeColor = Color.Black;
            Story.BorderStyle = BorderStyle.FixedSingle;
            Story.TabStop = true;
            Story.Name = "PauseText";
            Story.Size = new Size(700, 400);
            Story.TabStop = true;
            Story.Text = "       Знакомьтесь: Бомбермен.\r\n" +
                         "       Как только он сошел с конвейера родного завода, его забрали и привезли на фабрику по производству бомб. " +
                         "Всю свою жизнь он провел здесь, отлаживая процессы и выполняя грязную работу наряду с такими же, как он, роботами.";
            Story.BorderStyle = BorderStyle.None;
            Story.TextAlign = ContentAlignment.MiddleLeft;
            Story.AllowDrop = false;
            Story.Cursor = DefaultCursor;
            //
            // Start
            //
            Next.FlatStyle = FlatStyle.Flat;
            Next.Font = new Font("Latin", 17F);
            Next.Margin = new Padding(3, 2, 3, 2);
            Next.Name = "Next";
            Next.Size = new Size(350, 80);
            Next.TabIndex = 0;
            Next.Text = "Далее";
            Next.UseVisualStyleBackColor = true;
            Next.FlatAppearance.BorderColor = Color.FromArgb(156, 34, 93);
            Next.BackColor = Color.FromArgb(213, 100, 124); 
            Next.Click += new System.EventHandler(this.Next_Click);
            //
            // Back
            //
            Scip.FlatStyle = FlatStyle.Flat;
            Scip.Font = new Font("Latin", 16F);
            Scip.Margin = new Padding(3, 2, 3, 2);
            Scip.Name = "Scip";
            Scip.Size = new Size(350, 80);
            Scip.TabIndex = 1;
            Scip.Text = "Пропустить";
            Scip.UseVisualStyleBackColor = true;
            Scip.FlatAppearance.BorderColor = Color.FromArgb(156, 34, 93);
            Scip.BackColor = Color.FromArgb(213, 100, 124); 
            Scip.Click += new System.EventHandler(this.Scip_Click);
            // 
            // WelcomeWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            TransparencyKey = Color.SlateGray;
            BackgroundImage = Image.FromFile(background.FullName);
            BackgroundImageLayout = ImageLayout.Stretch;
            Size = new Size(900, 600);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "WelcomeWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WelcomeWindow";
            TopMost = true;
            Controls.Add(Story);
            Controls.Add(Next);
            Controls.Add(Scip);
            ResumeLayout(false);
            
            Story.Location = new Point(10, 10);
            Next.Location = new Point(Width - Scip.Width - 35, Height - Scip.Height - 20);
            Scip.Location = new Point(35, Height - Next.Height - 20);
        }

        #endregion

        private Queue<string> storyLine;
        private Button Next;
        private Button Scip;
        private Label Story;
    }
}