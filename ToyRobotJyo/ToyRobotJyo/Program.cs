using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotJyo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] input = File.ReadAllLines("test.txt");
                Program main = new Program();
                ExecuteCommand command = new ExecuteCommand();
                Console.WriteLine(command.Start(input));
            }
            catch (Exception ex)
            {
                Console.WriteLine("File Doesn't exist" ,ex.Message);
            }
        }


    }
}
