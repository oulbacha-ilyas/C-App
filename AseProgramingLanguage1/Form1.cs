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
        int start_x = 10;
        int start_y = 10;
        int end_x = 10;
        int end_y = 10;
        public Form1()
        {
            InitializeComponent();

            myCanvass = new Canvass(Graphics.FromImage(OutputBitmap));// this will handle the drawing then pass it to the form
            
        }



        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);

        }

       
                
        
    
        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode==Keys.Enter)
            {
                string command = commandLine.Text.Trim().ToLower();// reads what is written in command Line, gets ride of spaces and convert the text to lower case
                if (command.Equals("line")==true)
                {
                    myCanvass.DrawLine(100, 100);

                    //Console.WriteLine("a line is drawn");
                }
                else if (command.Equals("rectangle") == true)
                {
                    myCanvass.DrawRectangle(50, 100);
                   // Console.WriteLine("a square is draws");
                }
               
                commandLine.Text = ""; // clear the command line after the ENTER KEY is pressed
                outputWindow.Refresh();// update the drawing area to avoid drawing over past draws
            }
        }
        

    }
}
