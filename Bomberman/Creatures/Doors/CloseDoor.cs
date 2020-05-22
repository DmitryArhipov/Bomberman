namespace Bomberman.Doors
{
    public class CloseDoor : ICreature
    {
        public string GetImageFileName()
        {
            throw new System.NotImplementedException();
        }

        public CreatureCommand Act(int x, int y)
        {
            if (Game.MonstersCount == 0)
                return new CreatureCommand() { TransformTo = new[] { new OpenDoor() } };
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject) => false;
        
        public int GetDrawingPriority() => 100;
    }
}