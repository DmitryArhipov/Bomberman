﻿namespace Bomberman
{
    public class Fire : ICreature
    {
        public string GetImageFileName()
        {
            return "Fire.png";
        }

        public CreatureCommand Act(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            throw new System.NotImplementedException();
        }
    }
}