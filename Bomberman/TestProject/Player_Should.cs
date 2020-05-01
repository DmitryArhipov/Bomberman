using System;
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
        [Test]
        public void Player_GetImageFileName_CorrectImageName()
        {
            var player = new Player();
            player.GetImageFileName().Should().BeEquivalentTo("running-right-2.png");
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

            Game.Map[1, 1].First().GetImageFileName().Should().BeEquivalentTo("running-left-2.png");
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

            Game.Map[expX, expY].Count().Should().Be(1);
            Game.Map[expX, expY].First().Should().BeAssignableTo<Player>();
        }

        [TestCase(new[] {Keys.Down}, 1, 1, 1, 2, "UnbreakableWall")]
        [TestCase(new[] {Keys.Up}, 1, 1, 1, 0, "UnbreakableWall")]
        [TestCase(new[] {Keys.Left}, 1, 1, 0, 1, "UnbreakableWall")]
        [TestCase(new[] {Keys.Right, Keys.Right}, 2, 1, 3, 1, "BreakableWall")]
        public void Player_CantWalkThroughWalls(IEnumerable<Keys> keys, int expX, int expY,
            int expWallX, int expWallY, string wallType)
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

            Game.Map[expWallX, expWallY].Count().Should().Be(1);
            Game.Map[expX, expY].Count().Should().Be(1);
            Game.Map[expX, expY].First().Should().BeAssignableTo<Player>();
            if (wallType.Equals("BreakableWall"))
                Game.Map[expWallX, expWallY].First().Should().BeAssignableTo<BreakableWall>();
            else
                Game.Map[expWallX, expWallY].First().Should().BeAssignableTo<UnbreakableWall>();
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

            Game.Map[3, 1].Count().Should().Be(2);
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

            Game.Map[3, 1].Count().Should().Be(1);
            Game.Map[3, 1].First().Should().BeAssignableTo<Bomb>();
            Game.Map[2, 1].Count().Should().NotBe(2);
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

            while (timer.Elapsed <= TimeSpan.FromSeconds(1.1))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 1].Count().Should().Be(1);
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
            Game.Map[3, 1] = new ICreature[] { new Bomb(new Player()) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();

            while (timer.Elapsed <= TimeSpan.FromSeconds(2.3))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 1].Count().Should().Be(0);
            Game.Map[2, 1].Select(c => c.GetType().Name).Should().NotContain("Player");
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

            Game.KeyPressed = Keys.Space;
            while (timer.Elapsed <= TimeSpan.FromSeconds(2.05))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 1].Count().Should().Be(4);
            Game.Map[2, 1].Should().ContainItemsAssignableTo<Fire>();
            Game.Map[2, 1].Select(c => c.GetType().Name).Should().NotContain("Player");
        }
    }
}