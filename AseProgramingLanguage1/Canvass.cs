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
        int start_x = 0;
        int start_y =0; //it each time the form is launcher,will set the drawing to start in (0,0) then it can be changed using moveTo()
        int end_x = 0;
        int end_y =0;
        
        public Canvass(Graphics g)
        {
            this.g = g;
            //this.start_x=start_y=0;
            myPen = new Pen(Color.Black, 1);
            turtlePen = new Pen(Color.Red, 5);
            //Point turtle = new Point();

        }

        // drawing a line between tow points:the starting point (0,0) and another point defined by the user
        public void drawTo(int end_x, int end_y)
        {
            
            g.DrawLine(myPen, start_x, start_y, end_x, end_y);
            //start_x = end_x; //the pen will start where the last drawing ended.
            //start_x = end_y;
            moveTo(end_x, end_y);

        }
        public void DrawRectangle(int lateral1, int lateral2)
        {
            
            g.DrawRectangle(myPen, start_x, start_y, start_x + lateral1, start_y + lateral2);
           // start_x = end_x;
           // start_y = end_y;
            //start_x +=width ; //the pen will start where the last drawing ended.
            //start_y += length;
        }
        /*public void drawEllipse(int start_x,int start_y)
        {
            
        }*/
        public void moveTo(int end_x, int end_y)
        {
            start_x = end_x;
            start_y = end_y;
            g.DrawEllipse(turtlePen, start_x, start_y, 2, 2);
            
           

        }
        public void DrawCircle(float radius) // the circle is not drawn from the last position of moveTo,but the center is shifted
        {
            
            float width;
            float higth;
            width = higth = radius;
            g.DrawEllipse(myPen,start_x,start_y,width,higth);
            //start_x = end_x;
            //start_y = end_y;
        }
        public void DrawTriangle(int point1x, int point1y,int point2x,int point2y)
        {

            g.DrawLine(myPen,start_x,start_y,point1x,point1y);
            g.DrawLine(myPen, point1x, point1y, point2x, point2y);
            g.DrawLine(myPen, point2x, point2y, start_x, start_y);
            // start_x = end_x;
            // start_y = end_y;
            //start_x +=width ; //the pen will start where the last drawing ended.
            //start_y += length;
        }

    }
}
        
        
		
		
        
     

    


