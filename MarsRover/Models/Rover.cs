using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{

    class Rover:IMovement
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Direction direction { get; set; }

        public Rover(List<string> coordinatesAndDirection)
        {
            X = Convert.ToInt32(coordinatesAndDirection[0]);
            Y = Convert.ToInt32(coordinatesAndDirection[1]);
            direction = (Direction)Enum.Parse(typeof(Direction), coordinatesAndDirection[2]);

        }

        public void MovementControl(string directions)
        {
            foreach (var item in directions.ToUpper())
            {
                switch (item)
                {
                    case 'L':
                        MoveLeft();
                        break;

                    case 'R':
                        MoveRight();
                        break;

                    case 'M':
                        MoveForward();
                        break;

                    default:
                        break;
                }
            }
        }


        public override string ToString()
        {
            var result = ValidationHelper.LastPositionOutOfBoundsValidator(X,Y);

            if (!result.Key)
            {
                return result.Value;
            }
            else
            {
                return $"{X},{Y},{direction}";
            }
            
        }

        public void MoveLeft()
        {
            switch(direction)
            {
                case Direction.N:
                    direction = Direction.W;
                    break;

                case Direction.W:
                    direction = Direction.S;
                    break;

                case Direction.S:
                    direction = Direction.E;
                    break;

                case Direction.E:
                    direction = Direction.N;
                    break;
            }
        }

        public void MoveRight()
        {
            switch (direction)
            {
                case Direction.N:
                    direction = Direction.E;
                    break;

                case Direction.E:
                    direction = Direction.S;
                    break;

                case Direction.S:
                    direction = Direction.W;
                    break;

                case Direction.W:
                    direction = Direction.N;
                    break;
            }
        }

        public void MoveForward()
        {
            switch (direction)
            {
                case Direction.N:
                    Y++;
                    break;

                case Direction.E:
                    X++;
                    break;

                case Direction.S:
                    Y--;
                    break;

                case Direction.W:
                    X--;
                    break;
            }
        }
    }
}
