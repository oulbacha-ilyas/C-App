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
        
        public Form1()
        {
            InitializeComponent();

            myCanvass = new Canvass(Graphics.FromImage(OutputBitmap));// this will handle the drawing then pass it to the form

            int start_x = 0;
            int start_y = 0;
            int end_x = 0;
            int end_y = 0;

            myCanvass.moveTo(end_x, end_y);
            start_x = end_x;
            start_y = end_y;
        }



        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);

        }

       
                
        
    
        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            // parsing the input
            // rectangle 70,70
            string line = commandLine.Text;
            //line = text;
            string[] split;
            string command;
            string[] parameters;
            line = line.ToLower().Trim();
            split = line.Split(' ');
            command = split[0];
            parameters = split[1].Split(',');

            /*for (int n = 0; n <= parameters.Length; n++)
            {*/




                string parameter1 = parameters[0];
                string parameter2 = parameters[1];
                int param1 = Int32.Parse(parameter1);
                int param2 = Int32.Parse(parameter2);
               // Console.WriteLine("the input length is" + parameters.Length);
               // Console.WriteLine("your command is to draw " + shape + "with the parameters " + parameters[0] + "and" + parameters[1]);


            //}

            if (e.KeyCode==Keys.Enter)
            {
                
                //command = commandLine.Text.Trim().ToLower();// reads what is written in command Line, gets ride of spaces and convert the text to lower case
                if (command.Equals("line")==true)
                {
                    myCanvass.DrawLine(param1, param2);

                    //Console.WriteLine("a line is drawn");
                }
                else if (command.Equals("rectangle") == true)
                {
                    myCanvass.DrawRectangle(param1, param2);
                   // Console.WriteLine("a square is draws");
                }
                else if (command.Equals("moveto") == true)
                {
                    myCanvass.moveTo(param1, param2);
                }

                commandLine.Text = ""; // clear the command line after the ENTER KEY is pressed
                outputWindow.Refresh();// update the drawing area to avoid drawing over past draws

              
                
                
            }
        }

        private void commandLine_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
