using System.Diagnostics;
using System.Drawing;

namespace Bomberman
{
    public abstract class Monster : ICreatureWithTimer
    {
        protected Point Position { get; set; }
        
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
                Game.WantToMoveMonster[Position.X, Position.Y] = false;
                alive = false;
                Game.MonstersCount--;
            }

            return result;
        }

        public void Pause() => Timer.Stop();

        public void Unpause() => Timer.Start();
    }
}