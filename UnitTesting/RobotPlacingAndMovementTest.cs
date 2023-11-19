using ToyRobot.Constants;
using ToyRobot.Enums;
using ToyRobot.Models;
using ToyRobot;
using System;
using ToyRobot.Intefaces;

namespace UnitTesting
{
    public class RobotPlacingAndMovementTest
    {
        public RobotPlacingAndMovementTest()
        {

  

        }
        [Fact]
        public void PlacePositionZeroZeroWithSouthFacing()
        {
            GameDashboardCreator.Instance.ResetGame();
            ExecuteAction(GameDashboardCreator.Instance.GetPlayBoard(), (int)Actions.PLACE, 0, 0, "south");
            ExecuteAction(GameDashboardCreator.Instance.GetPlayBoard(() => new PlayBoardMOQ(GameDashboardCreator.Instance.GameBoard)), (int)Actions.MOVE);
            Assert.Equal("X : 0, Y : 1, F : South", ExecuteAction(GameDashboardCreator.Instance.GetPlayBoard(), (int)Actions.REPORT));

        }

        [Fact]
        public void PlacePositionZeroZeroWithEastFacing()
        {
            GameDashboardCreator.Instance.ResetGame();
            ExecuteAction(GameDashboardCreator.Instance.GetPlayBoard(), (int)Actions.PLACE, 0, 0, "east");
            ExecuteAction(GameDashboardCreator.Instance.GetPlayBoard(() => new PlayBoardMOQ(GameDashboardCreator.Instance.GameBoard)), (int)Actions.MOVE);
            Assert.Equal("X : 1, Y : 0, F : East", ExecuteAction(GameDashboardCreator.Instance.GetPlayBoard(), (int)Actions.REPORT));

        }


        private string ExecuteAction(IPlayBoard GamePlayBoard, int inputAction, int inputX = 0, int inputY = 0, string inputF = null)
        {


            switch (inputAction)
            {
                case (int)Actions.PLACE:

                    GameDashboardCreator.Instance.PlaceRobot(new Position { X = inputX, Y = inputY }, FacingDirection.GetDirectionFromFacing(inputF));

                    return String.Empty;
                case (int)Actions.LEFT:
                    if (GameDashboardCreator.Instance.GetPlayBoard() != null)
                    {
                        GamePlayBoard.Rotate(GameDashboardCreator.Instance.GetRobot(), Direction.Left);
                    }
                    return String.Empty;
                case (int)Actions.RIGHT:
                    if (GamePlayBoard != null)
                    {
                        GamePlayBoard.Rotate(GameDashboardCreator.Instance.GetRobot(), Direction.Right);
                    }
                    return String.Empty;
                case (int)Actions.MOVE:
                    if (GamePlayBoard != null)
                    {
                        GamePlayBoard.Move(GameDashboardCreator.Instance.GetRobot());
                    }
                    return String.Empty;
                case (int)Actions.REPORT:
                    if (GamePlayBoard != null)
                    {
                        return GamePlayBoard.GetReport(GameDashboardCreator.Instance.GetRobot());
                    }
                    break;
                case (int)Actions.EXIT:
                    return String.Empty;


            }
            return String.Empty;
        }

        private string GetProjectPath()
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result

            // This will get the current PROJECT bin directory (ie ../bin/)
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            // This will get the current PROJECT directory
            return Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        }

        private int GetActionNumber(string action)
        {
            switch (action)
            {
                case ActionsName.PLACE:
                    return (int)Actions.PLACE;
                    break;
                case ActionsName.MOVE:
                    return (int)Actions.MOVE;
                    break;
                case ActionsName.LEFT:
                    return (int)Actions.LEFT;
                    break;
                case ActionsName.RIGHT:
                    return (int)Actions.RIGHT;
                    break;
                case ActionsName.REPORT:
                    return (int)Actions.REPORT;
                    break;
                default:
                    return 0;
            }
        }
    }
}