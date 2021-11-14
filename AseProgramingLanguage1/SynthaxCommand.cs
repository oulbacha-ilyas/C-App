using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    public class SynthaxCommand
    {
        public string line { get; }

        public SynthaxCommand(string line)
        {
            this.line = line;
        }
        public const string Command_withNoParameters = "This command shouldn't have any parameter";
        public const string Command_WithParameter = "This command should have parameters";
        public const string CircleShouldHaveRadius ="Cirlce should have a radius of type int";
        public const string RadiusShouldBeInt = "The radius should be an int";
        public const string RectangleParametersNumber = "Rectangle should have two parameters:width and heigth";
        public const string WidthInt = "The width should be an int";
        public const string HeigthInt = "The theigth should be an int";
        public const string TriangleParametersNumber= "Tiangle should have 4 parameters;x and y for each point";
        public const string TrianglePoints = "Triangle points:x and y should be of type int";
        public const string PositionsParameters = "the positions should have two parameters:x and y";
        public const string PositionsPointsParse = "the positions parameters should be of type int";
        public const string ColorParametersNumber = "Only one color name can be take";
        public const string ColorParametersMatch= "The color name does not match any of the existing";

        public void SynthaxCheck(string line)
        {
            //ParseCommand parse = new ParseCommand(line);
            //string line = "circle 40";
            //string linee;
            string[] split;
            string[] parameters;
            line = line.ToLower().Trim();
            if (line.Equals("circle") || line.Equals("rectangle") || line.Equals("triangle") || line.Equals("moveto") || line.Equals("drawto") || line.Equals("fill") || line.Equals("fillcolor") || line.Equals("drawcolor")) { throw new ArgumentOutOfRangeException("line", line, Command_WithParameter); }
            //string ine =line; //added for manipulating commands with no parameters
            split = line.Split(' ');
            string command;
            command = split[0];

            if (command.Equals("clear") || command.Equals("reset") || command.Equals("run"))
            {
                if (split.Length >=2)
                {
                    throw new System.ArgumentOutOfRangeException("parameters", split[1], Command_withNoParameters);
                }

                /* if (split.Length == 1)
                 {  command = split[0]; }
                 else throw new System.ArgumentOutOfRangeException("command",command,Command_withNoParameters);
                */
            }

            else
            if (command.Equals("rectangle"))
            {
                if (split.Length == 2)
                {
                    parameters = split[1].Split(',');
                    if (parameters.Length == 1) { throw new System.ArgumentOutOfRangeException("Width and Heigth ", split[1], RectangleParametersNumber); }
                    if (parameters.Length == 2)
                    {
                        bool res1 = int.TryParse(parameters[0], out int r1);
                        bool res2 = int.TryParse(parameters[1], out int r2);
                        if (res1 != true) { throw new System.ArgumentOutOfRangeException("width", parameters[0], WidthInt); }
                        if (res2 != true) { throw new System.ArgumentOutOfRangeException("width", parameters[0], HeigthInt); }
                        /*if (res1)
                        {
                            int width = Int32.Parse(parameters[0]);
                            if (res2)
                            {
                                int heigth = Int32.Parse(parameters[1]);
                            }
                            else throw new ArgumentOutOfRangeException("parameter 2 should be number");

                        }
                        else throw new ArgumentOutOfRangeException("parameter 1 should be number");
                       */
                    }
                    if (parameters.Length > 2) { throw new System.ArgumentOutOfRangeException("Width and Heigth ", parameters, RectangleParametersNumber); }

                }
                else if (split.Length > 2) { throw new ArgumentOutOfRangeException("Width and Heigth ", split[1], RectangleParametersNumber); }
                

               // string param1 = parameters[0];
               // string param2 = parameters[1];
                //bool res;
                //int r;
                
            }
            else if (command.Equals("circle"))
            {
                /*if (split.Length == 1 ) { new System.ArgumentOutOfRangeException("radius", split[0], CircleShouldHaveRadius); }
                 else */
                if (split.Length == 2) 
                {
                        bool res1 = int.TryParse(split[1], out int r1);
                    if (res1 != true)
                    {
                        throw new System.ArgumentOutOfRangeException("radius",split[1], RadiusShouldBeInt);
                    }
                }
                else if (split.Length>2){ new System.ArgumentOutOfRangeException("radius", split[1], CircleShouldHaveRadius); }
                




            }
            else if (command.Equals("moveto") || command.Equals("drawto"))
            {
                if (split.Length==2)
                {
                    parameters = split[1].Split(',');
                   if (parameters.Length==2)
                    {
                        bool res1 = int.TryParse(parameters[0], out int r1);
                        bool res2 = int.TryParse(parameters[1], out int r2);
                        if (res1 !=true){throw new System.ArgumentOutOfRangeException("Parameter type",parameters[0],PositionsPointsParse);}
                        if (res2 !=true){ throw new System.ArgumentOutOfRangeException("Parameter",parameters[1],PositionsPointsParse); }

                    }
                    else throw new System.ArgumentOutOfRangeException("Parameters number",split[1],PositionsParameters);
                }
                else if (split.Length > 2) { throw new System.ArgumentOutOfRangeException("Parameters number", split[1],PositionsParameters); }


            }
            else if (command.Equals("triangle"))
            {
               //if(split.Length == 1) { throw new System.ArgumentOutOfRangeException("Parameters number", split[1],TriangleParametersNumber); }
                if (split.Length == 2)
                {
                    parameters = split[1].Split(',');
                    if (parameters.Length == 4)
                    {
                        bool res1 = int.TryParse(parameters[0], out int r1);
                        bool res2 = int.TryParse(parameters[1], out int r2);
                        bool res3 = int.TryParse(parameters[2], out int r3);
                        bool res4 = int.TryParse(parameters[3], out int r4);
                        if (res1 != true) { throw new System.ArgumentOutOfRangeException("points", parameters[0], TrianglePoints); }
                        if (res2 != true) { throw new System.ArgumentOutOfRangeException("point", parameters[1], TrianglePoints); }
                        if (res3 != true) { throw new System.ArgumentOutOfRangeException("points ", parameters[2], TrianglePoints); }
                        if (res4 != true) { throw new System.ArgumentOutOfRangeException("points", parameters[3], TrianglePoints); }

                    }
                    else throw new System.ArgumentOutOfRangeException("Parameters Number", parameters, TriangleParametersNumber);
                }
                if (split.Length >2) { throw new ArgumentOutOfRangeException("Parameters number", split[1], TriangleParametersNumber); }





            }
            else if (command.Equals("drawcolor") || command.Equals("fillcolor"))
            {
                /* can be used for second part to add other colors
                object[] colors = { "black", "red", "blue", "green" };
                for (int i=0;i<=colors.Length; i++)
                {}
                */
                    if (split[1].Equals("black") || split[1].Equals("red") || split[1].Equals("blue") || split[1].Equals("green"))
                    {
                       
                    }
                    else throw new System.ArgumentOutOfRangeException("Color Name",split[1],ColorParametersMatch);

            }
            else if(command.Equals("fill"))
            {
                    if (split[1].Equals("on") || split[1].Equals("off"))
                    {
                        string param5 = split[1];
                    }
                    else throw new ArgumentOutOfRangeException("Unknown fill setting");
            }
            else  throw new ArgumentOutOfRangeException("Unknown command");

        }
    }
}
