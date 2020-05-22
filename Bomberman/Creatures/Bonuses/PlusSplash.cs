namespace Bomberman.Bonuses
{
    public class PlusSplash : ICreature
    {
        public string GetImageFileName()
        {
            throw new System.NotImplementedException();
        }

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
                (conflictedObject as Player).SplashLimit++; 
            return true;
        }
        
        public int GetDrawingPriority() => 5;
    }
}