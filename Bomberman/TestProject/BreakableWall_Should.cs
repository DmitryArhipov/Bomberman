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
        private const double SecondsBeforeFly = Fire.secondsBeforeFly;
        [Test]
        public void BreakableWall_GetImageFileName_RightImageName()
        {
            var wall = new BreakableWall();
            wall.GetImageFileName().Should().Be("BreakableWall.png");
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
            var testTime = SecondsBeforeFly * 2;
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(testTime))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[1, 1].Should().BeEmpty();
        }
    }
}