using NUnit.Framework;
using FluentAssertions;

namespace Rover.Tests
{
    [TestFixture]
    public class Tests
    {
        private IRover rover;

        [SetUp]
        public void Setup()
        {
            rover = new Rover();
        }

        [Test]
        public void TestRover_InitialPosition()
        {
            rover.Should().BeEquivalentTo(new Rover(0, 0, FacingDirection.N));
        }

        [Test]
        public void TestRover_MoveForward()
        {
            rover.Move(MovingDirection.FRONTWARD);
            rover.Should().BeEquivalentTo(new Rover(0, 1, FacingDirection.N));
        }

        [Test]
        public void TestRover_MoveBackward()
        {
            rover.Move(MovingDirection.BACKWARD);
            rover.Should().BeEquivalentTo(new Rover(0, -1, FacingDirection.N));
        }

        [Test]
        public void TestRover_TurnLeft()
        {
            rover.Turn(TurningDirection.LEFT);
            rover.Should().BeEquivalentTo(new Rover(0, 0, FacingDirection.W));
        }

        [Test]
        public void TestRover_TurnRight()
        {
            rover.Turn(TurningDirection.RIGHT);
            rover.Should().BeEquivalentTo(new Rover(0, 0, FacingDirection.E));
        }

        [Test]
        public void TestRover_AllCommands()
        {
            rover.Turn(TurningDirection.RIGHT);
            rover.Turn(TurningDirection.LEFT);
            rover.Move(MovingDirection.FRONTWARD);
            rover.Move(MovingDirection.BACKWARD);
            rover.Should().BeEquivalentTo(new Rover(0, 0, FacingDirection.N));
        }

        [Test]
        public void TestRover_MoveLikeAKnight()
        {
            rover.Move(MovingDirection.FRONTWARD);
            rover.Move(MovingDirection.FRONTWARD);
            rover.Turn(TurningDirection.RIGHT);
            rover.Move(MovingDirection.FRONTWARD);

            rover.Should().BeEquivalentTo(new Rover(1, 2, FacingDirection.E));
        }
    }
}