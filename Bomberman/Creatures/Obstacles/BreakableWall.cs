using System.IO;
using System.Media;

namespace Bomberman
{
    public class BreakableWall : ICreature
    {
        public string GetImageFileName() => "BreakableWall.png";
        private static readonly string soundFile = Path.Combine(Program.SoundsPath, "wall.wav");

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Fire && Program.EnableSound && File.Exists(soundFile))
            {
                new SoundPlayer(soundFile).Play();
            }
            
            return conflictedObject is Fire;
        }

        public int GetDrawingPriority() => 5;
    }
}