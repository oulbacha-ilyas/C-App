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
            myCanvass.DrawColor("black");
            myCanvass.FillColor("black");
            myCanvass.moveTo(0, 0);  //myCanvass.moveTo(0, 0); //sets the turle position in the top left once Form1 is loaded
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
               if (synthaxMessages.Text!="There are no synthax errors at the moment")
                {synthaxMessages.Text="Check synthax first.";}
                else
                {
                   ParseCommand parse = new ParseCommand(commandLine.Text);
                     // creating a parse Object using the constructor ParseCommand
                 
                if (parse.command.Equals("drawto") == true)
                {
                        ClearCommand();
                    myCanvass.drawTo(parse.param1, parse.param2);

                }
                else if (parse.command.Equals("rectangle") == true)
                {
                    myCanvass.DrawRectangle(parse.param1, parse.param2);
                }
                else if (parse.command.Equals("moveto") == true)
                {
                    ClearCommand();
                    myCanvass.moveTo(parse.param1, parse.param2);
                }
                else if (parse.command.Equals("circle") == true)
                {
                    
                    myCanvass.DrawCircle(parse.param1);
                }
                else if (parse.command.Equals("triangle") == true)
                {
                    myCanvass.DrawTriangle(parse.param1, parse.param2, parse.param3, parse.param4);
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
                    myCanvass.DrawColor(parse.param5); //calling the the drawing color setting method
                }
                else if (parse.command.Equals("fill") == true)
                {
                    myCanvass.ChangeFill(parse.param5); //calling the fill setting method
                }
                else if (parse.command.Equals("fillcolor") == true)
                {
                    myCanvass.FillColor(parse.param5); //calling the fill color setting method
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
            }
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
                ExecuteCommandProgram();
            }

        }
        private void ExecuteCommandProgram() 
        {
            int linesNumber = ProgramLines.Lines.Length;
            
            for (int i = 0; i <= linesNumber - 1; i++) //the program is run line by line using,after checkeing the synthax and parsing the parameters
            {

                ParseCommand parse = new ParseCommand(ProgramLines.Lines[i]);

               
                if (parse.command.Equals("drawto") == true)
                {
                    ClearCommand();
                    myCanvass.drawTo(parse.param1, parse.param2);
                }
                else if (parse.command.Equals("rectangle") == true)
                {
                    myCanvass.DrawRectangle(parse.param1, parse.param2);
                    // Console.WriteLine("a square is draws");
                }
                else if (parse.command.Equals("moveto") == true)
                {
                    ClearCommand();
                    myCanvass.moveTo(parse.param1, parse.param2);
                  
                    outputWindow.Refresh();
                }
                else if (parse.command.Equals("circle") == true)
                {
                    myCanvass.DrawCircle(parse.param1);
                }
                else if (parse.command.Equals("triangle") == true)
                {
                    myCanvass.DrawTriangle(parse.param1, parse.param2, parse.param3, parse.param4);
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
                    myCanvass.DrawColor(parse.param5); //calling the the drawing color setting method
                }
                else if (parse.command.Equals("fill") == true)
                {
                    myCanvass.ChangeFill(parse.param5); //calling the fill setting method
                }
                else if (parse.command.Equals("fillcolor") == true)
                {
                    myCanvass.FillColor(parse.param5); //calling the fill color setting method
                }
                else if (parse.command.Equals("var")== true)
                {
                    Console.WriteLine("var is declared");
                }

            }
            outputWindow.Refresh();

        }

        private void ProgramLines_TextChanged(object sender, EventArgs e)
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
