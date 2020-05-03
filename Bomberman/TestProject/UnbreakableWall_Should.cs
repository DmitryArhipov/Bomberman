using Bomberman;
using FluentAssertions;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class UnbreakableWall_Should
    {
        [Test]
        public void UnbreakableWall_GetImageFileName_RightImageName()
        {
            var wall = new UnbreakableWall();
            wall.GetImageFileName().Should().Be("UnbreakableWall.png");
        }
    }
}