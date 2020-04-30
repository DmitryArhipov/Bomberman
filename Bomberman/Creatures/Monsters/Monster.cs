using System;
using System.Diagnostics;

namespace Bomberman
{
    public class Monster : ICreature
    {
        private int direction;
        private Stopwatch timer = Stopwatch.StartNew();
        public string GetImageFileName()
        {
            return "Monster.png";
        }

        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            if (direction == 0 && x + 1 < Game.MapWidth && !Game.Map[x + 1, y].IsWallOrBomb() &&
                !Game.Map[x + 1, y].IsMonster())
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(1))
                {
                    timer = Stopwatch.StartNew();
                    result.DeltaX = 1;
                }
            }
            else if (direction == 1 && y + 1 < Game.MapHeight && !Game.Map[x, y + 1].IsWallOrBomb() &&
                     !Game.Map[x, y + 1].IsMonster())
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(1))
                {
                    timer = Stopwatch.StartNew();
                    result.DeltaY = 1;
                }
            }
            else if (direction == 2 && x > 0 && !Game.Map[x - 1, y].IsWallOrBomb() && !Game.Map[x - 1, y].IsMonster())
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(1))
                {
                    timer = Stopwatch.StartNew();
                    result.DeltaX = -1;
                }
            }
            else if (direction == 3 && y > 0 && !Game.Map[x, y - 1].IsWallOrBomb() && !Game.Map[x, y - 1].IsMonster())
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(1))
                {
                    timer = Stopwatch.StartNew();
                    result.DeltaY = -1;
                }
            }
            else direction = (direction + 1) % 4;

            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Fire;
        }
        
        public int GetDrawingPriority()
        {
            return 100;
        }
    }
}