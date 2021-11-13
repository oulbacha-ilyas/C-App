using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using System.Drawing.TextureBrush;

namespace AseProgramingLanguage1
{
    public class Canvass
    {
        //instance data for the drawing tools: pen attributes,starting positions,graphics context
        Graphics g; //the drawing area 
        //Pen myPen;
        Pen myPen;
        Pen turtlePen;
        Brush myBrush;
        int start_x = 0;
        int start_y =0; //it each time the form is launcher,will set the drawing to start in (0,0) then it can be changed using moveTo()
        int end_x = 0;
        int end_y =0;
        //string fill = "off";
        //string defualtFill = "off";
        Turtle fillOnOff; 



        public Canvass(Graphics g)
        {
            this.g = g;
            //this.start_x=start_y=0;
            myPen = new Pen(Color.Black, 1);
            turtlePen = new Pen(Color.Red, 5);
            //Point turtle = new Point();
            // Brush myBrush = new Brush();
            myBrush = new SolidBrush(Color.Green);
           

        }
        public void ChangeFill(string Fill) // the circle is not drawn from the last position of moveTo,but the center is shifted
        {
            // outline or fill off is the default value of drawing,but this method should be called before DrawRectangle
            fillOnOff = new Turtle(Fill);
            
            Console.WriteLine("youve choosen fill" + Fill);

        }

        // drawing a line between tow points:the starting point (0,0) and another point defined by the user
        public void drawTo(int end_x, int end_y)
        {
            
            g.DrawLine(myPen, start_x, start_y, end_x, end_y);
            //start_x = end_x; //the pen will start where the last drawing ended.
            //start_x = end_y;
            moveTo(end_x, end_y);

        }
        public void DrawRectangle(int width, int higth)
        {

            

            if (fillOnOff.Fill.Equals("off") == true)
            {
                g.DrawRectangle(myPen, start_x, start_y,width,higth);
          
            }
            else if (fillOnOff.Fill.Equals("on") == true)
            {
                g.FillRectangle(myBrush, start_x, start_y,width, higth);
                
            }
            else throw new ArgumentOutOfRangeException("You need to choose fill on or fill off for the shape drawing method");
                

        }
       
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
            width = higth = radius*2;
            //g.DrawEllipse(myPen,start_x-(radius/2),start_y-(radius/2),width*2,higth*2);
            if (fillOnOff.Fill.Equals("off") == true)
            {
                g.DrawEllipse(myPen, start_x - radius, start_y - radius, width, higth);
            }
            else if (fillOnOff.Fill.Equals("on") == true)
            {
                g.FillEllipse(myBrush, start_x - radius, start_y - radius, width, higth);
            }
            else throw new ArgumentOutOfRangeException("You need to choose fill on or fill off for the shape drawing method");
           
        }
        public void DrawTriangle(int point1x, int point1y,int point2x,int point2y)
        {
            PointF[] triangle = new PointF[]
        { new PointF { X = start_x,Y=start_y },
              new PointF {X= point1x , Y=point1y},
              new PointF {X=point2x, Y=point2y}
        };
            if (fillOnOff.Fill.Equals("off") == true)
            {
            
                g.DrawPolygon(myPen, triangle);
               
            }
             else if (fillOnOff.Fill.Equals("on") == true)
            {
                g.FillPolygon(myBrush, triangle);
            }
            else throw new ArgumentOutOfRangeException("You need to choose fill on or fill off for the shape drawing method");



            // start_x = end_x;
            // start_y = end_y;
            //start_x +=width ; //the pen will start where the last drawing ended.
            //start_y += length;
        }
        public void DrawColor(string pencolor)
        {
            if (pencolor.Equals("red")==true)
            {
                myPen = new Pen(Color.Red);
            }
            else if (pencolor.Equals("green") == true)
            {
                myPen = new Pen(Color.Green);
            }
            else if (pencolor.Equals("blue") == true)
            {
                myPen = new Pen(Color.Blue);
            }
            else if (pencolor.Equals("black") == true)
            {
                myPen = new Pen(Color.Black);
            }
        }

        public void FillColor(string fillcolor)
        {
            if (fillcolor.Equals("red") == true)
            {
                myBrush = new SolidBrush(Color.Red);
            }
            else if (fillcolor.Equals("green") == true)
            {
                myBrush = new SolidBrush(Color.Green);
            }
            else if (fillcolor.Equals("blue") == true)
            {
                myBrush = new SolidBrush(Color.Blue);
            }
            else if (fillcolor.Equals("black") == true)
            {
                myBrush = new SolidBrush(Color.Black);
            }
        }
        public void drawline()
        {
            g.DrawLine(myPen,10, 10, 150, 150);

        }

    }
}
        
        
		
		
        
     

    


