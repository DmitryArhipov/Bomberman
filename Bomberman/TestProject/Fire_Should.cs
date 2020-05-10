﻿using System;
using System.Diagnostics;
using Bomberman;
using FluentAssertions;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class Fire_Should
    {
        private const double SecondsBeforeExplosion = Bomb.secondsBeforeExplosion;
        private const double SecondsBeforeFly = Fire.secondsBeforeFly;
        private const double TimeGap = 0.05;
        
        [Test]
        public void Fire_GetImageFileName_RightImageName()
        {
            var fire = new Fire(1, Direction.Down);
            fire.GetImageFileName().Should().Be("Fire.png");
        }

        [Test]
        public void Fire_FireLifePeriod_FireDisappear()
        {
            var testMap = @"
####
#  #
####";
            Game.CreateMap(testMap);
            Game.Map[1, 1] = new ICreature[] { new Fire(1, Direction.Right) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            var testTime = SecondsBeforeFly * 2 + TimeGap;
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(testTime))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[1, 1].Should().BeEmpty();
            Game.Map[2, 1].Should().BeEmpty();
        }

        [Test]
        public void Fire_NowhereFly_FireDisappear()
        {
            var testMap = @"
###
# #
###";
            Game.CreateMap(testMap);
            Game.Map[1, 1] = new ICreature[] { new Fire(1, Direction.Down) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            var testTime = TimeGap + SecondsBeforeFly;
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(testTime))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[1, 1].Should().BeEmpty();
        }

        [TestCase("####\r\n#  #\r\n####", 1, 1, Direction.Right, 2, 1)]
        [TestCase("####\r\n#  #\r\n####", 2, 1, Direction.Left, 1, 1)]
        [TestCase("###\r\n# #\r\n# #\r\n###", 1, 1, Direction.Down, 1, 2)]
        [TestCase("###\r\n# #\r\n# #\r\n###", 1, 2, Direction.Up, 1, 1)]
        public void Fire_FireFlyByDirection_FlyCorrectly(string testMap, int x, int y, Direction direction,
            int expX, int expY)
        {
            Game.CreateMap(testMap);
            Game.Map[x, y] = new ICreature[] { new Fire(1, direction) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            var testTime = TimeGap + SecondsBeforeFly;
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(testTime))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[expX, expY].Length.Should().Be(1);
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
            Game.Map[2, 1] = new ICreature[] { new Fire(1, Direction.Right) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            var testTime = SecondsBeforeFly * 2;
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(testTime))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 2].Length.Should().Be(1);
            Game.Map[2, 2].Should().ContainItemsAssignableTo<UnbreakableWall>();
        }
    }
}