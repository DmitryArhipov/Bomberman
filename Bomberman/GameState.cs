﻿using System;
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
                {
                    foreach (var creature in Game.Map[x,y])
                    {
                        if (creature == null)
                            continue;
                        var command = creature.Act(x, y);
                        if (x + command.DeltaX < 0 || x + command.DeltaX >= Game.MapWidth || y + command.DeltaY < 0 ||
                            y + command.DeltaY >= Game.MapHeight)
                            throw new Exception($"The object {creature.GetType()} falls out of the game field");
                        Animations.Add(
                            new CreatureAnimation
                            {
                                Command = command,
                                Creature = creature,
                                Location = new Point(x * ElementSize, y * ElementSize),
                                TargetLogicalLocation = new Point(x + command.DeltaX, y + command.DeltaY)
                            });
                    }
                }
        }

        public void EndAct()
        {
            var creaturesPerLocation = GetCandidatesPerLocation();
            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                    Game.Map[x, y] = SelectWinnerCandidatePerLocation(creaturesPerLocation, x, y);
        }

        private static ICreature[] SelectWinnerCandidatePerLocation(List<ICreature>[,] creatures, int x, int y)
        {
            var candidates = creatures[x, y];
            var aliveCandidates = candidates.ToList();
            foreach (var candidate in candidates)
                foreach (var rival in candidates)
                    if (rival != candidate && candidate.DeadInConflict(rival))
                        aliveCandidates.Remove(candidate);
            if (aliveCandidates.Count > 1 && !IsBombAndPlayer(aliveCandidates))
                throw new Exception(
                    $"Creatures {aliveCandidates[0].GetType().Name} and {aliveCandidates[1].GetType().Name} claimed the same map cell");

            return aliveCandidates.ToArray();
        }

        private static bool IsBombAndPlayer(List<ICreature> aliveCandidates)
        {
            return aliveCandidates[0] is Player && aliveCandidates[1] is Bomb ||
                   aliveCandidates[1] is Player && aliveCandidates[0] is Bomb;
        }

        private List<ICreature>[,] GetCandidatesPerLocation()
        {
            var creatures = new List<ICreature>[Game.MapWidth, Game.MapHeight];
            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                    creatures[x, y] = new List<ICreature>();
            foreach (var e in Animations)
            {
                var x = e.TargetLogicalLocation.X;
                var y = e.TargetLogicalLocation.Y;
                var nextCreature = e.Command.TransformTo ?? new[] {e.Creature};
                creatures[x, y].AddRange(nextCreature);
            }

            return creatures;
        }
    }
}