﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Bomberman;
using FluentAssertions;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class Player_Should
    {
        private const double SecondsBeforeExplosion = Bomb.secondsBeforeExplosion;
        private const double SecondsBeforeFly = Fire.secondsBeforeFly;
        private const double MonsterThinkingTime = 1;
        private const double TimeGap = 0.05;
        
        [Test]
        public void Player_GetImageFileName_CorrectImageName()
        {
            var player = new Player();
            player.GetImageFileName().Should().Be("running-right-2.png");
        }

        [Test]
        public void Player_GetImageFileNameTurnedPlayer_CorrectImageName()
        {
            var testMap = @"
####
# P#
####";
            Game.CreateMap(testMap);
            var gameState = new GameState();

            Game.KeyPressed = Keys.Left;
            gameState.BeginAct();
            gameState.EndAct();

            Game.Map[1, 1].First().GetImageFileName().Should().Be("running-left-2.png");
        }

        [TestCase(new[] {Keys.Right}, 6, 2)]
        [TestCase(new[] {Keys.Left}, 4, 2)]
        [TestCase(new[] {Keys.Up}, 5, 1)]
        [TestCase(new[] {Keys.Down}, 5, 3)]
        [TestCase(new[] {Keys.Up, Keys.Right, Keys.Right}, 7, 1)]
        [TestCase(new[] {Keys.Left, Keys.Left, Keys.Left, Keys.Up, Keys.Right, Keys.Down}, 3, 2)]
        public void Player_TestPlayerMoves(IEnumerable<Keys> keys, int expX, int expY)
        {
            var testMap = @"
##########
#        #
#    P   #
#        #
##########";
            Game.CreateMap(testMap);
            var gameState = new GameState();

            foreach (var key in keys)
            {
                Game.KeyPressed = key;
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[expX, expY].Length.Should().Be(1);
            Game.Map[expX, expY].First().Should().BeAssignableTo<Player>();
        }

        [TestCase(new[] {Keys.Down}, 1, 1, 1, 2, typeof(UnbreakableWall))]
        [TestCase(new[] {Keys.Up}, 1, 1, 1, 0, typeof(UnbreakableWall))]
        [TestCase(new[] {Keys.Left}, 1, 1, 0, 1, typeof(UnbreakableWall))]
        [TestCase(new[] {Keys.Right, Keys.Right}, 2, 1, 3, 1, typeof(BreakableWall))]
        public void Player_CantWalkThroughWalls(IEnumerable<Keys> keys, int expX, int expY,
            int expWallX, int expWallY, Type wallType)
        {
            var testMap = @"
#####
#P W#
#####";
            Game.CreateMap(testMap);
            var gameState = new GameState();

            foreach (var key in keys)
            {
                Game.KeyPressed = key;
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[expWallX, expWallY].Length.Should().Be(1);
            Game.Map[expX, expY].Length.Should().Be(1);
            Game.Map[expX, expY].First().Should().BeAssignableTo<Player>();
            Game.Map[expWallX, expWallY].First().Should().BeAssignableTo(wallType);
        }

        [Test]
        public void Player_SetBomb_BombAndPlayerInTheSameCell()
        {
            var testMap = @"
######
#  P #
######";
            Game.CreateMap(testMap);
            var gameState = new GameState();

            Game.KeyPressed = Keys.Space;
            gameState.BeginAct();
            gameState.EndAct();

            Game.Map[3, 1].Length.Should().Be(2);
            Game.Map[3, 1].Select(n => n.GetType().Name).Should().Contain("Bomb");
            Game.Map[3, 1].Select(n => n.GetType().Name).Should().Contain("Player");
        }

        [Test]
        public void Player_TryOverstepBombsLimit_TryFail()
        {
            var testMap = @"
######
#  P #
######";
            Game.CreateMap(testMap);
            var gameState = new GameState();

            var keys = new[] { Keys.Space, Keys.Left, Keys.Space };
            foreach (var key in keys)
            {
                Game.KeyPressed = key;
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[3, 1].Length.Should().Be(1);
            Game.Map[3, 1].First().Should().BeAssignableTo<Bomb>();
            Game.Map[2, 1].Length.Should().NotBe(2);
            Game.Map[2, 1].Should().ContainItemsAssignableTo<Player>();
        }
        
        [Test]
        public void Player_ConflictedObjectsMonster_PlayerDied()
        {
            var testMap = @"
######
#MP  #
######";
            Game.CreateMap(testMap);
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            var testTime = TimeGap + MonsterThinkingTime;

            while (timer.Elapsed <= TimeSpan.FromSeconds(testTime))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 1].Length.Should().Be(1);
            Game.Map[2, 1].Select(c => c.GetType().Name).Should().NotContain("Player");
            Game.Map[2, 1].Should().ContainItemsAssignableTo<PredictableMonster>();
        }

        [Test]
        public void Player_ConflictedObjectFire_PlayerDied()
        {
            var testMap = @"
#####
# P #
#####";
            Game.CreateMap(testMap);
            var player = new Player();
            Game.Map[3, 1] = new ICreature[] { new Fire(new Player(), Fire.Direction.Left) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            var testTime = SecondsBeforeFly * 2 + TimeGap;

            while (timer.Elapsed <= TimeSpan.FromSeconds(testTime))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 1].Should().BeEmpty();
            Game.Map[2, 1].Should().NotContain(player);
        }

        [Test]
        public void Player_PlayerStayOnBomb_PlayerDied()
        {
            var testMap = @"
#####
# P #
#####";
            Game.CreateMap(testMap);
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            var testTime = TimeGap + SecondsBeforeExplosion;

            Game.KeyPressed = Keys.Space;
            while (timer.Elapsed <= TimeSpan.FromSeconds(testTime))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 1].Length.Should().Be(4);
            Game.Map[2, 1].Should().ContainItemsAssignableTo<Fire>();
            Game.Map[2, 1].Should().NotContain(new Player());
        }
    }
}