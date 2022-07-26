using System;
using System.Linq;

namespace Rover
{
    public class Rover : IRover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public FacingDirection Direction { get; set; }

        public Rover(int x = 0, int y = 0, FacingDirection d = FacingDirection.NORTH)
        {
            X = x;
            Y = y;
            Direction = d;
        }

        public void Move(MovingDirection d)
        {
            switch (Direction)
            {
                case FacingDirection.NORTH:
                    Y += (int)d;
                    break;
                case FacingDirection.SOUTH:
                    Y -= (int)d;
                    break;
                case FacingDirection.EAST:
                    X += (int)d;
                    break;
                case FacingDirection.WEST:
                    X -= (int)d;
                    break;
            }
        }

        public void Turn(TurningDirection d) {
            switch (d)
            {
                case TurningDirection.LEFT:
                    TurnLeft();
                    break;
                case TurningDirection.RIGHT:
                    TurnRight();
                    break;
            }
        }

        private void TurnLeft() {
            var d = ((int)Direction - 1);
            
            if (d < 0)
                d = (int)Enum.GetValues(typeof(FacingDirection)).Cast<FacingDirection>().Max();
                
            Direction = (FacingDirection)d;
        }

        private void TurnRight() {
            var d = ((int)Direction + 1);
            var directions = Enum.GetValues(typeof(FacingDirection)).Cast<FacingDirection>();

            if (d > (int)directions.Max())
                d = (int)directions.Min();
                
            Direction = (FacingDirection)d;
        }
    }
}