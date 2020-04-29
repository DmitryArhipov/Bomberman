using System.Windows.Forms;

namespace Bomberman
{
    public class Player : ICreature
    {
        public int BombsLimit = 1;
        public int CurrentBombs;
        private string ImageName = "running-right-2.png";
        
        private void ChangeImageName(Keys keys)
        {
            if(keys == Keys.None)
                return;
            var current = ImageName.Split('-');
            var i= int.Parse(current[2][0].ToString());
            var direction = (keys == Keys.Right || keys == Keys.Down)
                ? "right" : "left";
            var j = (i + 1) % 2 + 1;
            ImageName = $"running-{direction}-{j}.png";
        }
        
        public string GetImageFileName()
        {
            return ImageName;
        }

        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            ChangeImageName(Game.KeyPressed);
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
                    if (CurrentBombs < BombsLimit && !Game.Map[x,y].IsWallOrBomb())
                    {
                        result.TransformTo = new ICreature[] {this, new Bomb(this)};
                        CurrentBombs++; // ToDo: при взрыве в классе бомбы говорить Player.CurrentBombs--
                    }
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