using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;
using ToyRobot.Intefaces;
using ToyRobot.Models;

namespace ToyRobot
{
    public class GameDashboardCreator
    {

        public GameDashboardCreator()
        {
            GameBoard = Board.Instance;
            GameBoard.NumberOfVerticalCells = 5;
            GameBoard.NumberOfHorizontalCells = 5;
        }
        public IPlayBoard PlayBoard { get; private set; }
        private static readonly Lazy<GameDashboardCreator> lazy = new Lazy<GameDashboardCreator>(() => new GameDashboardCreator());
        public static GameDashboardCreator Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public Board GameBoard { get; set; }

        public Robot Robot { get; set; } = null;

        public bool PlaceRobot(Position position, Direction direction)
        {
            if (position.X >= 0 && position.Y >= 0 &&
              position.X < GameBoard.NumberOfHorizontalCells && position.Y < GameBoard.NumberOfVerticalCells)
            {
                Robot= new Robot() { Position= position, Direction = direction };
                GameBoard.Robots.Add(Robot);
             
                return true;
            }
            return false;
        }
        public Robot GetRobot()
        {
            return this.Robot;
        }

        public Board GetBoard()
        {
            return this.GameBoard;
        }

        public IPlayBoard GetPlayBoard(Func<IPlayBoard> playBoard = null)
        {
            if (PlayBoard != null) return PlayBoard;
            if (Robot == null) return null;

            PlayBoard = playBoard();

            return PlayBoard;
        }

        public void ResetGame()
        {
            Robot = null;
            GameBoard.Robots = new List<Robot>();
        }
    }
}
