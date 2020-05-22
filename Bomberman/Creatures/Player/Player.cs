﻿using System.Windows.Forms;

namespace Bomberman
{
    public class Player : ICreature
    {
        public int BombsLimit = 1;
        public int SplashLimit = 1;
        public int CurrentBombs;
        private string ImageName = "running-right.png";
        
        private void ChangeImageName(Keys keys)
        {
            if (keys == Keys.None)
                return;
            var direction = (keys == Keys.Right || keys == Keys.Down)
                ? "right" 
                : "left";
            ImageName = $"running-{direction}.png";
        }

        public string GetImageFileName() => ImageName;

        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            ChangeImageName(Game.KeyPressed);
            switch (Game.KeyPressed)
            {
                case Keys.Right:
                    if (x + 1 < Game.MapWidth && !Game.Map[x + 1, y].ContainsObstaclesOrBomb())
                        result.DeltaX = 1;
                    break;
                case Keys.Left:
                    if (x > 0 && !Game.Map[x - 1, y].ContainsObstaclesOrBomb())
                        result.DeltaX = -1;
                    break;
                case Keys.Down:
                    if (y + 1 < Game.MapHeight && !Game.Map[x, y + 1].ContainsObstaclesOrBomb())
                        result.DeltaY = 1;
                    break;
                case Keys.Up:
                    if (y > 0 && !Game.Map[x, y - 1].ContainsObstaclesOrBomb())
                        result.DeltaY = -1;
                    break;
                case Keys.Q:
                    if (CurrentBombs < BombsLimit && !Game.Map[x,y].ContainsObstaclesOrBomb() && Game.WantToMoveMonster[x, y] == false)
                    {
                        result.TransformTo = new ICreature[] {this, new Bomb(this)};
                        CurrentBombs++;
                    }
                    break;
            }
            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Fire || conflictedObject is PredictableMonster || conflictedObject is SmartMonster
                   || conflictedObject is Block;
        }

        public int GetDrawingPriority() => 4;
    }
}