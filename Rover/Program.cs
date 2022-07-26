using System;

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

        public Rover(int x = 0, int y = 0, FacingDirection d = FacingDirection.N)
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

        //Finalement je suis parti sur FluentAssertions pour avoir des retours plus sympa
        // public override int GetHashCode()
        // {
        //     return HashCode.Combine(X, Y, Direction);
        // }

        // public override bool Equals(object? obj)
        // {
        //     return obj is Rover r &&
        //         X == r.X &&
        //         Y == r.Y &&
        //         Direction == r.Direction;
        // }

        public void Move(MovingDirection d)
        {
            throw new NotImplementedException();
        }

        public void Turn(TurningDirection d) {
            throw new NotImplementedException();
        }
    }

    public enum MovingDirection {
        FRONTWARD,
        BACKWARD
    }

    public enum TurningDirection {
        LEFT,
        RIGHT
    }

    public enum FacingDirection {
        N,
        S,
        W,
        E
    }
}
