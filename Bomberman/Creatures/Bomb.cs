namespace Bomberman
{
    public class Bomb : ICreature
    {
        private readonly Player player;

        public Bomb(Player player)
        {
            this.player = player;
        }
        public string GetImageFileName()
        {
            return "Bomb.png";
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }
    }
}