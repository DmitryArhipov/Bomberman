using System;
using System.Diagnostics;

namespace Bomberman
{
    public class Bomb : ICreature
    {
        private readonly Player player;
        private readonly Stopwatch timer;
        private bool shouldExplode;

        public Bomb(Player player)
        {
            this.player = player;
            timer = Stopwatch.StartNew();
        }

        public string GetImageFileName() => "Bomb.png";

        public CreatureCommand Act(int x, int y)
        {
            if (timer.Elapsed >= TimeSpan.FromSeconds(2) || shouldExplode)
            {
                player.CurrentBombs--;
                return new CreatureCommand() { TransformTo = new[] { new Fire(player, Fire.Direction.Up),
                    new Fire(player, Fire.Direction.Down), new Fire(player, Fire.Direction.Right),
                    new Fire(player, Fire.Direction.Left) } };
            }
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Fire)
                shouldExplode = true;
            return false;
        }

        public int GetDrawingPriority() => 500;
    }
}