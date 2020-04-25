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
            throw new System.NotImplementedException();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            throw new System.NotImplementedException();
        }
    }
}