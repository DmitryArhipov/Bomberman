namespace Bomberman.Doors
{
    public class CloseDoor : ICreature
    {
        private bool fireHit;
        
        public string GetImageFileName()
        {
            throw new System.NotImplementedException();
        }

        public CreatureCommand Act(int x, int y)
        {
            if (fireHit)
            {
                fireHit = false;
                return
                    new CreatureCommand() { TransformTo =
                        new ICreature[] {
                            new CloseDoor(),
                            new PredictableMonster() } };
            }
            if (Game.MonstersCount == 0)
                return new CreatureCommand() { TransformTo = new[] { new OpenDoor() } };
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