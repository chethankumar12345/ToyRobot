using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;
using ToyRobot.Models;

namespace ToyRobot.Intefaces
{
    public interface IPlayBoard
    {
        public void Move(Robot robot);
        public bool CanMove(Position nextPosition);
        public string GetReport(Robot robot);
        public void Rotate(Robot robot, Direction direction);

    }
}
