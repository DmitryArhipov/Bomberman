namespace Bomberman
{
    public class Hole : ICreature
    {
        public string GetImageFileName() => "Hole.png";

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject) => false;
        
        public int GetDrawingPriority() => 5;
    }
}