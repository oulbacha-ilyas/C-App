using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    class ParseCommand
    {
        public static void parseCommand(string line)
        {
            string text = " circle 100,100";
            line = text;
            string[] split;
            string command;
            string[] parameters;
            line = line.ToLower().Trim();
            split = line.Split(' ');
            command = split[0];
            parameters = split[1].Split(',');
            string parameter1 = parameters[0];
            string parameter2 = parameters[1];
            int param1 = Int32.Parse(parameter1);
            int param2 = Int32.Parse(parameter2);
            Console.WriteLine("your command is to draw " + command + "with the parameters " + param1 + "and" + "param2");

            /*for (double n = 0; n <= parameters.Length; n++)
            {
        
            } */
        }
    }
}
