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
            throw new System.NotImplementedException();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            throw new System.NotImplementedException();
        }
    }
}