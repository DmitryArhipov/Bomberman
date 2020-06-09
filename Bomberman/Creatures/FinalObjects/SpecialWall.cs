namespace Bomberman
{
    public class SpecialWall : ICreature
    {
        public string GetImageFileName() => "SpecialWall.png";
        
        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject) => false;
        
        public int GetDrawingPriority() => 5;
    }
}