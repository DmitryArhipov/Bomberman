using System;
using System.Diagnostics;

namespace Bomberman
{
    public class Bomb : ICreature
    {
        private readonly Player player;
        private readonly Stopwatch timer;
        private bool shouldExplode;
        public const double secondsBeforeExplosion = 2;
        
        public Bomb(Player player)
        {
            this.player = player;
            timer = Stopwatch.StartNew();
        }

        public string GetImageFileName() => "Bomb.png";

        public CreatureCommand Act(int x, int y)
        {
            if (timer.Elapsed >= TimeSpan.FromSeconds(secondsBeforeExplosion))
                shouldExplode = true;
            if (shouldExplode)
            {
                Game.WantToMoveMonster[x, y] = false;
                player.CurrentBombs--;
                return 
                    new CreatureCommand { TransformTo =
                        new[] {
                            new Fire(player.SplashLimit, Direction.Up), 
                            new Fire(player.SplashLimit, Direction.Down), 
                            new Fire(player.SplashLimit, Direction.Right), 
                            new Fire(player.SplashLimit, Direction.Left) } };
            }
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Fire)
                shouldExplode = true;
            return false;
        }

        public int GetDrawingPriority() => 6;
    }
}