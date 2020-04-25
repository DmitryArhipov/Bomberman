namespace Bomberman
{
    public class BreakableWall : ICreature
    {
        public string GetImageFileName()
        {
            return "BreakableWall.png";
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