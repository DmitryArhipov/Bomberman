namespace Bomberman
{
    public class Bomb : ICreature
    {
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