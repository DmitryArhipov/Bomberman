namespace Bomberman
{
    public class UsefulFeatures
    {
        public static bool IsWallOrBomb(ICreature cell)
        {
            return cell is Bomb || cell is BreakableWall || cell is UnbreakableWall;
        }
    }
}