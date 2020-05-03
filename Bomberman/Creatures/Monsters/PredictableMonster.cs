using System;
using System.Diagnostics;

namespace Bomberman
{
    public class PredictableMonster : ICreature
    {
        private int direction;
        private Stopwatch timer = Stopwatch.StartNew();
        public string GetImageFileName() => "PredictableMonster.png";

        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            switch (direction)
            {
                case 0 when x + 1 < Game.MapWidth && !Game.Map[x + 1, y].ContainsWallOrBomb() && !Game.Map[x + 1, y].ContainsMonster():
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(1))
                    {
                        timer = Stopwatch.StartNew();
                        result.DeltaX = 1;
                    }
                    break;
                }
                case 1 when y + 1 < Game.MapHeight && !Game.Map[x, y + 1].ContainsWallOrBomb() && !Game.Map[x, y + 1].ContainsMonster():
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(1))
                    {
                        timer = Stopwatch.StartNew();
                        result.DeltaY = 1;
                    }
                    break;
                }
                case 2 when x > 0 && !Game.Map[x - 1, y].ContainsWallOrBomb() && !Game.Map[x - 1, y].ContainsMonster():
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(1))
                    {
                        timer = Stopwatch.StartNew();
                        result.DeltaX = -1;
                    }
                    break;
                }
                case 3 when y > 0 && !Game.Map[x, y - 1].ContainsWallOrBomb() && !Game.Map[x, y - 1].ContainsMonster():
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(1))
                    {
                        timer = Stopwatch.StartNew();
                        result.DeltaY = -1;
                    }
                    break;
                }
                default:
                    direction = (direction + 1) % 4;
                    break;
            }
            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Fire;

        public int GetDrawingPriority() => 3;
    }
}