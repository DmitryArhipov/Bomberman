namespace Bomberman
{
    public class Monster : ICreature
    {
        public string GetImageFileName()
        {
            return "Monster.png";
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