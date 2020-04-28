using System.Linq;
using System.Windows.Forms;

namespace Bomberman
{
    public class Player : ICreature
    {
        public string GetImageFileName()
        {
            return "running-right-2.png";
        }

        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            switch (Game.KeyPressed)
            {
                case Keys.Right:
                    if (x + 1 < Game.MapWidth && !Game.Map[x + 1, y].IsWallOrBomb())
                        result.DeltaX = 1;
                    break;
                case Keys.Left:
                    if (x > 0 && !Game.Map[x - 1, y].IsWallOrBomb())
                        result.DeltaX = -1;
                    break;
                case Keys.Down:
                    if (y + 1 < Game.MapHeight && !Game.Map[x, y + 1].IsWallOrBomb())
                        result.DeltaY = 1;
                    break;
                case Keys.Up:
                    if (y > 0 && !Game.Map[x, y - 1].IsWallOrBomb())
                        result.DeltaY = -1;
                    break;
                case Keys.Space:
                    Game.Map[x, y] = Game.Map[x, y].Append(new Bomb());
                    break;
            }
            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Fire || conflictedObject is Monster;
        }
    }
}