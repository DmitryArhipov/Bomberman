using System.Drawing;

namespace Bomberman
{
    public abstract class Monster : ICreature
    {
        protected Point Position { get; set; }

        public abstract string GetImageFileName();
        public abstract CreatureCommand Act(int x, int y);
        public int GetDrawingPriority() => 3;

        public bool Alive = true;
        
        public bool DeadInConflict(ICreature conflictedObject)
        {
            var result = conflictedObject is Fire || conflictedObject is Block;
            
            if (Alive && result)
            {
                Game.WantToMoveMonster[Position.X, Position.Y] = false;
                Alive = false;
                Game.MonstersCount--;
            }

            return result;
        }
    }
}