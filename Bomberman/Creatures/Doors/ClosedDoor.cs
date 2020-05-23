namespace Bomberman.Doors
{
    public class ClosedDoor : ICreature
    {
        private bool fireHit;
        public string GetImageFileName() => "ClosedDoor.png";

        public CreatureCommand Act(int x, int y)
        {
            if (fireHit)
            {
                fireHit = false;
                return
                    new CreatureCommand { TransformTo =
                        new ICreature[] {
                            new ClosedDoor(),
                            new PredictableMonster() } };
            }
            return Game.MonstersCount == 0 
                ? new CreatureCommand { TransformTo = new[] { new OpenDoor() } } 
                : new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject) => false;
        
        public int GetDrawingPriority() => 100;
    }
}