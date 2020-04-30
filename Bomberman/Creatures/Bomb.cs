using System;
using System.Diagnostics;

namespace Bomberman
{
    public class Bomb : ICreature
    {
        private readonly Player player;
        private readonly Stopwatch timer;
        private bool inFire;

        public Bomb(Player player)
        {
            this.player = player;
            timer = Stopwatch.StartNew();
        }
        
        public string GetImageFileName()
        {
            return "Bomb.png";
        }

        public CreatureCommand Act(int x, int y)
        {
            if (timer.Elapsed >= TimeSpan.FromSeconds(2) || inFire)
            {
                player.CurrentBombs--;
                return new CreatureCommand(){ TransformTo = new[] { new Fire() , new Fire(), new Fire(), new Fire() } };
            }
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Fire)
                inFire = true;
            return false;
        }
        
        public int GetDrawingPriority()
        {
            return 500;
        }
    }
}