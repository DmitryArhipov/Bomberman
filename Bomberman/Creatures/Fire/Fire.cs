using System;
using System.Diagnostics;

namespace Bomberman
{
    public class Fire : ICreature
    {
        private readonly Direction direction;
        private readonly int splashLimit;
        private Stopwatch timer;
        private int splashLengthNow;
        public const double secondsBeforeFly = 0.1;

        public Fire(int splashLimit, Direction direction)
        {
            this.splashLimit = splashLimit;
            this.direction = direction;
            timer = Stopwatch.StartNew();
        }

        public string GetImageFileName() => "Fire.png";
        
        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            if (timer.Elapsed >= TimeSpan.FromSeconds(secondsBeforeFly))
            {
                if (splashLengthNow == splashLimit)
                    return new CreatureCommand() {TransformTo = new ICreature[] { }};
                timer = Stopwatch.StartNew();
                splashLengthNow++;
                switch (direction)
                {
                    case Direction.Up:
                    {
                        result.DeltaY = -1;
                        break;
                    }
                    case Direction.Down:
                    {
                        result.DeltaY = 1;
                        break;
                    }
                    case Direction.Right:
                    {
                        result.DeltaX = 1;
                        break;
                    }
                    default:
                    {
                        result.DeltaX = -1;
                        break;
                    }
                }
            }

            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Bomb || conflictedObject is Dynamite || conflictedObject is BreakableWall
                                            || conflictedObject is UnbreakableWall;
        }

        public int GetDrawingPriority() => 2;
    }
}