namespace Bomberman
{
    public interface ICreature
    {
        string GetImageFileName();
        CreatureCommand Act(int x, int y);
        bool DeadInConflict(ICreature conflictedObject);
    }
}