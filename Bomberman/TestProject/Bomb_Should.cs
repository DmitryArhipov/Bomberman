using System;
using System.Diagnostics;
using System.Linq;
using Bomberman;
using FluentAssertions;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class Bomb_Should
    {
        [Test]
        public void Bomb_GetImageFileName_RightImageName()
        {
            var bomb = new Bomb(new Player());
            bomb.GetImageFileName().Should().BeEquivalentTo("Bomb.png");
        }

        [Test]
        public void Bomb_BombExplosion_BombExploded()
        {
            var testMap = @"
#####
#   #
#   #
#   #
#####";
            Game.CreateMap(testMap);
            Game.Map[2, 2] = new ICreature[] {new Bomb(new Player())};
            Game.Map[2, 2].Count().Should().Be(1);
            Game.Map[2, 2].First().Should().BeAssignableTo<Bomb>();
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(2.15))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 2].Count().Should().Be(0);
            Game.Map[2, 2].Select(n => n.GetType().Name).Should().NotContain("Bomb");
        }
        
        [Test]
        public void Bomb_BombExplosion_BombTransformToFiresArray()
        {
            var testMap = @"
#####
#   #
#   #
#   #
#####";
            Game.CreateMap(testMap);
            Game.Map[2, 2] = new ICreature[] { new Bomb(new Player()) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(2.05))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 2].Count().Should().Be(4);
            Game.Map[2, 2].Select(n => n.GetType().Name).Should().NotContain("Bomb");
            Game.Map[2, 2].Should().AllBeAssignableTo<Fire>();
        }
        
        [Test]
        public void Bomb_BombExplosion_BombTransformToFires()
        {
            var testMap = @"
#####
#   #
#   #
#   #
#####";
            Game.CreateMap(testMap);
            Game.Map[2, 2] = new ICreature[] { new Bomb(new Player()) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(2.15))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 2].Count().Should().Be(0);
            Game.Map[2, 1].Count().Should().Be(1);
            Game.Map[2, 3].Count().Should().Be(1);
            Game.Map[1, 2].Count().Should().Be(1);
            Game.Map[3, 2].Count().Should().Be(1);
            Game.Map[2, 1].First().Should().BeAssignableTo<Fire>();
            Game.Map[2, 3].First().Should().BeAssignableTo<Fire>();
            Game.Map[1, 2].First().Should().BeAssignableTo<Fire>();
            Game.Map[3, 2].First().Should().BeAssignableTo<Fire>();
        }

        [Test]
        public void Bomb_BombConflictedObjectFire_BombExploded()
        {
            var testMap = @"
#####
#   #
#####";
            Game.CreateMap(testMap);
            Game.Map[1, 1] = new ICreature[] { new Fire(new Player(), Fire.Direction.Right) };
            Game.Map[2, 1] = new ICreature[] { new Bomb(new Player()) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(0.2))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[2, 1].Count().Should().Be(0);
            Game.Map[1, 1].Count().Should().Be(1);
            Game.Map[1, 1].First().Should().BeAssignableTo<Fire>();
            Game.Map[3, 1].Count().Should().Be(1);
            Game.Map[3, 1].First().Should().BeAssignableTo<Fire>();
        }
    }
}