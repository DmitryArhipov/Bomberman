using System.IO;
using System.Media;

namespace Bomberman
{
    public class Plate : ICreature
    {
        private static readonly string soundFile = Path.Combine(Program.SoundsPath, "button.wav");
        public string GetImageFileName()
        {
            throw new System.NotImplementedException();
        }

        public int GetDrawingPriority()
        {
            throw new System.NotImplementedException();
        }

        public CreatureCommand Act(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Block && Program.EnableSound && File.Exists(soundFile))
            {
                new SoundPlayer(soundFile).Play();
            }

            return conflictedObject is Block;
        }
    }
}