namespace Bomberman
{
    public class Prompt : ICreature
    {
        public readonly int number;
        
        public Prompt(int number)
        {
            this.number = number;
        }

        public string GetImageFileName()
        {
            if(number == 1)
                throw new System.NotImplementedException();
            if(number == 2)
                throw new System.NotImplementedException();
            if(number == 3)
                throw new System.NotImplementedException();
            if(number == 4)
                throw new System.NotImplementedException();
            if(number == 5)
                throw new System.NotImplementedException();
            throw new System.NotImplementedException();
        }

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            var result = conflictedObject is Player;
            
            if (result && number == 1)
                Game.Prompt1 = true;
            if (result && number == 2)
                Game.Prompt2 = true;
            if (result && number == 3)
                Game.Prompt3 = true;
            if (result && number == 4)
                Game.Prompt4 = true;
            if (result && number == 5)
                Game.Prompt5 = true;

            return result;
        }
        
        public int GetDrawingPriority() => 100;
    }
}