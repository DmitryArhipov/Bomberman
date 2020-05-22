namespace Bomberman
{
    public class Block : ICreature
    {
        private Direction direction;
        private bool hit;
        
        public string GetImageFileName()
        {
            throw new System.NotImplementedException();
        }

        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Fire)
            {
                direction = (conflictedObject as Fire).direction;
                hit = true;
            }
            return false;
        }
        
        public int GetDrawingPriority() => 1;
    }
}