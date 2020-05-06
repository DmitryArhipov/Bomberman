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
        public const double secondsBeforeGo = 1;
        public string GetImageFileName() => "PredictableMonster.png";

        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            monsterCell = new Point(x, y);
            switch (direction)
            {
                case 0 when x + 1 < Game.MapWidth && !Game.Map[x + 1, y].ContainsWallOrBomb()
                                                  && !Game.Map[x + 1, y].ContainsMonster() && Game.WantToMoveMonster[x + 1, y] == false:
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(secondsBeforeGo))
                    {
                        timer = Stopwatch.StartNew();
                        Game.WantToMoveMonster[x, y] = false;
                        monsterCell.X++;
                        Game.WantToMoveMonster[x + 1, y] = true;
                        result.DeltaX = 1;
                    }
                    break;
                }
                case 1 when y + 1 < Game.MapHeight && !Game.Map[x, y + 1].ContainsWallOrBomb()
                                                   && !Game.Map[x, y + 1].ContainsMonster() && Game.WantToMoveMonster[x, y + 1] == false:
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(secondsBeforeGo))
                    {
                        timer = Stopwatch.StartNew();
                        Game.WantToMoveMonster[x, y] = false;
                        monsterCell.Y++;
                        Game.WantToMoveMonster[x, y + 1] = true;
                        result.DeltaY = 1;
                    }
                    break;
                }
                case 2 when x > 0 && !Game.Map[x - 1, y].ContainsWallOrBomb()
                                  && !Game.Map[x - 1, y].ContainsMonster() && Game.WantToMoveMonster[x - 1, y] == false:
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(secondsBeforeGo))
                    {
                        timer = Stopwatch.StartNew();
                        Game.WantToMoveMonster[x, y] = false;
                        monsterCell.X--;
                        Game.WantToMoveMonster[x - 1, y] = true;
                        result.DeltaX = -1;
                    }
                    break;
                }
                case 3 when y > 0 && !Game.Map[x, y - 1].ContainsWallOrBomb()
                                  && !Game.Map[x, y - 1].ContainsMonster() && Game.WantToMoveMonster[x, y - 1] == false:
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(secondsBeforeGo))
                    {
                        timer = Stopwatch.StartNew();
                        Game.WantToMoveMonster[x, y] = false;
                        monsterCell.Y--;
                        Game.WantToMoveMonster[x, y - 1] = true;
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

        public bool DeadInConflict(ICreature conflictedObject)
        {
            Game.WantToMoveMonster[monsterCell.X, monsterCell.Y] = false;
            return conflictedObject is Fire;
        }

        public int GetDrawingPriority() => 3;
    }
}