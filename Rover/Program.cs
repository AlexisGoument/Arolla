﻿using System;
using System.Linq;

namespace Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IRover
    {
        int X { get; set; }
        int Y { get; set; }
        FacingDirection Direction { get; set; }

        bool Equals(Rover r);
        void Move(MovingDirection d);
        void Turn(TurningDirection d);
    }

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

        public bool Equals(Rover r)
        {
            return r != null &&
                X == r.X &&
                Y == r.Y &&
                Direction == r.Direction;
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
