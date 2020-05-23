namespace Bomberman.Doors
{
    public class OpenDoor : ICreature
    {
        public string GetImageFileName() => "OpenDoor.png";
        
        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
                Game.CanGoToNextLevel = true;
            return false;
        }

        public int GetDrawingPriority() => 100;
    }
}