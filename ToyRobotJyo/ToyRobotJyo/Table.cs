using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotJyo
{
    public class Table
    {
        public int length;
        public int width;
        public bool IsValidPlacement(int x, int y) => x >= 0 && x < width && y >= 0 && y < length;
        public bool IsValidDirectionPlacement(int x, int y) => x >= 0 && x < width && y >= 0 && y < length;

        public bool IsValidDirection(string direction) => direction == "north" || direction == "south" || direction == "east" || direction == "west";

        public Table(int length, int width)
        {         
            this.length = length;
            this.width = width;
        }
    }
}
