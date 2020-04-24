namespace Bomberman
{
    public class Bomb : ICreature
    {
        public string GetImageFileName()
        {
            throw new System.NotImplementedException();
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