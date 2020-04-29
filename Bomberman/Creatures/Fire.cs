namespace Bomberman
{
    public class Fire : ICreature
    {
        public string GetImageFileName()
        {
            return "Fire.png";
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }
        
        public int GetDrawingPriority()
        {
            return 10;
        }
    }
}