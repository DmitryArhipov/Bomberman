using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Bomberman
{
    public class Window : Form
    {
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        private readonly GameState gameState;
        private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();
        private int tickCount;
        private Button Pause;

        public Window(DirectoryInfo imagesDirectory = null)
        {
            gameState = new GameState();
            ClientSize = new Size(
                GameState.ElementSize * Game.MapWidth,
                GameState.ElementSize * Game.MapHeight + GameState.ElementSize / 2);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Pause = new Button();
            // Controls.Add(CloseButton);
            imagesDirectory ??= new DirectoryInfo("Images");
            foreach (var e in imagesDirectory.GetFiles("*.png"))
                bitmaps[e.Name] = (Bitmap) Image.FromFile(e.FullName);
            var timer = new Timer {Interval = 15};
            timer.Tick += TimerTick;
            timer.Start();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = "Bomberman";
            DoubleBuffered = true;
            Pause.Text = "X";
            Pause.BackColor = Color.Brown;
            Pause.FlatStyle = FlatStyle.Popup;
            Pause.Margin = new Padding(3, 2, 3, 2);
            Pause.Name = "CloseButton";
            Pause.Size = new Size(50, 20);
            Pause.TabIndex = 0;
            Pause.UseVisualStyleBackColor = true;
            Pause.Location = new Point(Width - Pause.Width, 0);
            Controls.Add(Pause);
            Pause.MouseClick += (sender, args) => Application.Exit();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Pause.Enabled = false;
            if (e.KeyCode == Keys.Z)
                Application.Exit(); // Чтобы можно было выйти из игры, потом уберу
            pressedKeys.Add(e.KeyCode);
            Game.KeyPressed = e.KeyCode;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            Pause.Enabled = false;
            pressedKeys.Remove(e.KeyCode);
            Game.KeyPressed = pressedKeys.Any() ? pressedKeys.Min() : Keys.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pause.Enabled = false;
            e.Graphics.TranslateTransform(0, 20);
            e.Graphics.FillRectangle(
                Brushes.ForestGreen, 0, 0, GameState.ElementSize * Game.MapWidth,
                GameState.ElementSize * Game.MapHeight);
            foreach (var a in gameState.Animations)
                e.Graphics.DrawImage(bitmaps[a.Creature.GetImageFileName()], a.Location);
            e.Graphics.ResetTransform();
            e.Graphics.DrawString("Level 1", new Font("Arial", 16), Brushes.Green, 0, 0);
        }

        private void TimerTick(object sender, EventArgs args)
        {
            if (tickCount == 0) gameState.BeginAct();
            foreach (var e in gameState.Animations)
                e.Location = new Point(e.Location.X + 4 * e.Command.DeltaX, e.Location.Y + 4 * e.Command.DeltaY);
            if (tickCount == 7)
                gameState.EndAct();
            tickCount++;
            if (tickCount == 8) tickCount = 0;
            Invalidate();
        }
    }
}