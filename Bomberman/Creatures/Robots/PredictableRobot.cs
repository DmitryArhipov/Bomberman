using System.Diagnostics;
using System.Drawing;

namespace Bomberman
{
    public class PredictableRobot : Robot
    {
        private int direction;
        private const double msToGo = 500;
        
        public override string GetImageFileName() => "PredictableRobot.png";

        public override CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            Position = new Point(x, y);
            var newPosition = Position;
            
            if (direction == 0 && x + 1 < Game.MapWidth && !Game.Map[x + 1, y].ContainsObstaclesOrBomb()
                && !Game.Map[x + 1, y].ContainsRobot() && !Game.WantToMoveRobot[x + 1, y]
                && !Game.Map[x + 1, y].ContainsForceField())
            {
                if (Timer.ElapsedMilliseconds >= msToGo)
                {
                    Timer = Stopwatch.StartNew();
                    Game.WantToMoveRobot[x, y] = false;
                    newPosition.X++;
                    Game.WantToMoveRobot[x + 1, y] = true;
                    result.DeltaX = 1;
                }
            }
            
            else if (direction == 1 && y + 1 < Game.MapHeight && !Game.Map[x, y + 1].ContainsObstaclesOrBomb()
                     && !Game.Map[x, y + 1].ContainsRobot() && !Game.WantToMoveRobot[x, y + 1]
                     && !Game.Map[x, y + 1].ContainsForceField())
            {
                if (Timer.ElapsedMilliseconds >= msToGo)
                {
                    Timer = Stopwatch.StartNew();
                    Game.WantToMoveRobot[x, y] = false;
                    newPosition.Y++;
                    Game.WantToMoveRobot[x, y + 1] = true;
                    result.DeltaY = 1;
                }
            }
            
            else if (direction == 2 && x > 0 && !Game.Map[x - 1, y].ContainsObstaclesOrBomb()
                     && !Game.Map[x - 1, y].ContainsRobot() && !Game.WantToMoveRobot[x - 1, y]
                     && !Game.Map[x - 1, y].ContainsForceField())
            {
                if (Timer.ElapsedMilliseconds >= msToGo)
                {
                    Timer = Stopwatch.StartNew();
                    Game.WantToMoveRobot[x, y] = false;
                    newPosition.X--;
                    Game.WantToMoveRobot[x - 1, y] = true;
                    result.DeltaX = -1;
                }
            }
            
            else if (direction == 3 && y > 0 && !Game.Map[x, y - 1].ContainsObstaclesOrBomb()
                     && !Game.Map[x, y - 1].ContainsRobot() && !Game.WantToMoveRobot[x, y - 1]
                     && !Game.Map[x, y - 1].ContainsForceField())
            {
                if (Timer.ElapsedMilliseconds >= msToGo)
                {
                    Timer = Stopwatch.StartNew();
                    Game.WantToMoveRobot[x, y] = false;
                    newPosition.Y--;
                    Game.WantToMoveRobot[x, y - 1] = true;
                    result.DeltaY = -1;
                }
            }

            else direction = (direction + 1) % 4;
            
            Position = newPosition;
            return result;
        }
    }
}