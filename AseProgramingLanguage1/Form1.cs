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
            myCanvass.ChangeFill("off");                                                        //myCanvass.moveTo(turtle.a, turtle.b);





            //start_x = end_x;
            //start_y = end_y;
        }



        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
            //ParseCommand parse = new ParseCommand(commandLine.Text);
            //myCanvass.moveTo(0, 0) ;


        }





        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
   
            if (e.KeyCode == Keys.Enter)
            {
                ParseCommand parse = new ParseCommand(commandLine.Text);
                
                //command = commandLine.Text.Trim().ToLower();// reads what is written in command Line, gets ride of spaces and convert the text to lower case
                if (parse.command.Equals("drawto") == true)
                {
                    myCanvass.drawTo(parse.param1, parse.param2);

                    //Console.WriteLine("a line is drawn");
                }
                else if (parse.command.Equals("rectangle") == true)
                {
                    myCanvass.DrawRectangle(parse.param1, parse.param2);
                    // Console.WriteLine("a square is draws");
                }
                else if (parse.command.Equals("moveto") == true)
                {
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
                else if (parse.command.Equals("clear") == true)
                {
                    ClearCommand();
                    outputWindow.Refresh();
                }
                else if (parse.command.Equals("reset") == true) // reset can use ClearCommand but the pen position is set to (0,0)
                {
                    ClearCommand();
                    myCanvass.moveTo(0, 0);
                    outputWindow.Refresh();
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
                else if (parse.command.Equals("run") == true)
                {
                    //calling the fill color setting method
                    ExecuteCommandProgram();
                }


                //commandLine.Text = ""; // clear the command line after the ENTER KEY is pressed
                // update the drawing area to avoid drawing over past draws


                outputWindow.Refresh();

            }
            
        }






        private void ClearCommand() // clearing all the previous drawings
        {
            Graphics g = Graphics.FromImage(OutputBitmap);
            g.Clear(Color.Linen);

        }

    

        private void drawButton_Click(object sender, EventArgs e)
        {
            ExecuteCommandProgram();
        }
        private void ExecuteCommandProgram()
        {
            int linesNumber = ProgramLines.Lines.Length;
            Console.WriteLine("number lines is" + linesNumber);
            for (int i = 0; i <= linesNumber - 1; i++)
            {

                ParseCommand parse = new ParseCommand(ProgramLines.Lines[i]);

                Console.WriteLine(ProgramLines.Lines[i]);
                if (parse.command.Equals("drawto") == true)
                {
                    myCanvass.drawTo(parse.param1, parse.param2);

                    //Console.WriteLine("a line is drawn");
                }
                else if (parse.command.Equals("rectangle") == true)
                {
                    myCanvass.DrawRectangle(parse.param1, parse.param2);
                    // Console.WriteLine("a square is draws");
                }
                else if (parse.command.Equals("moveto") == true)
                {
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
                else if (parse.command.Equals("clear") == true)
                {
                    ClearCommand();
                    outputWindow.Refresh();
                }
                else if (parse.command.Equals("reset") == true) // reset can use ClearCommand but the pen position is set to (0,0)
                {
                    ClearCommand();
                    myCanvass.moveTo(0, 0);
                    outputWindow.Refresh();
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

            }
            outputWindow.Refresh();


            /*int r = Int32.Parse(commandLines.Text);
            myCanvass.DrawCircle(r);
            Console.WriteLine("does something happened?"+commandLines.Text);
            outputWindow.Refresh();*/
            /////::::
            /* if (e.KeyCode == Keys.Enter)
                {
            int r = Int32.Parse(commandLines.Text);
            myCanvass.DrawCircle(r);

                outputWindow.Refresh();// update the drawing area to avoid drawing over past draws
            */
        }

        private void ProgramLines_TextChanged(object sender, EventArgs e)
        {

        }

        private void synthaxButton_Click(object sender, EventArgs e)
        {

            SynthaxCommand synthax = new SynthaxCommand(commandLine.Text);
            synthax.SynthaxCheck(commandLine.Text);
        }
    }
    

}
