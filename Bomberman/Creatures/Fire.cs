using System;
using System.Diagnostics;

namespace Bomberman
{
    public class Fire : ICreature
    {
        private readonly Player player;
        private Stopwatch timer;
        private readonly Direction direction;
        private int splashNow;

        public Fire(Player player, Direction direction)
        {
            this.player = player;
            this.direction = direction;
            timer = Stopwatch.StartNew();
        }
        
        public enum Direction
        {
            Right,
            Left,
            Up,
            Down
        }
        
        public string GetImageFileName()
        {
            return "Fire.png";
        }
        
        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            if (direction == Direction.Up)
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(0.3))
                {
                    if (splashNow == player.SplashLimit)
                        return new CreatureCommand() {TransformTo = new ICreature[] { }};
                    timer = Stopwatch.StartNew();
                    splashNow++;
                    result.DeltaY = -1;
                }
            }
            else if (direction == Direction.Down)
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(0.3))
                {
                    if (splashNow == player.SplashLimit)
                        return new CreatureCommand() {TransformTo = new ICreature[] { }};
                    timer = Stopwatch.StartNew();
                    splashNow++;
                    result.DeltaY = 1;
                }
            }
            else if (direction == Direction.Right)
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(0.3))
                {
                    if (splashNow == player.SplashLimit)
                        return new CreatureCommand() {TransformTo = new ICreature[] { }};
                    timer = Stopwatch.StartNew();
                    splashNow++;
                    result.DeltaX = 1;
                }
            }
            else
            {
                if (timer.Elapsed >= TimeSpan.FromSeconds(0.3))
                {
                    if(splashNow == player.SplashLimit)
                        return new CreatureCommand(){ TransformTo = new ICreature[] { } };
                    timer = Stopwatch.StartNew();
                    splashNow++;
                    result.DeltaX = -1;
                }
            }
            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Bomb || conflictedObject is UnbreakableWall;
        }
        
        public int GetDrawingPriority()
        {
            return 10;
        }
    }
}