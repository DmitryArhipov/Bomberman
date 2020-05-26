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
            Game.Map[2, 1] = new ICreature[] { new Fire(1, Direction.Left) };
            var gameState = new GameState();
            
            gameState.BeginAct();
            gameState.EndAct();

            Game.Map[1, 1].Should().BeEmpty();
        }
    }
}