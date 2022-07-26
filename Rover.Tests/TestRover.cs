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
            rover = new Rover(0, 0, FacingDirection.NORTH);
        }

        [Test]
        public void TestRover_InitialPosition()
        {
            rover.Should().BeEquivalentTo(new Rover(0, 0, FacingDirection.NORTH));
        }

        [Test]
        public void TestRover_MoveForward()
        {
            rover.Move(MovingDirection.FRONTWARD);
            rover.Should().BeEquivalentTo(new Rover(0, 1, FacingDirection.NORTH));
        }

        [Test]
        public void TestRover_MoveBackward()
        {
            rover.Move(MovingDirection.BACKWARD);
            rover.Should().BeEquivalentTo(new Rover(0, -1, FacingDirection.NORTH));
        }
        
        [TestCase(FacingDirection.NORTH, MovingDirection.FRONTWARD, 0, 1)]
        [TestCase(FacingDirection.EAST, MovingDirection.FRONTWARD, 1, 0)]
        [TestCase(FacingDirection.SOUTH, MovingDirection.FRONTWARD, 0, -1)]
        [TestCase(FacingDirection.WEST, MovingDirection.FRONTWARD, -1, 0)]
        [TestCase(FacingDirection.NORTH, MovingDirection.BACKWARD, 0, -1)]
        [TestCase(FacingDirection.EAST, MovingDirection.BACKWARD, -1, 0)]
        [TestCase(FacingDirection.SOUTH, MovingDirection.BACKWARD, 0, 1)]
        [TestCase(FacingDirection.WEST, MovingDirection.BACKWARD, 1, 0)]
        public void TestRover_Moves(FacingDirection initialFacingDirection, MovingDirection movingDirection, int expectedX, int expectedY)
        {
            rover.Direction = initialFacingDirection;
            rover.Move(movingDirection);
            rover.Should().BeEquivalentTo(new Rover(expectedX, expectedY, initialFacingDirection));
        }

        [Test]
        public void TestRover_TurnLeft()
        {
            rover.Turn(TurningDirection.LEFT);
            rover.Should().BeEquivalentTo(new Rover(0, 0, FacingDirection.WEST));
        }

        [Test]
        public void TestRover_TurnRight()
        {
            rover.Turn(TurningDirection.RIGHT);
            rover.Should().BeEquivalentTo(new Rover(0, 0, FacingDirection.EAST));
        }

        [TestCase(FacingDirection.NORTH, TurningDirection.LEFT, FacingDirection.WEST)]
        [TestCase(FacingDirection.WEST, TurningDirection.LEFT, FacingDirection.SOUTH)]
        [TestCase(FacingDirection.SOUTH, TurningDirection.LEFT, FacingDirection.EAST)]
        [TestCase(FacingDirection.EAST, TurningDirection.LEFT, FacingDirection.NORTH)]
        [TestCase(FacingDirection.NORTH, TurningDirection.RIGHT, FacingDirection.EAST)]
        [TestCase(FacingDirection.WEST, TurningDirection.RIGHT, FacingDirection.NORTH)]
        [TestCase(FacingDirection.SOUTH, TurningDirection.RIGHT, FacingDirection.WEST)]
        [TestCase(FacingDirection.EAST, TurningDirection.RIGHT, FacingDirection.SOUTH)]
        public void TestRover_Turns(FacingDirection initialFacingDirection, TurningDirection turningDirection, FacingDirection expectedFacingDirection)
        {
            rover.Direction = initialFacingDirection;
            rover.Turn(turningDirection);
            rover.Should().BeEquivalentTo(new Rover(0, 0, expectedFacingDirection));
        }

        [Test]
        public void TestRover_AllCommands()
        {
            rover.Turn(TurningDirection.RIGHT);
            rover.Turn(TurningDirection.LEFT);
            rover.Move(MovingDirection.FRONTWARD);
            rover.Move(MovingDirection.BACKWARD);
            rover.Should().BeEquivalentTo(new Rover(0, 0, FacingDirection.NORTH));
        }

        [Test]
        public void TestRover_MoveLikeAKnight()
        {
            rover.Move(MovingDirection.FRONTWARD);
            rover.Move(MovingDirection.FRONTWARD);
            rover.Turn(TurningDirection.RIGHT);
            rover.Move(MovingDirection.FRONTWARD);

            rover.Should().BeEquivalentTo(new Rover(1, 2, FacingDirection.EAST));
        }
    }
}