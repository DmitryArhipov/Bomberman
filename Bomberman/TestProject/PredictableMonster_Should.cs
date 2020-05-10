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
        private const double SecondsBeforeFly = Fire.secondsBeforeFly;
        private const double MonsterThinkingTime = 1;
        private const double TimeGap = 0.05;
        
        [Test]
        public void PredictableMonster_GetImageFileName_RightImageName()
        {
            var monster = new PredictableMonster();
            monster.GetImageFileName().Should().Be("PredictableMonster.png");
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
            var testTime = MonsterThinkingTime + TimeGap;

            while (timer.Elapsed <= TimeSpan.FromSeconds(testTime))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[xWas, yWas].Should().BeEmpty();
            Game.Map[x, y].Length.Should().Be(1);
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
            Game.Map[3, 1].Should().BeEmpty();
        }
        
        [TestCase("###\r\n#M#\r\n###")]
        [TestCase("#W#\r\nWMW\r\n#W#")]
        public void PredictableMonster_GoThroughWalls_MonsterCantGoThroughWalls(string testMap)
        {
            Game.CreateMap(testMap);
            var gameState = new GameState();
            var timer = Stopwatch.StartNew();
            var testTime = MonsterThinkingTime * 2 + TimeGap;
            
            while (timer.Elapsed <= TimeSpan.FromSeconds(testTime))
            {
                gameState.BeginAct();
                gameState.EndAct();
            }

            Game.Map[1, 1].Length.Should().Be(1);
            Game.Map[1, 1].First().Should().BeAssignableTo<PredictableMonster>();
        }
    }
}