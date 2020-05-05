using System.Drawing;

namespace Bomberman
{
    public class CreatureAnimation
    {
        public CreatureCommand Command;
        public ICreature Creature;
        public Point Location;
        public Point InitialLogicalLocation;
        public Point TargetLogicalLocation;
    }
}