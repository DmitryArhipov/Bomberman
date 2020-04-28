namespace Bomberman
{
    public class UnbreakableWall : ICreature
    {
        public string GetImageFileName()
        {
            return "UnbreakableWall.png";
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