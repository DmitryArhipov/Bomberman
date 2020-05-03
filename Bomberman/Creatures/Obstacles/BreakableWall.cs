namespace Bomberman
{
    public class BreakableWall : ICreature
    {
        public string GetImageFileName() => "BreakableWall.png";

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Fire;

        public int GetDrawingPriority() => 5;
    }
}