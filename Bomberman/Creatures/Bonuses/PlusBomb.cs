namespace Bomberman.Bonuses
{
    public class PlusBomb : ICreature
    {
        public string GetImageFileName()
        {
            throw new System.NotImplementedException();
        }
        
        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
                (conflictedObject as Player).BombsLimit++;
            return true;
        }
        
        public int GetDrawingPriority() => 5;
    }
}