namespace Bomberman
{
    public class UnbreakableWall : ICreature
    {
        public string GetImageFileName() => "UnbreakableWall.png";

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject) => false;

        public int GetDrawingPriority() => 10;
    }
}