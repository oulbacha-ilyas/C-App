﻿using System;
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
        Pen turtlePen;
        int start_x,start_y; //it each time the form is launcher,will set the drawing to start in (0,0) then it can be changed using moveTo()
        int end_x,end_y;
        public Canvass(Graphics g)
        {
            this.g = g;
            this.start_x=start_y=0;
            myPen = new Pen(Color.Black, 1);
            turtlePen = new Pen(Color.Red, 5);
            //Point turtle = new Point();

        }

        // drawing a line between tow points:the starting point (0,0) and another point defined by the user
        public void drawTo(int end_x, int end_y)
        {
            g.DrawLine(myPen, start_x, start_y, end_x, end_y);
            start_x= end_x; //the pen will start where the last drawing ended.
            start_y = end_y;

        }
        public void DrawRectangle(int width, int length)
        {
        
            g.DrawRectangle(myPen, start_x, start_y, start_x + width, start_y + length);
            start_x = end_x;
            start_y = end_y;
            //start_x +=width ; //the pen will start where the last drawing ended.
            //start_y += length;
        }
        /*public void drawEllipse(int start_x,int start_y)
        {
            
        }*/
        public void moveTo(int end_x, int end_y)
        {

            g.DrawEllipse(turtlePen, end_x, end_y, 2, 2);
            start_x = end_x;
            start_y = end_y;

        }
        public void DrawCircle(float radius) // the circle is not drawn from the last position of moveTo,but the center is shifted
        {
            float width;
            float higth;
            width = higth = radius;
            g.DrawEllipse(myPen,start_x,start_y,width,higth);
        }

    }
}
        
        
		
		
        
     

    


