using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AseProgramingLanguage1
{
    public partial class Form1 : Form
    {
        
        //the drawing will be in a bitmap then will be displayed in a pictureBox(outputWindow)
        Bitmap OutputBitmap = new Bitmap(700, 600);
        Canvass myCanvass;
        //Turtle turtle  = new Turtle();
        //int a = 0;
        //int b = 0;

        public Form1()
        {
            InitializeComponent();

            myCanvass = new Canvass(Graphics.FromImage(OutputBitmap));// this will handle the drawing then pass it to the form
            myCanvass.ChangeFill("off");// sets the Fill to default option:Off,the subsequent draws will be outlined til the Fill is changed to On
            string zer1 = 0.ToString();
            string zer2 = 0.ToString();
            string zer3 = 0.ToString();
            myCanvass.DrawColor(zer1,zer2,zer3);
            myCanvass.FillColor(zer1, zer2, zer3);
            int zero = 0;
            string zero_x = zero.ToString();
            string zero_y = zero.ToString();
            myCanvass.moveTo(zero_x, zero_y);  //myCanvass.moveTo(0, 0); //sets the turle position in the top left once Form1 is loaded
        }



        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
            //ParseCommand parse = new ParseCommand(commandLine.Text);
           //myCanvass.moveTo(penPosition.X, y) ;
        }

        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
           //Once the Enter key is pressed,SynthaxCheck is called for checking the synthax errors,then the parameters are parsedn,then drawing methods and commands can be called
            if (e.KeyCode == Keys.Enter)
            {
               //if (synthaxMessages.Text!="There are no synthax errors at the moment")
               // {synthaxMessages.Text="Check synthax first.";}
               // else
               // {
                   ParseCommand parse = new ParseCommand(commandLine.Text);
                // creating a parse Object using the constructor ParseCommand
                if (parse.command.Equals("drawto") == true)
                {
                    ClearCommand();
                    myCanvass.drawTo(parse.p1, parse.p2);

                }
                else if (parse.command.Equals("rectangle") == true)
                {
                    myCanvass.DrawRectangle(parse.width, parse.heigth);
                }
                else if (parse.command.Equals("moveto") == true)
                {
                    ClearCommand();
                    myCanvass.moveTo(parse.p1, parse.p2);
                }
                else if (parse.command.Equals("circle") == true)
                {

                    myCanvass.DrawCircle(parse.radius);
                }
                else if (parse.command.Equals("triangle") == true)
                {
                    myCanvass.DrawTriangle(parse.p1, parse.p2, parse.p3, parse.p4);
                }
                else if (parse.command.Equals("clear") == true) //clear all the drawing area of OutputWindow,including the turtle
                {
                    ClearCommand();
                    myCanvass.Clear();
                    outputWindow.Refresh();
                }
                else if (parse.command.Equals("reset") == true) // reset can use ClearCommand but the pen position is set to (0,0)
                {
                    ClearCommand();
                    myCanvass.Reset();

                }
                else if (parse.command.Equals("drawcolor") == true)
                {
                    //myCanvass.DrawColor(parse.param5); //calling the the drawing color setting method
                    myCanvass.DrawColor(parse.rgb1, parse.rgb2, parse.rgb3);
                }

                else if (parse.command.Equals("fill") == true)
                {
                    myCanvass.ChangeFill(parse.param5); //calling the fill setting method
                }
                else if (parse.command.Equals("fillcolor") == true)
                {
                    myCanvass.FillColor(parse.rgb1, parse.rgb2, parse.rgb3); //calling the fill color setting method
                }
                else if (parse.command.Equals("run") == true)//executes the programe typed into ProgramLines richBox
                {
                    //calling the fill color setting method
                    ExecuteCommandProgram();
                }


                //commandLine.Text = ""; // clear the command line after the ENTER KEY is pressed
                // update the drawing area to avoid drawing over past draws

                outputWindow.Refresh(); //refreshing the drawing area so the new drawings can appears after each command is passed
 
                }
            //}
        }

        private void ClearCommand() // clearing all the previous drawings
        {
            Graphics g = Graphics.FromImage(OutputBitmap);
            g.Clear(Color.Linen);

        }

    
        private void drawButton_Click(object sender, EventArgs e)//Once clicked,execute the program typed into ProgramLines richbox
        {
           
            if (synthaxMessages.Text == "")
            {
                List<string> synthaxMessagesList = new List<string>();
                try
                {
                    ExecuteCommandProgram();
                }
                catch (System.Exception argX1) //catching the whole exception message then extract only the customized message
                {

                    string trimMessage = argX1.Message.Trim();
                    string[] splitMessage;
                    splitMessage = trimMessage.Split('.');
                    if (splitMessage[0] != "There are no synthax errors at the moment")
                    {
                        synthaxMessagesList.Add("line : " + splitMessage[0]);//adding the message to the list of error messages concerning the typed program
                        synthaxMessages.Text = splitMessage[0];
                    }

                }
            }


        }
        private void ExecuteCommandProgram() 
        {
            int linesNumber = ProgramLines.Lines.Length;
            int loop_start_line =0;
            int loop_end_line =0;
            int iterations =0;
            for (int i = 0; i <= linesNumber - 1; i++) //the program is run line by line using,after checkeing the synthax and parsing the parameters
            {
                
                ParseCommand parse = new ParseCommand(ProgramLines.Lines[i]);

                //if while is off
                //if while is on ==> line i
                // while status on ==> read only
                //while off ==> line j
                //execute from i to j
                if (parse.command.Equals("while") == true)
                {
                    myCanvass.Create_while(parse.param5, parse.param6);
                    loop_start_line = i;
                    iterations = myCanvass.Get_iterations(parse.param6);
                    Console.WriteLine($"there are {iterations} iterations");
                    //iterations = parse.param6;
                }
                else if (parse.command.Equals("endwhile") == true)
                {
                    myCanvass.End_while(parse.counter);
                    loop_end_line = i;
                    int e = 0;
                    while (e <=iterations)
                    {
                        for (int j = loop_start_line+1; j <= loop_end_line-1; j++)
                        {
                            ParseCommand parse1 = new ParseCommand(ProgramLines.Lines[j]);
                            if (parse1.command.Equals("circle") == true)
                            {
                                
                                myCanvass.Mother_DrawCircle(parse1.radius);
                            }
                            else
                            if (parse1.command.Equals("rectangle") == true)
                            {
                                myCanvass.Mother_DrawRectangle(parse1.width, parse1.heigth);
                                
                            }
                            else if (parse1.command.Equals("triangle") == true)
                            {
                                myCanvass.Mother_DrawTriangle(parse1.p1, parse1.p2, parse1.p3, parse1.p4);
                            }
                            if (parse1.command.Equals("drawcolor") == true)
                            {

                                myCanvass.Mother_DrawColor(parse1.rgb1, parse1.rgb2, parse1.rgb3);
                                //calling the the drawing color setting method
                            }
                            if (parse1.command.Equals("fillcolor") == true)
                            {
                                myCanvass.Mother_FillColor(parse1.rgb1, parse1.rgb2, parse1.rgb1); //calling the fill color setting method
                            }
                            else if (parse1.command.Equals("drawto") == true)

                            {
                                ClearCommand();
                                //myCanvass.drawTo(parse.param1, parse.param2);
                                myCanvass.Mother_drawTo(parse1.p1, parse1.p2);
                            }
                            if (parse1.command.Equals("moveto") == true)
                            {
                                ClearCommand();
                                //myCanvass.moveTo(parse.p1, parse.p2);
                                myCanvass.Mother_moveTo(parse1.p1, parse1.p2);
                                outputWindow.Refresh();
                            }

                            else
                            {
                                string line1 = ProgramLines.Lines[j];
                                string[] dec;
                                string[] split1;
                                line1 = line1.ToLower().Trim();
                                split1 = line1.Split(' ');

                                int len = split1.Length;
                                if (split1.Length == 3)
                                {
                                    bool res0 = int.TryParse(split1[2], out int r0);
                                    if (res0)
                                    {
                                        //Canvass var_assign = new Canvass(parse.command, parse.val0);
                                        Console.WriteLine("assign called");
                                        myCanvass.Assign_var(parse1.command, parse1.val0);
                                    }
                                    else
                                    {
                                        //Variables var_check = new Variables(parse.command, parse.param5);
                                        //var_check.Check_Var(parse.command, parse.param5);
                                        Console.WriteLine(" check called");
                                        myCanvass.Check_Var(parse1.command, parse1.param5);

                                    }
                                }
                                else if (split1.Length == 5)
                                {
                                    myCanvass.Mother_Calcul_var(parse1.command, parse1.val2, parse1.oper1, parse1.val3);
                                    // myCanvass.Calcul_var(parse1.command, parse1.val2, parse1.oper1, parse1.val3);
                                }
                                
                            }
                            
                        }
                        Console.WriteLine(" for is executed");
                        e++;
                    

                    }
                    Console.WriteLine(" loop is executed");
                }
                else if (parse.command.Equals("drawto") == true)

                {
                    ClearCommand();
                    myCanvass.drawTo(parse.p1, parse.p2);
                }
                else if (parse.command.Equals("rectangle") == true)
                {
                    myCanvass.Mother_DrawRectangle(parse.width, parse.heigth);
                    //myCanvass.DrawRectangle(parse.param1, parse.param2);
                }
                else if (parse.command.Equals("moveto") == true)
                {
                    ClearCommand();
                    myCanvass.moveTo(parse.p1, parse.p2);

                    outputWindow.Refresh();
                }
                else if (parse.command.Equals("circle") == true)
                {
                    //myCanvass.DrawCircle(parse.radius);
                    myCanvass.Mother_DrawCircle(parse.radius);

                }
                else if (parse.command.Equals("triangle") == true)
                {
                    myCanvass.DrawTriangle(parse.p1, parse.p2, parse.p3, parse.p4);
                }
                else if (parse.command.Equals("clear") == true)
                {
                    ClearCommand();
                    myCanvass.Clear();
                    outputWindow.Refresh();
                }
                else if (parse.command.Equals("reset") == true) // reset can use ClearCommand but the pen position is set to (0,0)
                {
                    ClearCommand();
                    myCanvass.Reset();
                    //outputWindow.Refresh();
                }
                else if (parse.command.Equals("drawcolor") == true)
                {
        
                        myCanvass.DrawColor(parse.rgb1, parse.rgb2, parse.rgb3);
                         //calling the the drawing color setting method
                }
                else if (parse.command.Equals("fill") == true)
                {
                    myCanvass.ChangeFill(parse.param5); //calling the fill setting method
                }
                else if (parse.command.Equals("fillcolor") == true)
                {
                    myCanvass.Mother_FillColor(parse.rgb1, parse.rgb2, parse.rgb3); //calling the fill color setting method
                }
                else
                {
                    string line = ProgramLines.Lines[i];
                    string[] dec;
                    string[] split;
                    line = line.ToLower().Trim();
                    split = line.Split(' ');

                    int len = split.Length;
                    if (split.Length == 3)
                    {
                        bool res0 = int.TryParse(split[2], out int r0);
                        if (res0)
                        {
                            //Canvass var_assign = new Canvass(parse.command, parse.val0);
                            Console.WriteLine("assign called");
                            myCanvass.Assign_var(parse.command, parse.val0);
                        }
                        else
                        {
                            //Variables var_check = new Variables(parse.command, parse.param5);
                            //var_check.Check_Var(parse.command, parse.param5);
                            Console.WriteLine(" check called");
                            myCanvass.Check_Var(parse.command, parse.param5);

                        }
                    }
                    else if (split.Length == 5)
                    {
                        //myCanvass.Mother_Calcul_var(parse.command, parse.val2, parse.oper1, parse.val3);
                        myCanvass.Calcul_var(parse.command, parse.val2, parse.oper1, parse.val3);
                    }
                }
                
            }
            outputWindow.Refresh();

        }

        private void ProgramLines_TextChanged(object sender, EventArgs e)
        {
            int linesNumber = ProgramLines.Lines.Length;
            List<string> synthaxMessagesList = new List<string>();
            for (int i = 0; i <= linesNumber - 1; i++)
            {

                SynthaxCommand ProgramSynthax = new SynthaxCommand(ProgramLines.Lines[i]);
                //ProgramSynthax.SynthaxCheck(ProgramLines.Lines[i]);
                try
                {
                    ProgramSynthax.SynthaxCheck(ProgramLines.Lines[i]);
                }
                catch (System.Exception argX0) //catching the whole exception message then extract only the customized message
                {

                    string trimMessage = argX0.Message.Trim();
                    string[] splitMessage;
                    splitMessage = trimMessage.Split('.');
                    if (splitMessage[0] != "There are no synthax errors at the moment")
                    {
                        synthaxMessagesList.Add($"line {i + 1}: " + splitMessage[0]);//adding the message to the list of error messages concerning the typed program
                    }

                }
            }
            int l = synthaxMessagesList.Count;

            if (l == 0)
            {
                synthaxMessages.Text = "";
            }
            if (l == 1)
            {
                synthaxMessages.Text = synthaxMessagesList[0];
            }
            if (l == 2)
            {
                synthaxMessages.Text = synthaxMessagesList[0] + System.Environment.NewLine + synthaxMessagesList[1];
            }
            if (l == 3)
            {
                synthaxMessages.Text = synthaxMessagesList[0] + System.Environment.NewLine + synthaxMessagesList[1] + System.Environment.NewLine + synthaxMessagesList[2];
            }
            if (l == 4)
            {
                synthaxMessages.Text = synthaxMessagesList[0] + System.Environment.NewLine + synthaxMessagesList[1] + System.Environment.NewLine + synthaxMessagesList[2] + System.Environment.NewLine + synthaxMessagesList[3] + System.Environment.NewLine;
            }
            if (l == 5)
            {
                synthaxMessages.Text = synthaxMessagesList[0] + System.Environment.NewLine + synthaxMessagesList[1] + System.Environment.NewLine + synthaxMessagesList[2] + System.Environment.NewLine + synthaxMessagesList[3] + System.Environment.NewLine + synthaxMessagesList[4];
            }
        }



        private void synthaxButton_Click(object sender, EventArgs e) //runs the synthaxCheck for program typed into ProgramLines richbox
        {
            int linesNumber = ProgramLines.Lines.Length;
            //Console.WriteLine("number lines is" + linesNumber);
            List<string> synthaxMessagesList = new List<string>();
            for (int i = 0; i <= linesNumber - 1; i++)
            {

                SynthaxCommand ProgramSynthax = new SynthaxCommand(ProgramLines.Lines[i]);
                // ProgramSynthax.SynthaxCheck(ProgramLines.Lines[i]);
                try
                {
                    ProgramSynthax.SynthaxCheck(ProgramLines.Lines[i]);
                }
                catch (System.Exception argX0) //catching the whole exception message then extract only the customized message
                {

                    string trimMessage = argX0.Message.Trim();
                    string[] splitMessage;
                    splitMessage = trimMessage.Split('.');
                    synthaxMessagesList.Add($"line {i + 1}: " + splitMessage[0]); //adding the message to the list of error messages concerning the typed program
                }
            }
            int l = synthaxMessagesList.Count;
            Console.WriteLine($"there are {l} errors in this program");
            if (l==0)
            {
                synthaxMessages.Text = "No synthax errors at the moment";
            }
            if (l == 1)
            {
                synthaxMessages.Text = synthaxMessagesList[0];
            }
            if (l == 2)
            {
                synthaxMessages.Text = synthaxMessagesList[0] + System.Environment.NewLine + synthaxMessagesList[1];
            }
            if (l == 3)
            {
                synthaxMessages.Text = synthaxMessagesList[0] + System.Environment.NewLine + synthaxMessagesList[1] + System.Environment.NewLine + synthaxMessagesList[2];
            }
            if (l == 4)
            {
                synthaxMessages.Text = synthaxMessagesList[0] + System.Environment.NewLine + synthaxMessagesList[1] + System.Environment.NewLine + synthaxMessagesList[2] + System.Environment.NewLine + synthaxMessagesList[3] + System.Environment.NewLine;
            }
            if (l == 5)
            {
                synthaxMessages.Text = synthaxMessagesList[0] + System.Environment.NewLine + synthaxMessagesList[1] + System.Environment.NewLine + synthaxMessagesList[2] + System.Environment.NewLine + synthaxMessagesList[3] + System.Environment.NewLine + synthaxMessagesList[4];
            }
        }  

        private void commandLine_TextChanged(object sender, EventArgs e)
        {
            SynthaxCommand ProgramSynthax = new SynthaxCommand(commandLine.Text);
            //Canvass ckeck = new Canvass();
            // ProgramSynthax.SynthaxCheck(ProgramLines.Lines[i]);
            
            try
            {
                ProgramSynthax.SynthaxCheck(commandLine.Text);
               
            }
            catch (System.Exception argX0) //catching the whole exception message then extract only the customized message
            {

                string trimMessage = argX0.Message.Trim();
                string[] splitMessage;
                splitMessage = trimMessage.Split('.');
                synthaxMessages.Text= splitMessage[0];//adding the message to the list of error messages concerning the typed program
                
            }

        }
            
            
    

        private void synthaxMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void synthaxMessages_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
