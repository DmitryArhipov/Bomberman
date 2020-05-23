using System.Diagnostics;
using System.Drawing;

namespace Bomberman
{
    public class SmartMonster : ICreature
    {
        private Stopwatch timer = Stopwatch.StartNew();
        private Point monsterCell;
        public string GetImageFileName() => "SmartMonster.png";

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            var result = conflictedObject is Fire || conflictedObject is Block;
            if (result)
            {
                Game.WantToMoveMonster[monsterCell.X, monsterCell.Y] = false;
                Game.MonstersCount--;
            }
            return result;
        }
        
        public int GetDrawingPriority() => 3;
    }
}