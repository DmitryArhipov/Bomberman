using System.IO;
using System.Media;

namespace Bomberman
{
    public class Plate : ICreature
    {
        private bool pressing;
        private static readonly string soundFile = Path.Combine(Program.SoundsPath, "button.wav");
        
        public string GetImageFileName() => "Button.png";
        
        public CreatureCommand Act(int x, int y)
        {
            if(pressing)
                return new CreatureCommand { TransformTo = new[] { new PressedPlate() } };
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Block && Program.EnableSound && File.Exists(soundFile) && !pressing)
            {
                new SoundPlayer(soundFile).Play();
                Game.PlatesCount--;
                pressing = true;
            }

            return false;
        }
        
        public int GetDrawingPriority() => 100;
    }
}