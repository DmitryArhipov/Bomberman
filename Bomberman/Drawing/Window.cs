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
        public readonly GameState gameState;
        private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();
        private int tickCount;
        public Timer timer = new Timer {Interval = 15};
        private StartWindow mainMenu;
        private Pause pause;

        public Window(StartWindow startWindow, DirectoryInfo imagesDirectory = null)
        {
            mainMenu = startWindow;
            gameState = new GameState();
            ClientSize = new Size(
                GameState.ElementSize * Game.MapWidth,
                GameState.ElementSize * Game.MapHeight + GameState.ElementSize / 2);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            imagesDirectory ??= new DirectoryInfo("Images");
            foreach (var e in imagesDirectory.GetFiles("*.png"))
                bitmaps[e.Name] = (Bitmap) Image.FromFile(e.FullName);
            timer.Tick += TimerTick;
            timer.Start();
            pause = new Pause(mainMenu, this);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = "Bomberman";
            DoubleBuffered = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                timer.Stop();
                tickCount = 0;
                pause.background.Show();
                pause.Show();
                gameState.Pause();
                Game.KeyPressed = Keys.None;
                pressedKeys.Clear();
            }
            else
            {
                pressedKeys.Add(e.KeyCode);
                Game.KeyPressed = e.KeyCode;
            }
        }
        
        protected override void OnKeyUp(KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
            Game.KeyPressed = pressedKeys.Any() ? pressedKeys.Min() : Keys.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, 23);
            e.Graphics.FillRectangle(
                Brushes.Wheat, 0, 0, GameState.ElementSize * Game.MapWidth,
                GameState.ElementSize * Game.MapHeight);
            foreach (var a in gameState.Animations)
                e.Graphics.DrawImage(bitmaps[a.Creature.GetImageFileName()], a.Location);
            e.Graphics.ResetTransform();
            e.Graphics.DrawString($"Level {Game.Level}", new Font("Arial", 16), Brushes.Black, 0, 0);
        }

        private void TimerTick(object sender, EventArgs args)
        {
            if (Game.IsOver)
            {
                Close();
                var winWindow = new WinWindow();
                winWindow.Show();
                timer.Stop();
            }
            if (tickCount == 0) gameState.BeginAct();
            foreach (var e in gameState.Animations)
                e.Location = new Point(e.Location.X + 4 * e.Command.DeltaX, e.Location.Y + 4 * e.Command.DeltaY);
            if (tickCount == 7)
                gameState.EndAct();
            tickCount++;
            if (tickCount == 8) tickCount = 0;
            Invalidate();
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