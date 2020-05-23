namespace Bomberman
{
    public class Dynamite : ICreature
    {
        private bool shouldExplode;

        public string GetImageFileName() => "Dynamite.png";

        public CreatureCommand Act(int x, int y)
        {
            if (shouldExplode)
            {
                return 
                    new CreatureCommand() { TransformTo =
                        new[] {
                            new Fire(100, Direction.Up), 
                            new Fire(100, Direction.Down),
                            new Fire(100, Direction.Right), 
                            new Fire(100, Direction.Left) } };
            }
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Fire)
                shouldExplode = true;
            return false;
        }
        
        public int GetDrawingPriority() => 5;
    }
}