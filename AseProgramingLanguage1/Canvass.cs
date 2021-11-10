using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AseProgramingLanguage1
{
    class Canvass
    {
        //instance data for the drawing tools: pen attributes,starting positions,graphics context
        Graphics g; //the drawing area 
        //Pen myPen;
        Pen myPen;
        int start_x, start_y; //it each time the form is launcher,will set the drawing to start in (0,0) then it can be changed using moveTo()
    
        public  Canvass(Graphics g)
        {
            this.g = g;
            this.start_x = start_y = 0;
            myPen = new Pen(Color.Black, 1);

        }
       
        
    }

}
