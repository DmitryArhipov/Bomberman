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
        
        public string GetImageFileName() => "Fire.png";
        
        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            switch (direction)
            {
                case Direction.Up:
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(0.1))
                    {
                        if (splashNow == player.SplashLimit)
                            return new CreatureCommand() {TransformTo = new ICreature[] { }};
                        timer = Stopwatch.StartNew();
                        splashNow++;
                        result.DeltaY = -1;
                    }
                    break;
                }
                case Direction.Down:
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(0.1))
                    {
                        if (splashNow == player.SplashLimit)
                            return new CreatureCommand() {TransformTo = new ICreature[] { }};
                        timer = Stopwatch.StartNew();
                        splashNow++;
                        result.DeltaY = 1;
                    }
                    break;
                }
                case Direction.Right:
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(0.1))
                    {
                        if (splashNow == player.SplashLimit)
                            return new CreatureCommand() {TransformTo = new ICreature[] { }};
                        timer = Stopwatch.StartNew();
                        splashNow++;
                        result.DeltaX = 1;
                    }
                    break;
                }
                default:
                {
                    if (timer.Elapsed >= TimeSpan.FromSeconds(0.1))
                    {
                        if(splashNow == player.SplashLimit)
                            return new CreatureCommand(){ TransformTo = new ICreature[] { } };
                        timer = Stopwatch.StartNew();
                        splashNow++;
                        result.DeltaX = -1;
                    }
                    break;
                }
            }
            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Bomb 
                                                                  || conflictedObject is BreakableWall 
                                                                  || conflictedObject is UnbreakableWall;

        public int GetDrawingPriority() => 100;
    }
}