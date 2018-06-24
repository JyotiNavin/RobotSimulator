using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToyRobotJyo
{
    public class ExecuteCommand
    {


        public Table Table = new Table(5, 5);
        public bool Place;
        public string Message = string.Empty;
        public string ErrorInputs = "Placement of Robot is not correctly defined.";
        public RobotMovements objRobotMovement;
        public string Start(string[] input)
        {
            objRobotMovement = new RobotMovements(Table);
            foreach (string inputmove in input)
            {
                if (Place)
                {
                    RobotMovement(inputmove);
                }
                else if (Regex.IsMatch(inputmove, "[PLACE]"))
                {
                    Place = true;
                    RobotMovement(inputmove);
                }
                if (Message == ErrorInputs)
                {
                    break;
                }
                if (Message.Length > 1)
                {
                    Console.WriteLine(Message);
                    Message = "";
                }
            }
            return Message;
        }

        public string RobotMovement(string inputmove)
        {
            if (Regex.IsMatch(inputmove, "^PLACE"))
            {
                string[] coordinates = inputmove.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (coordinates.Length == 4)
                {

                    int x = Convert.ToInt32(coordinates[1]);
                    int y = Convert.ToInt32(coordinates[2]);
                   
                    objRobotMovement.Place(x, y, coordinates[3]);

                }
                if (objRobotMovement.Toy == null)
                {
                    Message = ErrorInputs;
                }
            }
            else if (Regex.IsMatch(inputmove, "^MOVE") || Regex.IsMatch(inputmove, "^RIGHT") || Regex.IsMatch(inputmove, "^LEFT"))
            {
                objRobotMovement.RobotMoves(inputmove.ToLower());
            }
            else if (Regex.IsMatch(inputmove, "^REPORT"))
            {
                Message = objRobotMovement.Report();
            }
            else
            {
                Message = ErrorInputs;
            }
            return Message;
        }
    }
}
