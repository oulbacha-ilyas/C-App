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
        }

       

        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
        }
    }
}
