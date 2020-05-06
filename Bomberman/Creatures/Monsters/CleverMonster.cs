using System.Diagnostics;
using System.Drawing;

namespace Bomberman
{
    public class CleverMonster : ICreature
    {
        private Stopwatch timer = Stopwatch.StartNew();
        private Point monsterCell;
        public string GetImageFileName() => "PredictableMonster.png"; // заменить картинку

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            Game.WantToMoveMonster[monsterCell.X, monsterCell.Y] = false;
            return conflictedObject is Fire;
        }
        
        public int GetDrawingPriority() => 3;
    }
}