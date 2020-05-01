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
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Fire;
        }
        
        public int GetDrawingPriority()
        {
            return 400;
        }
    }
}