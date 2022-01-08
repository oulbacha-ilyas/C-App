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
        public string radius { get; }
        public int param1 { get; }
        public int param2 { get; }
        public int param3 { get; }
        public int param4 { get; }
        public string param5 { get; }
        public int val0 { get; }
        public int val1 { get; }
        public string oper1 { get; }
        public string val2 { get; }
        public string val3 { get; }
        public const string InvalidParsing = "Check synthax errors.";
        public const string Var_dec = "the val shoud be known.";
        // the constructor ParseCommand takes 1 argument line,then split it, extract arguments and parse them
        // the if statements are checking the synthax,if it is not respected,it returns an exception error


        public ParseCommand(string line)
        //input text is lowered,then trimed to ignore any spaces,then split to extract commands and parameters
        {
            this.line = line;


            string[] split;
            string[] parameters;
            line = line.ToLower().Trim();
            split = line.Split(' ');
            string command;
            command = split[0]; //based on the first split,parse parameters based on command value;some commands may have no parameters,others may have more then 1
            if (command.Equals("rectangle"))
            {
                parameters = split[1].Split(',');
                string width = parameters[0];
                string length = parameters[1];
                this.param1 = Int32.Parse(width); //parse the width value so it it can be used as an integer in the drawing method rectangle()
                this.param2 = Int32.Parse(length);
            }
            else if (command.Equals("circle"))
            {
                //string radius = split[1];
                //this.param1 = Int32.Parse(radius);
                this.radius = split[1];
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
            else if (command.Count(char.IsLetterOrDigit) == 1 || command.Count(char.IsLetterOrDigit) == 2/*command.Equals("var")*/)
            {
                if (split.Length == 3)
                {
                    //if the declared value is there,change its value
                    //if its not,declare a new one
                    bool res2 = int.TryParse(split[2], out int r2);
                    if (res2 == true && split[0].Length != 0)
                    {
                        this.command = split[0];
                        this.val0 = Int32.Parse(split[2]);
                        Console.WriteLine(" values parsed");


                    }
                    else if (split[2].Count(char.IsLetterOrDigit) == 1 || split[2].Count(char.IsLetterOrDigit) == 2)
                    {
                        this.command = split[0];
                        this.param5 = split[2];
                    }
                }
                else if (split.Length == 5) //5 is the length of the synthax when there is an operator for calculating
                {
                    this.command = split[0];
                    this.val2 = split[2];
                    this.val3 = split[4];
                    this.oper1 = split[3];
                }
            }
            else { Console.WriteLine("condition 3"); }

                    //this.command = split[0];
                    //this.param5 = split[1];
                    //this.param4 = Int32.Parse(split[3]);
                    //Variables var = new Variables(param5, param4);
                    //if (param4 > 0)
                    //{
                    //    Variables.Add(var);

                    //}
                    //else { throw new System.ArgumentOutOfRangeException("Synthax errors", command, InvalidParsing); }
                    //this.command = split[0];
        }
    }
}
