namespace Rover
{
    public interface IRover
    {
        int X { get; set; }
        int Y { get; set; }
        FacingDirection Direction { get; set; }
        void Move(MovingDirection d);
        void Turn(TurningDirection d);
    }

    public enum MovingDirection {
        FRONTWARD = 1,
        BACKWARD = -1
    }

    public enum TurningDirection {
        LEFT,
        RIGHT
    }

    public enum FacingDirection {
        NORTH = 0,
        EAST = 1,
        SOUTH = 2,
        WEST = 3
    }
}