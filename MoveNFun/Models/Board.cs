using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Models
{
    public sealed class Board
    {
        private Board()
        {
            Robots = new List<Robot>();
        }
        private static readonly Lazy<Board> lazy = new Lazy<Board>(() => new Board());
        public static Board Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public int NumberOfHorizontalCells { get; set; }
        public int NumberOfVerticalCells { get; set; }
        public List<Robot> Robots { get; set; }
    }

}
