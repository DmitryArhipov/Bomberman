using System.Diagnostics;
using System.Drawing;

namespace Bomberman
{
    public class SmartMonster : Monster
    {
        private Stopwatch timer = Stopwatch.StartNew();
        public override string GetImageFileName() => "SmartMonster.png";

        public override CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }
    }
}