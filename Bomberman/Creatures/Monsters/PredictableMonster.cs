using System;
using System.Diagnostics;
using System.Drawing;

namespace Bomberman
{
    public class PredictableMonster : ICreature
    {
        private int direction;
        private Stopwatch timer = Stopwatch.StartNew();
        private Point monsterCell;
        private const double SecondsBeforeGo = 1;
        public string GetImageFileName() => "PredictableMonster.png";

        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            monsterCell = new Point(x, y);
            if (direction == 0 && x + 1 < Game.MapWidth && !Game.Map[x + 1, y].ContainsObstaclesOrBomb()
                && !Game.Map[x + 1, y].ContainsMonster() && Game.WantToMoveMonster[x + 1, y] == false)
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(SecondsBeforeGo))
                {
                    timer = Stopwatch.StartNew();
                    Game.WantToMoveMonster[x, y] = false;
                    monsterCell.X++;
                    Game.WantToMoveMonster[x + 1, y] = true;
                    result.DeltaX = 1;
                }
            }
            else if (direction == 1 && y + 1 < Game.MapHeight && !Game.Map[x, y + 1].ContainsObstaclesOrBomb()
                     && !Game.Map[x, y + 1].ContainsMonster() && Game.WantToMoveMonster[x, y + 1] == false)
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(SecondsBeforeGo))
                {
                    timer = Stopwatch.StartNew();
                    Game.WantToMoveMonster[x, y] = false;
                    monsterCell.Y++;
                    Game.WantToMoveMonster[x, y + 1] = true;
                    result.DeltaY = 1;
                }
            }
            else if (direction == 2 && x > 0 && !Game.Map[x - 1, y].ContainsObstaclesOrBomb()
                     && !Game.Map[x - 1, y].ContainsMonster() && Game.WantToMoveMonster[x - 1, y] == false)
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(SecondsBeforeGo))
                {
                    timer = Stopwatch.StartNew();
                    Game.WantToMoveMonster[x, y] = false;
                    monsterCell.X--;
                    Game.WantToMoveMonster[x - 1, y] = true;
                    result.DeltaX = -1;
                }
            }
            else if (direction == 3 && y > 0 && !Game.Map[x, y - 1].ContainsObstaclesOrBomb()
                     && !Game.Map[x, y - 1].ContainsMonster() && Game.WantToMoveMonster[x, y - 1] == false)
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(SecondsBeforeGo))
                {
                    timer = Stopwatch.StartNew();
                    Game.WantToMoveMonster[x, y] = false;
                    monsterCell.Y--;
                    Game.WantToMoveMonster[x, y - 1] = true;
                    result.DeltaY = -1;
                }
            }
            else direction = (direction + 1) % 4;

                return result;
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