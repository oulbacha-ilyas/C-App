using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    class ParseCommand
    {
        public string line { get; }
        public string command { get; }
        public int param1 { get; }
        public int param2 { get; }
        public int param3 { get; }
        public int param4 { get; }
        public string param5 { get; }


        // create an object with 3 attributes:command,params
        public ParseCommand(string line)
        {
            this.line = line;
            string[] split;
            string[] parameters;
            line = line.ToLower().Trim();
            split = line.Split(' ');
            string command;
            command = split[0];
            if (command.Equals("rectangle"))
            {
                parameters = split[1].Split(',');
                string width = parameters[0];
                string length = parameters[1];
                this.param1 = Int32.Parse(width);
                this.param2 = Int32.Parse(length);
            }
            else if (command.Equals("circle"))
            {
                string radius = split[1];
                this.param1 = Int32.Parse(radius);
            }
            else if (command.Equals("moveto") || command.Equals("drawto"))
            {
                parameters = split[1].Split(',');
                string end_x = parameters[0];
                string end_y = parameters[1];
                this.param1 = Int32.Parse(end_x);
                this.param2 = Int32.Parse(end_y);


            }
            else if (command.Equals("triangle"))
            {
                parameters = split[1].Split(',');
                string point1x = parameters[0];
                string point1y = parameters[1];
                string point2x = parameters[2];
                string point2y = parameters[3];
                this.param1 = Int32.Parse(point1x);
                this.param2 = Int32.Parse(point1y);
                this.param3 = Int32.Parse(point2x);
                this.param4 = Int32.Parse(point2y);

            }
            else if (command.Equals("clear") || command.Equals("reset"))
            {
                this.command = split[0];
            }
            else if (command.Equals("drawcolor") )
            {
                string colors = split[1];
                this.param5 = colors;

                this.command = split[0];
            }
            else if (command.Equals("fill"))
            {
                string OnOff = split[1];//only one parameter(On or Off) is taken after the commmand
                this.param5 = OnOff; 

                this.command = split[0];
            }
            else if (command.Equals("fillcolor"))
            {
                string fillcolor = split[1];//only one parameter(On or Off) is taken after the commmand
                this.param5 = fillcolor;

                this.command = split[0];
            }
            else throw new ArgumentOutOfRangeException("the syntax is incorrect");
            this.command = split[0];
        }
        public ParseCommand()
        {
            this.param1 = param1;
            this.param2 = param1;
        }
    }
}
