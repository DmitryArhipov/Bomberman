namespace Bomberman.Doors
{
    public class OpenDoor : ICreature
    {
        public string GetImageFileName()
        {
            throw new System.NotImplementedException();
        }
        
        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject) => false;
        
        public int GetDrawingPriority() => 100;
    }
}