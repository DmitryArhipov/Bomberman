namespace Bomberman.FinalObjects
{
    public class RemoteControl : ICreature
    {
        public string GetImageFileName() => "RemoteControl.png";
        
        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            var result = conflictedObject is Player;
            if (result)
                Game.IsRemoteControl = true;

            return result;
        }
        
        public int GetDrawingPriority() => 5;
    }
}