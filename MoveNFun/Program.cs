using System;
using System.Runtime.CompilerServices;
using ToyRobot;
using ToyRobot.Constants;
using ToyRobot.Enums;
using ToyRobot.Intefaces;
using ToyRobot.Models;


Console.WriteLine("Select Game Input Type :");
Console.WriteLine("1. Manual Input");
Console.WriteLine("2. Input from text file");
string input = Console.ReadLine();
int inputType;

Board GameBorad = null;

if (Int32.TryParse(input, out inputType))
{
    switch (inputType)
    {
        case 1:
            GameWithManualInput();
            break;
            case 2:
            string filePath = GetProjectPath() + "/File/input.txt";
            string[] actions = File.ReadAllLines(filePath);

            foreach (string action in actions)
            {
                string[] type = action.Split(' ');
                if (type.Length == 2)
                {
                    string[] commandInputs = type[1].Split(',');
                    int inputX = int.Parse(commandInputs[0]);
                    int inputY = int.Parse(commandInputs[1].ToLower());
                    string inputF = commandInputs[2].ToLower();
                    int actionNumber = GetActionNumber(type[0].ToLower());
                    ExecuteAction(GameDashboardCreator.Instance.GetPlayBoard(), actionNumber, inputX, inputY, inputF);

                }
                else
                {
                    int actionNumber = GetActionNumber(type[0].ToLower());
                    ExecuteAction(GameDashboardCreator.Instance.GetPlayBoard(() => new PlayBoard(GameDashboardCreator.Instance.GameBoard)), actionNumber);

                }
            }
            break;
    }
}
else
{
    Console.WriteLine("Wrong input. Enter selection 1. Manual Input , 2. Input from text file");
}


static void GameWithManualInput()
{

    while (true)
    {
        Console.WriteLine("1. Place");
        Console.WriteLine("2. Move");
        Console.WriteLine("3. Left");
        Console.WriteLine("4. Right");
        Console.WriteLine("5. Report");
        Console.WriteLine("6. Exit");

        int action;
        string input = Console.ReadLine();
        if (Int32.TryParse(input, out action))
        {

            switch (action)
            {
                case (int)Actions.PLACE:

                    Console.WriteLine("1. Enter Robot position and face in this format \"X,Y,F\" Where F is the robot facing direction NORTH, SOUTH,  EAST or WEST");
                    string robotPlace = Console.ReadLine();
                    string[] commandInputs = robotPlace.Split(',');
                    if(commandInputs.Length == 3)
                    {
                        int inputX = int.Parse(commandInputs[0]);
                        int inputY = int.Parse(commandInputs[1].ToLower());
                        string inputF = commandInputs[2].ToLower();

                        ExecuteAction(GameDashboardCreator.Instance.GetPlayBoard(), action, inputX, inputY, inputF);

                    }

                    break;
                case (int)Actions.LEFT:
                case (int)Actions.RIGHT:
                case (int)Actions.MOVE:
                case (int)Actions.REPORT:
                    ExecuteAction(GameDashboardCreator.Instance.GetPlayBoard(() => new PlayBoard(GameDashboardCreator.Instance.GameBoard)), action);
                    break;
                case (int)Actions.EXIT:
                    return;

            }
        }
    }

   
}

static void ExecuteAction(IPlayBoard GamePlayBoard, int inputAction,int inputX=0,int inputY=0,string inputF =null)
{


        switch (inputAction)
        {
            case (int)Actions.PLACE:

            GameDashboardCreator.Instance.PlaceRobot(new Position { X = inputX, Y = inputY }, FacingDirection.GetDirectionFromFacing(inputF));

                break;
            case (int)Actions.LEFT:
                if (GameDashboardCreator.Instance.GetPlayBoard() != null)
                {
                    GamePlayBoard.Rotate(GameDashboardCreator.Instance.GetRobot(), Direction.Left);
                }
                break;
            case (int)Actions.RIGHT:
                if (GamePlayBoard != null)
                {
                    GamePlayBoard.Rotate(GameDashboardCreator.Instance.GetRobot(), Direction.Right);
                }
                break;
            case (int)Actions.MOVE:
                if (GamePlayBoard != null)
                {
                    GamePlayBoard.Move(GameDashboardCreator.Instance.GetRobot());
                }
                break;
            case (int)Actions.REPORT:
                if (GamePlayBoard != null)
                {
                    Console.WriteLine(GamePlayBoard.GetReport(GameDashboardCreator.Instance.GetRobot()));
                }
                break;
            case (int)Actions.EXIT:
                return;

        
    }
}

static string GetProjectPath()
{
    // This will get the current WORKING directory (i.e. \bin\Debug)
    string workingDirectory = Environment.CurrentDirectory;
    // or: Directory.GetCurrentDirectory() gives the same result

    // This will get the current PROJECT bin directory (ie ../bin/)
    string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

    // This will get the current PROJECT directory
    return Directory.GetParent(workingDirectory).Parent.Parent.FullName;
}

static int GetActionNumber(string action)
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