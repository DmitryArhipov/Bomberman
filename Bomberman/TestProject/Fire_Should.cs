using System;
using System.Diagnostics;
using System.Linq;
using Bomberman;
using FluentAssertions;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class Fire_Should
    {
        [Test]
        public void Fire_GetImageFileName_RightImageName()
        {
            var fire = new Fire(new Player(), Fire.Direction.Down);
            fire.GetImageFileName().Should().BeEquivalentTo("Fire.png");
        }

        [Test]
        public void Fire_FireLifePeriod_FireDisappear()
        {
            var testMap = @"
####
#  #
####";
            Game.CreateMap(testMap);
            Game.Map[1, 1] = new ICreature[] { new Fire(new Player(), Fire.Direction.Right) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(0.3))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[1, 1].Count().Should().Be(0);
            Game.Map[2, 1].Count().Should().Be(0);
        }

        [Test]
        public void Fire_NowhereFly_FireDisappear()
        {
            var testMap = @"
###
# #
###";
            Game.CreateMap(testMap);
            Game.Map[1, 1] = new ICreature[] { new Fire(new Player(), Fire.Direction.Down) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(0.15))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[1, 1].Count().Should().Be(0);
        }

        [TestCase("####\r\n#  #\r\n####", 1, 1, Fire.Direction.Right, 2, 1)]
        [TestCase("####\r\n#  #\r\n####", 2, 1, Fire.Direction.Left, 1, 1)]
        [TestCase("###\r\n# #\r\n# #\r\n###", 1, 1, Fire.Direction.Down, 1, 2)]
        [TestCase("###\r\n# #\r\n# #\r\n###", 1, 2, Fire.Direction.Up, 1, 1)]
        public void Fire_FireFlyByDirection_FlyCorrectly(string testMap, int x, int y, Fire.Direction direction,
            int expX, int expY)
        {
            Game.CreateMap(testMap);
            Game.Map[x, y] = new ICreature[] { new Fire(new Player(), direction) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(0.11))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[expX, expY].Count().Should().Be(1);
            Game.Map[expX, expY].Should().ContainItemsAssignableTo<Fire>();
        }
        
        [Test]
        public void Fire_ConflictedObjectUnbreakableWall_FireDied()
        {
            var testMap = @"
####
#  #
####";
            Game.CreateMap(testMap);
            Game.Map[2, 1] = new ICreature[] { new Fire(new Player(), Fire.Direction.Right) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(0.2))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 2].Count().Should().Be(1);
            Game.Map[2, 2].Should().ContainItemsAssignableTo<UnbreakableWall>();
        }
    }
}