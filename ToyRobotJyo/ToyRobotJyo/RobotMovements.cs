using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotJyo
{
    public class RobotMovements
    {

        public Robot Toy;
        public Table Surface;

        public RobotMovements(Table table)
        {
            Surface = table;
        }

        public void Place(int x, int y, string direction)
        {
            if (Surface.IsValidDirection(direction.ToLower()))
            {
                if (Surface.IsValidPlacement(x, y))
                {
                    Toy = new Robot
                    {
                        direction = direction.ToLower(),
                        x = x,
                        y = y
                    };
                }
            }

            }

        public void RobotMoves(string movement)
        {
            int xtemp = Toy.x;
            int ytemp = Toy.y;
            switch (movement)
            {
                case "move":

                    
                    Toy.MoveStep();
                    if (!Surface.IsValidPlacement(Toy.x, Toy.y))
                    {
                        Toy.x=xtemp;
                        Toy.y=ytemp;
                    }
                        break;
                case "right":
                    Toy.TurnRight();
                    break;
                case "left":
                    Toy.TurnLeft();
                    break;
            }
        }

        public string Report()
        {
            return Toy.Report();
        }
    }
}
