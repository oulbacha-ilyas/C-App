using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    public class ParseCommand
    {
        public string line { get; }
        public string command { get; }
        public int param1 { get; }
        public int param2 { get; }
        public int param3 { get; }
        public int param4 { get; }
        public string param5 { get; }


        // the constructor ParseCommand takes 1 argument line,then split it, extract arguments and parse them
        // the if statements are checking the synthax,if it is not respected,it returns an exception error
        
        
        public ParseCommand(string line) // for commands with no parameters
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
            else if (command.Equals("clear") || command.Equals("reset") || command.Equals("run"))
            {
                this.command = split[0];
            }
            else if (command.Equals("drawcolor"))
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
            else { throw new ArgumentOutOfRangeException("the syntax is incorrect");
                Console.WriteLine("this is an error message");
            }
            this.command =split[0];
           
        }
       
        /*public ParseCommand(string line)
        {
            this.line = line;
            string[] split;
            string[] parameters;
            line = line.ToLower().Trim();
            split = line.Split(' ');
            string command;
            command = split[0];
            parameters = split[1].Split(',');
 
            this.param1 = Int32.Parse(parameters[0]);
            this.param2 = Int32.Parse(parameters[1]);
            this.param3 = Int32.Parse(parameters[2]);
            this.param4 = Int32.Parse(parameters[3]);
            this.param5 = split[0];
        }
       */
        /*
        public ParseCommand()
        {
            this.param1 = param1;
            this.param2 = param1;
        }
      
        public ParseCommand(string c,int x) //for commands with one parameter
        {
            this.command = c;
            this.param1 = x;
        }
        public ParseCommand(string c, string  cl) //for commands with a string parameter(fill on)
        {
            this.command = c;
            this.param5 = cl;
        }
    public ParseCommand(string c,int x,int y) // command with tow arguments
        {
            this.command = c;
            this.param1 = x;
            this.param2 = y;
        }
        public ParseCommand(string c, int x, int y,int z,int w)
        {
            this.command = c;
            this.param1 = x;
            this.param2 = y;
            this.param1 = z;
            this.param2 = y;
        }
        
        /*public void SynthaxCheck()
         {
             ParseCommand inputtext = new ParseCommand(line);
             //string command = inputtext.command;
             object[] values = { (string) command };
             foreach( var value in values)
             {
                 Type tp = value.GetType();
                 if (tp.Equals(typeof(string)))

                 {
                     Console.WriteLine("command synthax is correct");
                 }
                 else throw new ArgumentOutOfRangeException("command synthax is not correct,it should be composed of caracters only");
             }
         }
        */
        
       
    }
}
