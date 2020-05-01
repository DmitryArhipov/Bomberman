using System;
using System.Diagnostics;
using System.Linq;
using Bomberman;
using FluentAssertions;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class BreakableWall_Should
    {
        [Test]
        public void BreakableWall_GetImageFileName_RightImageName()
        {
            var wall = new BreakableWall();
            wall.GetImageFileName().Should().BeEquivalentTo("BreakableWall.png");
        }
        
        [Test]
        public void BreakableWall_ConflictedObjectFire_BreakableWallBroke()
        {
            var testMap = @"
####
#W #
####";
            Game.CreateMap(testMap);
            Game.Map[2, 1] = new ICreature[] { new Fire(new Player(), Fire.Direction.Left) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(0.2))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[1, 1].Count().Should().Be(0);
        }
    }
}