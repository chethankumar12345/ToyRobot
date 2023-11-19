using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Constants;
using ToyRobot.Enums;

namespace ToyRobot
{
    public class FacingDirection
    {
        public static string GetFacingFromDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return Facing.West;
                case Direction.Up:
                    return Facing.North;
                case Direction.Right:
                    return Facing.East;
                case Direction.Down:
                    return Facing.South;
                default:
                    return Facing.West;
            }
        }

        public static Direction GetDirectionFromFacing(string facing)
        {
            facing = FirstLetterToUpper(facing);
            switch (facing)
            {
                case Facing.West:
                    return Direction.Left;
                case Facing.North:
                    return Direction.Up ;
                case Facing.East:
                    return Direction.Right;
                case Facing.South:
                    return Direction.Down;
                default:
                    return Direction.Left;
            }
        }

        private static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }
}
