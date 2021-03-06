using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;

namespace Bomberman
{
    public abstract class Robot : ICreatureWithTimer
    {
        protected Point Position { get; set; }
        private static readonly string soundFile = Path.Combine(Program.SoundsPath, "robot.wav");
        
        protected Stopwatch Timer = Stopwatch.StartNew();
        private bool alive = true;

        public abstract string GetImageFileName();
        public abstract CreatureCommand Act(int x, int y);
        public int GetDrawingPriority() => 3;
        
        public bool DeadInConflict(ICreature conflictedObject)
        {
            var result = conflictedObject is Fire || conflictedObject is Block;
            
            if (alive && result)
            {
                if (Program.EnableSound && File.Exists(soundFile))
                {
                    new SoundPlayer(soundFile).Play();
                }
                Game.WantToMoveRobot[Position.X, Position.Y] = false;
                alive = false;
                Game.RobotsCount--;
            }

            return result;
        }

        public void Pause() => Timer.Stop();

        public void Unpause() => Timer.Start();
    }
}