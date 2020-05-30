namespace Bomberman
{
    public class ForceField : ICreature
    {
        public string GetImageFileName() => "ForceField.png";

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject) => false;
        
        public int GetDrawingPriority() => 5;
    }
}