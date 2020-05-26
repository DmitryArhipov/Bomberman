namespace Bomberman
{
    public interface ICreatureWithTimer : ICreature
    {
        void Pause();
        void Unpause();
    }
}