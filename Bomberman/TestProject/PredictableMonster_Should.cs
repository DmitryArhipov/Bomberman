using System;
using System.Diagnostics;
using System.Linq;
using Bomberman;
using FluentAssertions;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class PredictableMonster_Should
    {
        [Test]
        public void PredictableMonster_GetImageFileName_RightImageName()
        {
            var monster = new PredictableMonster();
            monster.GetImageFileName().Should().BeEquivalentTo("PredictableMonster.png");
        }
        
        [TestCase("####\r\n#M #\r\n####", 1, 1, 2, 1)]
        [TestCase("####\r\n# M#\r\n####", 2, 1, 1, 1)]
        [TestCase("####\r\n#  M#\r\n####", 3, 1, 2, 1)]
        [TestCase("#####\r\n#  M#\r\n#   #\r\n#####", 3, 1, 3, 2)]
        [TestCase("#####\r\n#   #\r\n# #M#\r\n#####", 3, 2, 3, 1)]
        public void PredictableMonster_MonsterCanMove_MonsterPredictablyMoved(string testMap, int xWas, int yWas, 
            int x, int y)
        {
            Game.CreateMap(testMap);
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();

            while (timer.Elapsed <= TimeSpan.FromSeconds(1.1))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[xWas, yWas].Count().Should().Be(0);
            Game.Map[x, y].Count().Should().Be(1);
            Game.Map[x, y].First().Should().BeAssignableTo<PredictableMonster>();
        }

        [Test]
        public void PredictableMonster_ConflictedObjectFire_MonsterDied()
        {
            var testMap = @"
#####
# M #
#####";
            Game.CreateMap(testMap);
            Game.Map[1, 1] = new ICreature[] { new Bomb(new Player()) };
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(2.3))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[1, 1].Count().Should().Be(0);
            Game.Map[2, 1].Count().Should().Be(0);
            Game.Map[3, 1].Count().Should().Be(0);
        }
        
        [TestCase("###\r\n#M#\r\n###")]
        [TestCase("#W#\r\nWMW\r\n#W#")]
        public void PredictableMonster_GoThroughWalls_MonsterCantGoThroughWalls(string testMap)
        {
            Game.CreateMap(testMap);
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(2.2))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[1, 1].Count().Should().Be(1);
            Game.Map[1, 1].First().Should().BeAssignableTo<PredictableMonster>();
        }
    }
}