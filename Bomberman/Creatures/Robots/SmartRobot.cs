using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Bomberman
{
    public class SmartRobot : Robot
    {
        public override string GetImageFileName() => "SmartRobot.png";
        
        private const double msBeforeGo = 150;
        private readonly Random random = new Random();

        public override CreatureCommand Act(int x, int y)
        {
            Position = new Point(x, y);
            if (Timer.ElapsedMilliseconds < msBeforeGo)
            {
                Game.WantToMoveRobot[x, y] = true;
                return new CreatureCommand();
            }

            Timer = Stopwatch.StartNew();
            Game.WantToMoveRobot[x, y] = false;
            var command = GetOptimalMove(x, y);
            Game.WantToMoveRobot[x + command.DeltaX, y + command.DeltaY] = true;

            Position = new Point(x + command.DeltaX, y + command.DeltaY);
            return command;
        }

        private CreatureCommand GetOptimalMove(int x, int y)
        {
            var playerPosition = GetPlayerPosition();
            var currentDistance = GetManhattanDistance(Position, playerPosition);
            
            var minDistance = currentDistance;
            var minDirection = new Point(0, 0);

            foreach (var direction in AllDirections)
            {
                var newPosition = GetNewPosition(Position, direction);
                
                if (CanMove(newPosition))
                {
                    var newDistance = GetManhattanDistance(newPosition, playerPosition) - random.Next(3);
                    
                    if (newDistance < minDistance)
                    {
                        minDistance = newDistance;
                        minDirection = direction;
                    }    
                }
            }

            return new CreatureCommand {DeltaX = minDirection.X, DeltaY = minDirection.Y};
        }

        private Point GetNewPosition(Point old, Point direction) => new Point(old.X + direction.X, old.Y + direction.Y);

        private bool CanMove(Point point)
        {
            return point.X >= 0 && point.X < Game.MapWidth &&
                   point.Y >= 0 && point.Y < Game.MapHeight &&
                   !Game.Map[point.X, point.Y].ContainsObstaclesOrBomb() &&
                   !Game.Map[point.X, point.Y].ContainsRobot() &&
                   !Game.Map[point.X, point.Y].ContainsForceField() &&
                   !Game.WantToMoveRobot[point.X, point.Y];
        }

        private Point[] AllDirections = {
            new Point(-1, 0), new Point(1, 0), new Point(0, -1), new Point(0, 1)
        };

    private static int GetManhattanDistance(Point p1, Point p2) => Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);

        private static Point GetPlayerPosition()
        {
            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                    if (Game.Map[x, y].OfType<Player>().Any())
                        return new Point(x, y);
            return new Point(0, 0);
        }
    }
}