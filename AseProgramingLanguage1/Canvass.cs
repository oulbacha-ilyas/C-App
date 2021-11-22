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
        Pen myPen,redPen,greenPen,bluePen;
        Pen turtlePen;
        Brush myBrush,redBrush,greenBrush,blueBrush;
        int start_x = 0;
        int start_y =0; //it each time the form is launcher,will set the drawing to start in (0,0) then it can be changed using moveTo()
        int end_x = 0;
        int end_y =0;
        //string fill = "off";
        //string defualtFill = "off";
        Turtle fillOnOff;
        Turtle Pen;
        Turtle Brush;
        List<Turtle> turtles = new List<Turtle>();
        List<Circles> Circles= new List<Circles>();
        List<Rectangles> Rectangles = new List<Rectangles>();


        public Canvass(Graphics g)
        {
            this.g = g;
            //this.start_x=start_y=0;
            myPen = new Pen(Color.Black, 1);
            redPen=new Pen(Color.Red,1);
            greenPen=new Pen(Color.Green,1);
            bluePen=new Pen(Color.Blue,1);
            turtlePen = new Pen(Color.Red, 5);
            //Point turtle = new Point();
            // Brush myBrush = new Brush();
            myBrush = new SolidBrush(Color.Black);
            redBrush = new SolidBrush(Color.Red);
            greenBrush = new SolidBrush(Color.Green);
            blueBrush = new SolidBrush(Color.Blue);
        }

        public void ChangeFill(string Fill) // the circle is not drawn from the last position of moveTo,but the center is shifted
        {
            // outline or fill off is the default value of drawing,but this method should be called before DrawRectangle
            fillOnOff = new Turtle(Fill);
        }

        // drawing a line between tow points:the starting point (0,0) and another point defined by the user
        public void drawTo(int end_x, int end_y)
        {          
            g.DrawLine(myPen, start_x, start_y, end_x, end_y); //drawing a line first,
            moveTo(end_x, end_y);//then moving the turtle to the last point of the drawn line
        }

        public void DrawRectangle(int width, int heigth)
        {
            Rectangles rectangle = new Rectangles(start_x, start_y, width,heigth, fillOnOff.Fill, Pen.Fill, Brush.Fill);
            rectangle.Width_Heigth_Types(width,heigth);
            Rectangles.Add(rectangle);
            if (fillOnOff.Fill.Equals("off") == true)
            {
                g.DrawRectangle(myPen, start_x, start_y,width,heigth);
          
            }
            else if (fillOnOff.Fill.Equals("on") == true)
            {
                g.FillRectangle(myBrush, start_x, start_y,width, heigth);            
            }
        }
       
        public void moveTo(int end_x, int end_y)
        {
            Turtle turtle = new Turtle(end_x, end_y);
            turtles.Add(turtle);
            start_x = end_x;
            start_y = end_y;
            g.DrawEllipse(turtlePen, start_x, start_y, 1,1);
            for (int i=0;i<Circles.Count;i++)
            {
                if (Circles[i].Fill == "off")
                {
                    if( Circles[i].Pencolor=="black")
                      {g.DrawEllipse(myPen, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);}
                    if( Circles[i].Pencolor=="red")
                      {g.DrawEllipse(redPen, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);}
                    if( Circles[i].Pencolor=="green")
                      {g.DrawEllipse(greenPen, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);}
                    if( Circles[i].Pencolor=="blue")
                      {g.DrawEllipse(bluePen, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);}

                }
                else if (Circles[i].Fill == "on")
                {
                    if( Circles[i].Fillcolor=="black")
                      g.FillEllipse(myBrush, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);
                    if( Circles[i].Fillcolor=="red")
                      g.FillEllipse(redBrush, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);
                    if( Circles[i].Fillcolor=="green")
                      g.FillEllipse(greenBrush, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);
                    if( Circles[i].Fillcolor=="blue")
                      g.FillEllipse(blueBrush, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);

                }
            }
            for (int i = 0; i < Rectangles.Count; i++)
            {
                if (Rectangles[i].Fill == "off")
                {
                    if (Rectangles[i].Pencolor == "black")
                    { g.DrawRectangle(myPen, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth); }
                    if (Rectangles[i].Pencolor == "red")
                    { g.DrawRectangle(redPen, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth); }
                    if (Rectangles[i].Pencolor == "green")
                    { g.DrawRectangle(greenPen, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth); }
                    if (Rectangles[i].Pencolor == "blue")
                    { g.DrawRectangle(bluePen, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth); }

                }
                else if (Rectangles[i].Fill == "on")
                {
                    if (Circles[i].Fillcolor == "black")
                        g.FillRectangle(myBrush, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth);
                    if (Circles[i].Fillcolor == "red")
                        g.FillRectangle(redBrush, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth);
                    if (Circles[i].Fillcolor == "green")
                        g.FillRectangle(greenBrush, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth);
                    if (Circles[i].Fillcolor == "blue")
                        g.FillRectangle(blueBrush, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth);

                }
            }

        }

        public void DrawCircle(int radius) // the circle is not drawn from the last position of moveTo,but the center is shifted
        {      
            float width;
            float higth;
            width = higth = radius*2;
            Circles circle = new Circles(start_x, start_y, radius, fillOnOff.Fill,Pen.Fill,Brush.Fill);
            circle.Radius_Type(radius);
            Circles.Add(circle);
            
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
        }

        public void DrawColor(string pencolor)
        {
            Pen = new Turtle(pencolor);
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
            Brush = new Turtle(fillcolor);
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
        
        
		
		
        
     

    


