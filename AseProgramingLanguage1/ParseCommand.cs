﻿using System;
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
        public string aftercommand { get; }
        public string radius { get; }
        public int param1 { get; }
        public int param2 { get; }
        public int param3 { get; }
        public int param4 { get; }
        public string param5 { get; }
        public string param6 { get; }
        public int val0 { get; }
        public int val1 { get; }
        public string oper1 { get; }
        public string val2 { get; }
        public string val3 { get; }
        public string counter { get; }
        public string width { get; }
        public string heigth { get; }
        public string p1 { get; }
        public string p2 { get; }
        public string p3 { get; }
        public string p4 { get; }
        public string color { get; }
        public string rgb1 { get; }
        public string rgb2 { get; }
        public string rgb3 { get; }
        public string M { get; }
        public string if_name { get; }


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
            string aftercommand;
            command = split[0]; //based on the first split,parse parameters based on command value;some commands may have no parameters,others may have more then 1
            aftercommand = split[1];
            if (command.Equals("rectangle"))
            {
                this.command = split[0];
                parameters = split[1].Split(',');
                //string width = parameters[0];
                //string length = parameters[1];
                this.width = parameters[0]; //parse the width value so it it can be used as an integer in the drawing method rectangle()
                this.heigth= parameters[1];
            }
            else if (command.Equals("circle"))
            {

                //string radius = split[1];
                this.command = split[0];
                //this.param1 = Int32.Parse(radius);
                this.radius = split[1];

            }
            else if (command.Equals("moveto") || command.Equals("drawto"))
            {
                this.command = split[0];
                parameters = split[1].Split(',');
                //string end_x = parameters[0];
                //string end_y = parameters[1];
                this.p1 = parameters[0];
                this.p2 = parameters[1];
            }
            else if (command.Equals("triangle"))
            {
                this.command = split[0];
                parameters = split[1].Split(',');
                this.p1 = parameters[0];
                this.p2 = parameters[1];
                this.p3 = parameters[2];
                this.p4 = parameters[3];

            }
            else if (command.Equals("clear") || command.Equals("reset") || command.Equals("run"))
            {
                this.command = split[0];
            }
            else if (command.Equals("drawcolor"))
            {
                //string colors = split[1];
                parameters = split[1].Split(',');
                if (parameters.Length == 3)
                {
                    this.command = split[0];
                    this.rgb1 = parameters[0];
                    this.rgb2 = parameters[1];
                    this.rgb3 = parameters[2];
                }
            }
            else if (command.Equals("fill"))
            {
                string OnOff = split[1];//only one parameter(On or Off) is taken after the commmand
                this.param5 = OnOff;

                this.command = split[0];
            }
            else if (command.Equals("fillcolor"))
            {
                /*string fillcolor = split[1];*///only one parameter(On or Off) is taken after the commmand
                parameters = split[1].Split(',');
                if (parameters.Length == 3)
                {
                    this.command = split[0];
                    this.rgb1 = parameters[0];
                    this.rgb2 = parameters[1];
                    this.rgb3 = parameters[2];
                }
            }
            else if(command.Count(char.IsLetterOrDigit) == 1) // declaring the variables
            //else if (command.Count(char.IsLetterOrDigit) == 1 || command.Count(char.IsLetterOrDigit) == 2/*command.Equals("var")*/)
            {
                if (split.Length == 3 )
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
                else if (split.Length == 5 ) //5 is the length of the synthax when there is an operator for calculating
                {
                    this.command = split[0];
                    this.val2 = split[2];
                    this.val3 = split[4];
                    this.oper1 = split[3];
                }
            }
            else if (command.Equals("while"))
            {
                this.command = split[0];
                this.param5 = split[1];  //will take the counter and consider it as a name of the while
                this.param6 = split[3];
            }
            else if (command.Equals("endwhile"))
            {
                this.command = split[0];
                this.counter = split[1];
            }
            else if (command.Equals("method"))
            {
                this.command = split[0];
                this.M = split[1];
            }
            else if (command.Equals("endmethod"))
            {
                this.command = split[0];
                this.M = split[1];
            }
            else if (command.Equals("if("))
            {
                this.command = split[0];
                this.if_name = split[1];  //will take the counter and consider it as a name of the while
                this.param5 = split[3]; // the first parameter
                this.oper1 = split[4]; //  the operator
                this.param6 = split[5]; //the second parameter
            }
            else if (command.Equals("endofif"))
            {
                this.command = split[0];
                this.if_name = split[1];
            }


        }
    }
}
