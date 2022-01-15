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
        List<Variables> Var_liste = new List<Variables>() { };
        string[] names;
        public const string UnkownCommand = "Unkown comman.";
        public const string Command_withNoParameters = "This command shouldn't have any parameter.";
        public const string Command_WithParameter = "This command should have parameters.";
        public const string CircleShouldHaveRadius = "Cirlce should have only one parameter, radius, of type string.";
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
        public const string lopp_limit_format = "The loop limit should be a number or a declared variable.";
        public const string Var_dec = "The variable needs to be declared before use.";
        public const string Var_name = "The variable name should be either letters or a combination of letters and numbers.";
        public const string logical_operators = "The logical operators can be either +,-,* or /.";
        public const string WHformat = "The height and height can be either a letter,a number or combination of them.";
        public const string RGBcode_length = "The color  rgb code should be of 3 digits or declared variables.";
        public const string RGBcode_values = "The color be variables should be letters or a combination of letters and digits.";
        public const string end_while = "The loop should be ended with a valid counter.";
        public const string method_name = "A method should have one name and one only.";
        public const string method_name_type = "The method name can be only letters or combination of letters and digit.";

        public const string Empty_command = "Type a command.";
        public void SynthaxCheck(string line)
        {
            var names = new List<string>() {};
            string[] split; //declaring an arry that will handle values after the first split
            string[] parameters;//declaring an arry that will handle values after the second split
            line = line.ToLower().Trim();//ignores in spaces and lowerCase every letter

            if (line.Length == 0)
            {
                throw new System.ArgumentOutOfRangeException("parameters", line, Empty_command);

            }
                if (line.Equals("clear") || line.Equals("reset") || line.Equals("run"))
                {
                // throw new System.ArgumentOutOfRangeException("parameters", line, CorrectSynthax);
            }
                else if (line.Equals("circle") || line.Equals("rectangle") || line.Equals("triangle") || line.Equals("moveto") || line.Equals("drawto") || line.Equals("fill") || line.Equals("fillcolor") || line.Equals("drawcolor") || line.Equals("var")) { throw new ArgumentOutOfRangeException("line", line, Command_WithParameter); }
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
                       // if (parameters.Length == 1) { throw new System.ArgumentOutOfRangeException("Width and Heigth ", split[1], RectangleParametersNumber); }
                        if (parameters.Length == 2)
                        {
                            foreach (string p in parameters)

                            {
                                if (parameters[0].All(v => char.IsLetterOrDigit(v))==false || parameters[0].Length == 0 || parameters[1].All(v => char.IsLetterOrDigit(v))==false || parameters[1].Length == 0)
                                {
                                    throw new ArgumentOutOfRangeException("Width and Heigth ", split[1], Var_name);
                                }
                            }
                        }
                        else { throw new System.ArgumentOutOfRangeException("Width and Heigth ", parameters, RectangleParametersNumber); }

                    }
                    else if (split.Length > 2) { throw new ArgumentOutOfRangeException("Width and Heigth ", split[1], RectangleParametersNumber); }


                }
                else if (command.Equals("circle"))
                {
                if(split[1].All(v => char.IsLetterOrDigit(v)))
                    {
                    }
                    else { throw new System.ArgumentOutOfRangeException("radius", split[1], Var_name); }
                    if (split.Length == 2)
                    {
                        if (split[1].All(char.IsLetterOrDigit)==true)
                        {
                            if(split[1].Length==0)
                            {
                                throw new System.ArgumentOutOfRangeException("radius", split[1], CircleShouldHaveRadius);
                            }
                            
                        }
                        else
                        {
                            throw new System.ArgumentOutOfRangeException("radius", split[1], Var_name);
                        }

                    }
                    else if (split.Length > 2) {throw new System.ArgumentOutOfRangeException("radius", split[1], CircleShouldHaveRadius); }

                }
                else if (command.Equals("moveto") || command.Equals("drawto"))
                {
                    if (split.Length == 2)
                    {
                        parameters = split[1].Split(',');
                        if (parameters.Length == 2)
                        {
                            if (parameters[0].All(char.IsLetterOrDigit) == false || parameters[0].Length == 0 || parameters[1].All(char.IsLetterOrDigit) == false || parameters[1].Length == 0)
                            {
                                throw new System.ArgumentOutOfRangeException("Parameters number", parameters, Var_name);
                            }
                        }
                        else throw new System.ArgumentOutOfRangeException("Parameters number", split[1], PositionsParameters);
                    }
                    else if (split.Length > 2) { throw new System.ArgumentOutOfRangeException("Parameters number", split[1], PositionsParameters); }


                }
                else if (command.Equals("triangle"))
                {
                    if (split.Length == 2)
                    {
                        parameters = split[1].Split(',');
                        if (parameters.Length == 4)
                        {
                            if (parameters[0].All(char.IsLetterOrDigit) == false || parameters[0].Length == 0 || parameters[1].All(char.IsLetterOrDigit) == false || parameters[1].Length == 0 || parameters[2].All(char.IsLetterOrDigit) == false || parameters[2].Length == 0 || parameters[3].All(char.IsLetterOrDigit) == false || parameters[3].Length == 0)
                            {
                                throw new System.ArgumentOutOfRangeException("Parameters number", parameters, Var_name);
                            }
                        }
                        else throw new System.ArgumentOutOfRangeException("Parameters Number", parameters, TriangleParametersNumber);
                    }
                    if (split.Length > 2) { throw new ArgumentOutOfRangeException("Parameters number", split[1], TriangleParametersNumber); }

                }
                else if (command.Equals("drawcolor") || command.Equals("fillcolor"))
                {
                    parameters = split[1].Split(',');
                    if (parameters.Length != 3)
                    {
                        throw new System.ArgumentOutOfRangeException("RGB Code", parameters, RGBcode_length);
                    }
                    foreach(string para in parameters)
                    {
                        if(para.All(v => char.IsLetterOrDigit(v) ==false))
                        {
                            throw new System.ArgumentOutOfRangeException("RGB Code", parameters, RGBcode_values);
                        }
                    }
                    
                }
                else if (command.Equals("fill"))
                {
                    if (split[1].Equals("on") || split[1].Equals("off"))
                    {
                        throw new System.ArgumentOutOfRangeException("Fill choice", split[1], CorrectSynthax);
                    }
                    else throw new System.ArgumentOutOfRangeException("Fill choice", split[1], FillParametersMatch);
                }
                else if (command.Count(char.IsLetterOrDigit) == 1 || command.Count(char.IsLetterOrDigit) == 2/*command.Equals("var")*/)
                {
                    if (split.Length == 3)
                    {
                        bool res0 = int.TryParse(split[0], out int r0);
                        bool res2 = int.TryParse(split[2], out int r2);

                        if (split[0].All(v => char.IsLetterOrDigit(v)))
                        {
                            if (res0 != true && split[0].Length != 0)
                            {
                                if (split[1].Equals("="))
                                {
                                }
                                else { throw new System.ArgumentOutOfRangeException("var assing", split[1], Var_dec_sign); }
                            }
                            else { throw new System.ArgumentOutOfRangeException("var name", split[0], Var_dec_name1); }

                        }
                        else { throw new System.ArgumentOutOfRangeException("var name", split[0], Var_dec_name2); }
                    }
                    else if (split.Length > 3)
                    {


                        int l = split.Length;
                        int i = 2;
                        int j = 3;
                        while (i <= l)
                        {

                            if (split[i].All(v => char.IsLetterOrDigit(v)))
                            {
                                bool resi = int.TryParse(split[i], out int r1);
                                if (resi == false)
                                {
                                }
                                else
                                {
                                    Console.WriteLine("value can be calculated");

                                }

                            }
                            else { throw new System.ArgumentOutOfRangeException("var name", split[i], Var_name); }

                            i = i + 2;
                        }

                        while (j < l)
                        {
                            if (split[j].Equals("+") || split[j].Equals("-") || split[j].Equals("*") || split[j].Equals("/"))
                            {
                                Console.WriteLine($"{j} :the operator is correct");
                            }
                            else { throw new System.ArgumentOutOfRangeException("var assing", split[j], logical_operators); }
                            j = j + 2;
                        }
                    }
                    else { throw new System.ArgumentOutOfRangeException("var assing", split, loop_syntax); }
                }

                else if (command.Equals("while"))
                {

                    if (split.Length == 4)
                    {
                        bool res1 = int.TryParse(split[1], out int r1);
                        bool res3 = int.TryParse(split[3], out int r3);
                        if (split[1].All(i => char.IsLetterOrDigit(i)))
                        {
                            if (res1 != true)
                            {

                                if (split[2].Equals("<"))
                                {
                                    if (res3 != true)
                                    {
                                        if (split[3].All(x => char.IsLetterOrDigit(x)))
                                        {
                                        }
                                        else { throw new System.ArgumentOutOfRangeException("while limit", split[3], lopp_limit_format); }
                                            
                                    }
                                    else { };

                                }
                                else { throw new System.ArgumentOutOfRangeException("while limit", split[2], loop_operator); };


                            }
                            else { throw new System.ArgumentOutOfRangeException("loop counter", split[1], loop_counter); }
                        }
                        else { throw new System.ArgumentOutOfRangeException("loop counter", split[1], loop_counter); }



                    }
                    else { throw new System.ArgumentOutOfRangeException("loop syntax", split, loop_syntax);}

                }
                else if( command.Equals("endwhile"))
                {
                    if (split.Length == 2)
                    {
                        bool res1 = int.TryParse(split[1], out int r1);
                        if (split[1].All(i => char.IsLetterOrDigit(i)))
                        {
                            if (res1 == true)
                            {
                                throw new System.ArgumentOutOfRangeException("loop syntax", split, loop_counter);
                            }
                        }
                        else { throw new System.ArgumentOutOfRangeException("loop syntax", split, loop_counter); }
                    }
                    else { throw new System.ArgumentOutOfRangeException("loop syntax", split, end_while); }
                }
                 else if (command.Equals("method"))
                {
                    if (split.Length == 2)
                    {
                        bool res1 = int.TryParse(split[1], out int r1);
                        if (split[1].All(i => char.IsLetterOrDigit(i)))
                        {
                            if (res1 == true)
                            {
                                throw new System.ArgumentOutOfRangeException("loop syntax", split, method_name_type);
                            }
                        }
                        else { throw new System.ArgumentOutOfRangeException("loop syntax", split, method_name_type); }
                    }
                    else { throw new System.ArgumentOutOfRangeException("loop syntax", split, method_name ); }
                }
                else if (command.Equals("endmethod"))
                {
                    if (split.Length == 2)
                    {
                        bool res1 = int.TryParse(split[1], out int r1);
                        if (split[1].All(i => char.IsLetterOrDigit(i)))
                        {
                            if (res1 == true)
                            {
                                throw new System.ArgumentOutOfRangeException("loop syntax", split, method_name_type);
                            }
                        }
                        else { throw new System.ArgumentOutOfRangeException("loop syntax", split, method_name_type); }
                    }
                    else { throw new System.ArgumentOutOfRangeException("loop syntax", split, method_name); }
                }

                else { throw new System.ArgumentOutOfRangeException("Unknown command", line, UnkownCommand); }
            }

        }
    }
}
