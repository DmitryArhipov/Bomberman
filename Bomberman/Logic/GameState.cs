using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Bomberman
{
    public class GameState
    {
        public const int ElementSize = 80;
        public List<CreatureAnimation> Animations = new List<CreatureAnimation>();

        public void BeginAct()
        {
            Animations.Clear();

            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                    foreach (var creature in Game.Map[x,y])
                    {
                        if (creature == null)
                            continue;
                        var command = creature.Act(x, y);
                        if (x + command.DeltaX < 0 || x + command.DeltaX >= Game.MapWidth 
                                                   || y + command.DeltaY < 0 || y + command.DeltaY >= Game.MapHeight)
                            throw new Exception($"The object {creature.GetType()} falls out of the game field");
                        Animations.Add(
                            new CreatureAnimation
                            {
                                Command = command,
                                Creature = creature,
                                Location = new Point(x * ElementSize, y * ElementSize),
                                InitialLogicalLocation = new Point(x, y),
                                TargetLogicalLocation = new Point(x + command.DeltaX, y + command.DeltaY)
                            });
                    }
            
            Animations = Animations.OrderByDescending(z => z.Creature.GetDrawingPriority()).ToList();
        }

        public void EndAct()
        {
            var candidates = GetCandidatesPerLocation();
            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                    Game.Map[x, y] = SelectWinnerCandidatePerLocation(candidates, x, y);
        }

        private static ICreature[] SelectWinnerCandidatePerLocation(List<Candidate>[,] creatures, int x, int y)
        {
            var point = new Point(x, y);
            var candidates = creatures[x, y];
            var aliveCandidates = candidates.ToList();
            
            foreach (var candidate in candidates)
                foreach (var rival in candidates)
                {
                    if (candidate.To != point)
                        aliveCandidates.Remove(candidate);

                    if (rival.Creature != candidate.Creature && Conflict(candidate, rival) && candidate.Creature.DeadInConflict(rival.Creature))
                        aliveCandidates.Remove(candidate);
                }

            var aliveCreatures = aliveCandidates.Select(c => c.Creature).ToList();
            
            if (aliveCreatures.Count > 1 && !IsBombAndPlayer(aliveCreatures) && !IsFire(aliveCreatures))
                throw new Exception(
                    $"Creatures {aliveCreatures[0].GetType().Name} and {aliveCreatures[1].GetType().Name} claimed the same map cell");

            return aliveCreatures.ToArray();
        }

        private static bool Conflict(Candidate candidate1, Candidate candidate2)
        {
            return candidate1.To == candidate2.To || Cross(candidate1, candidate2);
        }

        private static bool Cross(Candidate candidate1, Candidate candidate2)
        {
            return candidate1.From == candidate2.To && candidate1.To == candidate2.From;
        }

        private static bool IsFire(List<ICreature> aliveCandidates)
        {
            var fires = 0;
            foreach (var candidate in aliveCandidates)
                if (candidate is Fire)
                    fires++;
            return fires == aliveCandidates.Count;
        }

        private static bool IsBombAndPlayer(List<ICreature> aliveCandidates)
        {
            return aliveCandidates[0] is Player && aliveCandidates[1] is Bomb ||
                   aliveCandidates[1] is Player && aliveCandidates[0] is Bomb;
        }

        private List<Candidate>[,] GetCandidatesPerLocation()
        {
            var candidates = new List<Candidate>[Game.MapWidth, Game.MapHeight];
            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                    candidates[x, y] = new List<Candidate>();

            foreach (var e in Animations)
            {
                var creatures = e.Command.TransformTo ?? new[] {e.Creature};
                
                foreach (var creature in creatures)
                {
                    var candidate = new Candidate
                    {
                        Creature = creature,
                        From = e.InitialLogicalLocation,
                        To = e.TargetLogicalLocation
                    };
                
                    var x = e.InitialLogicalLocation.X;
                    var y = e.InitialLogicalLocation.Y;
                
                    candidates[x, y].Add(candidate);

                    if (e.InitialLogicalLocation != e.TargetLogicalLocation)
                    {
                        var x1 = e.TargetLogicalLocation.X;
                        var y1 = e.TargetLogicalLocation.Y;

                        candidates[x1, y1].Add(candidate);
                    } 
                }
                
            }

            return candidates;
        }

        public class Candidate
        {
            public Point From;
            public Point To;
            public ICreature Creature;
        }
    }
}