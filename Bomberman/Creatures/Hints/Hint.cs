namespace Bomberman
{
    public class Hint : ICreature
    {
        public readonly int number;
        
        public Hint(int number)
        {
            this.number = number;
        }

        public string GetImageFileName() => "Hint.png";

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            var result = conflictedObject is Player;
            
            if (result && number == 1)
                Game.Hint1 = true;
            if (result && number == 2)
                Game.Hint2 = true;
            if (result && number == 3)
                Game.Hint3 = true;
            if (result && number == 4)
                Game.Hint4 = true;
            if (result && number == 5)
                Game.Hint5 = true;

            return result;
        }
        
        public int GetDrawingPriority() => 100;
    }
}