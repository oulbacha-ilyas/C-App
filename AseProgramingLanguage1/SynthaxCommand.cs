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
        List<string> Var_liste = new List<string>();
        public const string UnkownCommand = "Unkown comman.";
        public const string Command_withNoParameters = "This command shouldn't have any parameter.";
        public const string Command_WithParameter = "This command should have parameters.";
        public const string CircleShouldHaveRadius = "Cirlce should have a radius of type int.";
        public const string RadiusShouldBeInt = "The radius should be an int.";
        public const string RectangleParametersNumber = "Rectangle should have two parameters:width and heigth.";
        public const string WidthInt = "The width should be an int.";
        public const string HeigthInt = "The theigth should be an int.";
        public const string TriangleParametersNumber = "Tiangle should have 4 parameters;x and y for each point.";
        public const string TrianglePoints = "Triangle points:x and y should be of type int.";
        public const string PositionsParameters = "the positions should have two parameters:x and y.";
        public const string Point_X_Parse = "the  parameter x should be of type int.";
        public const string Point_Y_Parse = "the parameter Y should be of type int.";
        public const string ColorParametersMatch = "This color name matches the existing ones;black,blue,green,red.";
        public const string ColorParametersDoesnotMatch = "The color name does not match any of the existing;only one color can be choosen at a time.";
        public const string FillParametersMatch = "Only two options can be choosen: On or Off.";
        public const string CorrectSynthax = "There are no synthax errors at the moment.";
        public const string Point1_X_parse= "The first parameter should be an int.";
        public const string Point1_Y_parse= "The second parameter should be an int.";
        public const string Point2_X_parse= "The third parameter should be an int.";
        public const string Point2_Y_parse= "The fourth parameter should be an int.";
        public const string Var_dec_structure = "The variable declaration should be as following:varName = value.";
        public const string Var_dec_value = "The assigned value should be an integer.";
        public const string Var_dec_sign = "The variable should be declared using =.";
        public const string Var_dec_name1 = "The variable name should of type string and not empty.";
        public const string Var_dec_name2 = "The variable name can contain only letters an numbers.";
        public const string Var_dec_elements_number = "The variable declaration should have 3 elements.";
        public const string Var_dec_length = "The declaration command should be 4 elements.";
        public const string loop_limit_dec = "The loop limit is not declared.";
        public const string loop_operator = "The loop operator should be <.";
        public const string loop_counter = "The loop counter should be a variable.";
        public const string loop_syntax = "The while loop should contain 4 elements: while i < x.";
        public const string command_checked = "command checked and correct.";
        
      

        public const string Empty_command = "Type a command.";
        public void SynthaxCheck(string line)
        {
            string[] split; //declaring an arry that will handle values after the first split
            string[] parameters;//declaring an arry that will handle values after the second split
            line = line.ToLower().Trim();//ignores in spaces and lowerCase every letter
            if (line.Length == 0)
            {
                throw new System.ArgumentOutOfRangeException("parameters", line, Empty_command);

            }
                if (line.Equals("clear") || line.Equals("reset") || line.Equals("run"))
                {
                    /*if (split.Length == 2)
                    {*/
                    throw new System.ArgumentOutOfRangeException("parameters", line, CorrectSynthax);
                    /*}
                    else  throw new System.ArgumentOutOfRangeException("parameters", split[1], CorrectSynthax);

                    /* if (split.Length == 1)
                     {  command = split[0]; }
                     else throw new System.ArgumentOutOfRangeException("command",command,Command_withNoParameters);
                    */
                }
                else if (line.Equals("circle") || line.Equals("rectangle") || line.Equals("triangle") || line.Equals("moveto") || line.Equals("drawto") || line.Equals("fill") || line.Equals("fillcolor") || line.Equals("drawcolor") || line.Equals("var")) { throw new ArgumentOutOfRangeException("line", line, Command_WithParameter); }
                //else { throw new System.ArgumentOutOfRangeException("Unown command", line, UnkownCommand); }
            else
            {
                split = line.Split(' ');
                string command;
                command = split[0];
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
                            if (res1 == true || res2 == true)
                            {
                                throw new System.ArgumentOutOfRangeException("correct parameters", split[1], CorrectSynthax);
                            }
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
                            throw new System.ArgumentOutOfRangeException("radius", split[1], RadiusShouldBeInt);
                        }
                        else { throw new System.ArgumentOutOfRangeException("radius", split[1], CorrectSynthax); }
                    }
                    else if (split.Length > 2) { new System.ArgumentOutOfRangeException("radius", split[1], CircleShouldHaveRadius); }

                }
                else if (command.Equals("moveto") || command.Equals("drawto"))
                {
                    if (split.Length == 2)
                    {
                        parameters = split[1].Split(',');
                        if (parameters.Length == 2)
                        {
                            bool res1 = int.TryParse(parameters[0], out int r1);
                            bool res2 = int.TryParse(parameters[1], out int r2);
                            if (res1 != true) { throw new System.ArgumentOutOfRangeException("Parameter type", parameters[0], Point_X_Parse); }
                            if (res2 != true) { throw new System.ArgumentOutOfRangeException("Parameter type", parameters[1], Point_Y_Parse); }

                            if (res1 == true && res2 == true) { throw new System.ArgumentOutOfRangeException("Parameter type", split[1], CorrectSynthax); }
                            /*   
                            if (res1 != true) { 
                                //throw new System.ArgumentOutOfRangeException("Parameter type", parameters[0], PositionsPointsParse); 
                                if (res2 != true) { throw new System.ArgumentOutOfRangeException("Parameter", parameters[1], PositionsPointsParse);}
                            }
                            if (res1 == true || res2==true ) 
                            { throw new System.ArgumentOutOfRangeException("Correct position", split[1], CorrectSynthax);} 
                           */
                        }
                        else throw new System.ArgumentOutOfRangeException("Parameters number", split[1], PositionsParameters);
                    }
                    else if (split.Length > 2) { throw new System.ArgumentOutOfRangeException("Parameters number", split[1], PositionsParameters); }


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
                            if (res1 != true) { throw new System.ArgumentOutOfRangeException("points", parameters[0], Point1_X_parse); }
                            if (res2 != true) { throw new System.ArgumentOutOfRangeException("point", parameters[1], Point1_Y_parse); }
                            if (res3 != true) { throw new System.ArgumentOutOfRangeException("points ", parameters[2], Point2_X_parse); }
                            if (res4 != true) { throw new System.ArgumentOutOfRangeException("points", parameters[3], Point2_Y_parse); }
                            if (res1 == true && res2 == true && res3 == true && res4 == true)
                            {
                                { throw new System.ArgumentOutOfRangeException("Correct position", split[1], CorrectSynthax); }
                            }

                        }
                        else throw new System.ArgumentOutOfRangeException("Parameters Number", parameters, TriangleParametersNumber);
                    }
                    if (split.Length > 2) { throw new ArgumentOutOfRangeException("Parameters number", split[1], TriangleParametersNumber); }

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
                        throw new System.ArgumentOutOfRangeException("Color Name", split[1], CorrectSynthax);
                    }
                    else throw new System.ArgumentOutOfRangeException("Color Name", split[1], ColorParametersDoesnotMatch);

                }
                else if (command.Equals("fill"))
                {
                    if (split[1].Equals("on") || split[1].Equals("off"))
                    {
                        throw new System.ArgumentOutOfRangeException("Fill choice", split[1], CorrectSynthax);
                    }
                    else throw new System.ArgumentOutOfRangeException("Fill choice", split[1], FillParametersMatch);
                }
                else if (command.Equals("var"))
                {
                    // 
                    if (split.Length == 4)
                    {
                        
                        bool res2 = int.TryParse(split[1], out int r2);
                        bool res3 = int.TryParse(split[3], out int r3);
                        
                        if (split[1].All(v => char.IsLetterOrDigit(v)))
                        {
                            if (res2 == true || split[1].Length==0)
                            {
                                throw new System.ArgumentOutOfRangeException("var name", split[1], Var_dec_name1);
                            }
                            
                            if (split[2].Equals("="))
                            {
           
                                    if (res3 == true)
                                    {
                                    Var_liste.Add(split[1]);
                                    throw new System.ArgumentOutOfRangeException("var value", split[3], command_checked);
                                }
                                    else
                                    {
                                    throw new System.ArgumentOutOfRangeException("var value", split[3], Var_dec_value);
                                    }
                               
                            }
                                else throw new System.ArgumentOutOfRangeException("var assing", split[2], Var_dec_sign);
                        }
                        else { throw new System.ArgumentOutOfRangeException("var name", split[1], Var_dec_name2); }
                    }
                    else
                    {
                        throw new System.ArgumentOutOfRangeException("Unknown command", split,Var_dec_structure);
                    }
                
                }
                else if (command.Equals("while"))
                {
                    
                    if (split.Length==4 )
                    {
                        bool res1 = int.TryParse(split[1], out int r1);
                        bool res3 = int.TryParse(split[3], out int r3);
                        if  (split[1].All(i => char.IsLetterOrDigit(i)))
                        {
                            if (res1 != true)
                            {

                                if (split[2].Equals("="))
                                {
                                    if (res3 != true)
                                    {

                                        if (Var_liste.Contains(split[3]) != false)
                                        {
                                            throw new System.ArgumentOutOfRangeException("while limit", split[3], loop_limit_dec);
                                        }

                                    }

                                }
                                throw new System.ArgumentOutOfRangeException("while limit", split, loop_operator);

                            }
                            throw new System.ArgumentOutOfRangeException("loop counter", split[1], loop_counter);
                        }
                        throw new System.ArgumentOutOfRangeException("loop counter", split[1], loop_counter);



                    }
                    throw new System.ArgumentOutOfRangeException("loop syntax", line, loop_syntax);

                }
                {
                throw new System.ArgumentOutOfRangeException("Unknown command", line, UnkownCommand);
                }
            }

        }
    }
}
