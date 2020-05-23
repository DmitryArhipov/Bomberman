namespace Bomberman.Doors
{
    public class OpenDoor : ICreature
    {
        private bool fireHit;

        public string GetImageFileName() => "OpenDoor.png";
        
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
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Fire)
                fireHit = true;
            return false;
        }

        public int GetDrawingPriority() => 100;
    }
}