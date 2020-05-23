namespace Bomberman
{
    public class Block : ICreature
    {
        private Direction direction;
        private bool fireHit;

        public string GetImageFileName() => "Block.png";

        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            if (fireHit)
            {
                fireHit = false;
                switch (direction)
                {
                    case Direction.Up:
                    {
                        if (y > 0 && !Game.Map[x, y - 1].ContainsObstaclesOrBomb())
                            result.DeltaY = -1;
                        break;
                    }
                    case Direction.Down:
                    {
                        if (y + 1 < Game.MapHeight && !Game.Map[x, y + 1].ContainsObstaclesOrBomb())
                            result.DeltaY = 1;
                        break;
                    }
                    case Direction.Right:
                    {
                        if (x + 1 < Game.MapWidth && !Game.Map[x + 1, y].ContainsObstaclesOrBomb())
                            result.DeltaX = 1;
                        break;
                    }
                    default:
                    {
                        if (x > 0 && !Game.Map[x - 1, y].ContainsObstaclesOrBomb())
                            result.DeltaX = -1;
                        break;
                    }
                }
            }

            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Fire)
            {
                direction = (conflictedObject as Fire).direction;
                fireHit = true;
            }
            return false;
        }
        
        public int GetDrawingPriority() => 1;
    }
}