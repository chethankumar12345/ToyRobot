using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ToyRobot.Enums;
using ToyRobot.Intefaces;
using ToyRobot.Models;

namespace ToyRobot
{
    public  class PlayBoard : IPlayBoard
    {
        protected Board GameBoard;
        public PlayBoard(Board gameBoard)
        {
            GameBoard = gameBoard;
        }

        private bool IsRobotPlaced(Robot robot)
        {
            return (robot!=null && robot.Position != null) ? true : false;

        }

        public bool CanMove(Position nextPosition)
        {
          if(nextPosition.X >=0 && nextPosition.Y>=0 && 
                nextPosition.X<GameBoard.NumberOfHorizontalCells && nextPosition.Y<GameBoard.NumberOfVerticalCells)
            {
                return true;
            }

            return false;
        }


        public string GetReport(Robot robot)
        {
            if (IsRobotPlaced(robot))
            { 
             return String.Format("X : {0}, Y : {1}, F : {2}", robot.Position.X, robot.Position.Y, FacingDirection.GetFacingFromDirection(robot.Direction));
            }

            return String.Empty;
        }

        public void Move(Robot robot)
        {
            var nextPosition = GetNextPosition(robot);
            if (IsRobotPlaced(robot) && CanMove(nextPosition))
            {
                var robotInBorad = GameBoard.Robots.FirstOrDefault(pX => pX.Position == robot.Position);

                robot.Position = nextPosition;
                if(robotInBorad != null)
                {
                    robotInBorad.Position = nextPosition;
                }       


            }
        }

        private Position GetNextPosition(Robot robot)
        {
            var position = new Position { X = robot.Position.X, Y = robot.Position.Y };

            switch (robot.Direction)
            {
                case Direction.Left:
                    position.X--;
                    break;
                case Direction.Right:
                    position.X++;
                    break;
                case Direction.Up:
                    position.Y--;
                    break;
                case Direction.Down:
                    position.Y++;
                    break;

            }
            return position;

        }

        public void Rotate(Robot robot,Direction direction)
        {
          if(direction == Direction.Left)
            {
               int directionValue = (int)robot.Direction;
                directionValue--;
                if (directionValue < 0) directionValue = (int)Direction.Down;
                robot.Direction = (Direction)directionValue;
            }
            else if (direction == Direction.Right)
            {
                int directionValue = (int)robot.Direction;
                directionValue++;
                if (directionValue > 3) directionValue = (int)Direction.Left;
                robot.Direction = (Direction)directionValue;
            }
        }
    }
}
