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
        Pen myPen, redPen, greenPen, bluePen;
        Pen turtlePen;
        Brush myBrush, redBrush, greenBrush, blueBrush;
        int start_x = 0;
        int start_y = 0; //it each time the form is launcher,will set the drawing to start in (0,0) then it can be changed using moveTo()
        int end_x = 0;
        int end_y = 0;
        //string fill = "off";
        //string defualtFill = "off";
        Turtle fillOnOff;
        Turtle Pen;
        Turtle Brush;
        List<Turtle> turtles = new List<Turtle>();
        List<Circles> Circles = new List<Circles>();
        List<Rectangles> Rectangles = new List<Rectangles>();
        List<Triangles> Triangles = new List<Triangles>();
        List<Lines> Lines = new List<Lines>();


        //variables setting
        public string varname { get; }
        public int varvalue { get; }
        public string varvar { get; }
        public const string Var_value = "The value assigned to the variable should be positive.";
        public const string Var_dec = "The value assigned to the variable should be a number or a declared variable.";
        List<Variables> var_list = new List<Variables>();

        public Canvass(Graphics g)
        {
            this.g = g;
            //this.start_x=start_y=0;
            myPen = new Pen(Color.Black, 1);
            redPen = new Pen(Color.Red, 1);
            greenPen = new Pen(Color.Green, 1);
            bluePen = new Pen(Color.Blue, 1);
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
          
            Lines line = new Lines(start_x,start_y,end_x,end_y,Pen.Fill);
            line.LinePoint_Type(end_x, end_y);
            Lines.Add(line);
            int l = Lines.Count;
            g.DrawLine(myPen, Lines[l - 1].X1, Lines[l - 1].Y1, Lines[l - 1].X2, Lines[l - 1].Y2) ; //drawing a line first,
            start_x = Lines[l-1].X2;
            start_y = Lines[l - 1].Y2;
            moveTo(Lines[l - 1].X2, Lines[l - 1].Y2);//then moving the turtle to the last point of the drawn line

        }

        public void DrawRectangle(int width, int heigth)
        {
            Rectangles rectangle = new Rectangles(start_x, start_y, width, heigth, fillOnOff.Fill, Pen.Fill, Brush.Fill);
            rectangle.Width_Heigth_Types(width, heigth);
            Rectangles.Add(rectangle);
            if (fillOnOff.Fill.Equals("off") == true)
            {
                g.DrawRectangle(myPen, start_x, start_y, width, heigth);

            }
            else if (fillOnOff.Fill.Equals("on") == true)
            {
                g.FillRectangle(myBrush, start_x, start_y, width, heigth);
            }
        }

        public void moveTo(int end_x, int end_y)
        {
            Turtle turtle = new Turtle(end_x, end_y);
            turtles.Add(turtle);
            int l = turtles.Count;
            start_x = end_x;
            start_y = end_y;
            g.DrawEllipse(turtlePen, turtles[l - 1].X, turtles[l - 1].Y, 1, 1);

            for (int i = 0; i < Lines.Count; i++)
            {   if (Lines[i].Pencolor == "black")
                { g.DrawLine(myPen, Lines[i].X1, Lines[i].Y1, Lines[i].X2, Lines[i].Y2); }
                if (Lines[i].Pencolor == "red")
                { g.DrawLine(redPen, Lines[i].X1, Lines[i].Y1, Lines[i].X2, Lines[i].Y2); }
                if (Lines[i].Pencolor == "blue")
                { g.DrawLine(bluePen, Lines[i].X1, Lines[i].Y1, Lines[i].X2, Lines[i].Y2); }
                if (Lines[i].Pencolor == "green")
                { g.DrawLine(greenPen, Lines[i].X1, Lines[i].Y1, Lines[i].X2, Lines[i].Y2); }
            }
                for (int i = 0; i < Circles.Count; i++)
            {
                if (Circles[i].Fill == "off")
                {
                    if (Circles[i].Pencolor == "black")
                    { g.DrawEllipse(myPen, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2); }
                    if (Circles[i].Pencolor == "red")
                    { g.DrawEllipse(redPen, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2); }
                    if (Circles[i].Pencolor == "green")
                    { g.DrawEllipse(greenPen, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2); }
                    if (Circles[i].Pencolor == "blue")
                    { g.DrawEllipse(bluePen, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2); }

                }
                else if (Circles[i].Fill == "on")
                {
                    if (Circles[i].Fillcolor == "black")
                        g.FillEllipse(myBrush, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);
                    if (Circles[i].Fillcolor == "red")
                        g.FillEllipse(redBrush, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);
                    if (Circles[i].Fillcolor == "green")
                        g.FillEllipse(greenBrush, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);
                    if (Circles[i].Fillcolor == "blue")
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
                    if (Rectangles[i].Fillcolor == "black")
                        g.FillRectangle(myBrush, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth);
                    if (Rectangles[i].Fillcolor == "red")
                        g.FillRectangle(redBrush, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth);
                    if (Rectangles[i].Fillcolor == "green")
                        g.FillRectangle(greenBrush, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth);
                    if (Rectangles[i].Fillcolor == "blue")
                        g.FillRectangle(blueBrush, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth);

                }
            }

            for (int i = 0; i < Triangles.Count; i++)
            {
                PointF[] TPoints = new PointF[]
       { new PointF { X = Triangles[i].X1,Y=Triangles[i].Y1 },
              new PointF { X = Triangles[i].X2,Y=Triangles[i].Y2},
              new PointF { X = Triangles[i].X3,Y=Triangles[i].Y3} };

                if (Triangles[i].Fill == "off")
                {
                    if (Triangles[i].Pencolor == "black")
                    { g.DrawPolygon(myPen, TPoints); }
                    if (Triangles[i].Pencolor == "red")
                    { g.DrawPolygon(redPen, TPoints); }
                    if (Triangles[i].Pencolor == "green")
                    { g.DrawPolygon(greenPen, TPoints); }
                    if (Triangles[i].Pencolor == "blue")
                    { g.DrawPolygon(bluePen, TPoints); }

                }
                else if (Triangles[i].Fill == "on")
                {
                    if (Triangles[i].Pencolor == "black")
                    { g.FillPolygon(myBrush, TPoints); }
                    if (Triangles[i].Pencolor == "red")
                    { g.FillPolygon(redBrush, TPoints); }
                    if (Triangles[i].Pencolor == "green")
                    { g.FillPolygon(greenBrush, TPoints); }
                    if (Triangles[i].Pencolor == "blue")
                    { g.FillPolygon(blueBrush, TPoints); }
                }
            }
        }

        public void DrawCircle(int radius) // the circle is not drawn from the last position of moveTo,but the center is shifted
        {
            float width;
            float higth;
            width = higth = radius * 2;
            Circles circle = new Circles(start_x, start_y, radius, fillOnOff.Fill, Pen.Fill, Brush.Fill);
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

        public void DrawTriangle(int point1x, int point1y, int point2x, int point2y)
        {

            Triangles triangle = new Triangles(start_x, start_y, point1x, point1y, point2x, point2y, fillOnOff.Fill, Pen.Fill, Brush.Fill);
            triangle.Tpoint1_TPoint2_Types(point1x, point1y, point2x, point2y);
            Triangles.Add(triangle);
            PointF[] TPoints = new PointF[]
        { new PointF { X = start_x,Y=start_y },
              new PointF {X= point1x , Y=point1y},
              new PointF {X=point2x, Y=point2y}
        };
            if (fillOnOff.Fill.Equals("off") == true)
            {

                g.DrawPolygon(myPen, TPoints);

            }
            else if (fillOnOff.Fill.Equals("on") == true)
            {
                g.FillPolygon(myBrush, TPoints);
            }
        }

        public void DrawColor(string pencolor)
        {
            Pen = new Turtle(pencolor);
            if (pencolor.Equals("red") == true)
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
            g.DrawLine(myPen, 10, 10, 150, 150);

        }
        public void Reset()
        {
            //g.FillEllipse(redBrush, 1, 1, 1, 1);
            start_x = 0;
            start_y = 0;
            //turtles.Clear();
            Circles.Clear();
            Triangles.Clear();
            Rectangles.Clear();
            g.DrawEllipse(turtlePen, start_x, start_y, 1, 1);

        }
        public void Clear()
        {
            //g.FillEllipse(redBrush, 1, 1, 1, 1);
            int l = turtles.Count;
            g.DrawEllipse(turtlePen, turtles[l-1].X, turtles[l - 1].Y, 1, 1);
            //turtles.Clear();
            Circles.Clear();
            Triangles.Clear();
            Rectangles.Clear();
        }



        // variables 
        public Canvass(string v,int x)
        {
            this.varname = v;
            this.varvalue = x;

        }
        public Canvass(string v, string x)
        {
            this.varname = v;
            this.varvar = x;
        }
        public void Check_Var(string v, string y)
        {
                if(var_list.Exists(e => e.varname == y))
                {
                int i = var_list.FindIndex(e => e.varname == y);
                int value_found = var_list[i].varvalue;
                Console.WriteLine(" var is there in "+i+" "+$"{value_found}");
                Console.WriteLine($" var {v} will take its value");
                Assign_var(v, value_found);
         
                }
            else { Console.WriteLine(" var is not there"); }


        }
        public void Assign_var(string v, int x)
        {
            Variables varibale = new Variables(v, x);
             if (var_list.Exists(e => e.varname == v))
                {
                    var_list.RemoveAll(e => e.varname == v);
                    Console.WriteLine(" var removed");
                    var_list.Add(varibale);
                    Console.WriteLine($"var {v} updated");
                }
                else 
                {
                var_list.Add(varibale);
                Console.WriteLine($" new var {v} added");
                }
        }
        public void Update_val(string v, int x)
        {
            if (var_list.Exists(e => e.varname == v))
            {
                int i = var_list.FindIndex(e => e.varname == v);
                Variables varibale = new Variables(v, x);
                Console.WriteLine("value assigne from another variable");
            }
            else { Console.WriteLine(" var is not there"); }
        }
        public void Calcul_var(string v, string x,string oper,string y)
        {
            int r=0;
            bool resx = int.TryParse(x, out int rx);
            bool resy = int.TryParse(y, out int ry);
            if(resx && resy)
            {
                if(oper=="+")
                {
                    r = Int32.Parse(x) + Int32.Parse(y);
                    if (r < 0)
                    {
                        Console.WriteLine("the first value should be greater than the second value");
                    }
                }
                else if(oper == "-")
                {
                    r = Int32.Parse(x) - Int32.Parse(y);
                    if(r<0)
                    {
                        Console.WriteLine("the first value should be greater than the second value");
                    }
                }
                else if (oper == "*")
                {
                    r = Int32.Parse(x)*Int32.Parse(y);
                    if (r < 0)
                    {
                        Console.WriteLine("both values should be positive");
                    }
                }
                else if (oper == "/")
                {
                    if(Int32.Parse(y) == 0)
                    {
                        Console.WriteLine("this operation cannot be performed");
                    }
                    else
                    {
                        r = Int32.Parse(x)/Int32.Parse(y);
                        if (r < 0)
                        {
                            Console.WriteLine("both values should be positive");
                        }
                    }
                    
                }
                
            }
            if (resx==false && resy)
            {
                if (var_list.Exists(e => e.varname == x))
                {
                    int i = var_list.FindIndex(e => e.varname == x);
                    int xf = var_list[i].varvalue;

                    if (oper == "+")
                    {
                        r = xf + Int32.Parse(y);
                        if (r < 0)
                        {
                            Console.WriteLine("the first value should be greater than the second value");
                        }
                    }
                    else if (oper == "-")
                    {
                        r = xf - Int32.Parse(y);
                        if (r < 0)
                        {
                            Console.WriteLine("the first value should be greater than the second value");
                        }
                    }
                    else if (oper == "*")
                    {
                        r = xf * Int32.Parse(y);
                        if (r < 0)
                        {
                            Console.WriteLine("both values should be positive");
                        }
                    }
                    else if (oper == "/")
                    {
                        if (Int32.Parse(y) == 0)
                        {
                            Console.WriteLine("this operation cannot be performed");
                        }
                        else
                        {
                            r = xf / Int32.Parse(y);
                            if (r < 0)
                            {
                                Console.WriteLine("both values should be positive");
                            }
                        }

                    }
                }
                else { Console.WriteLine($"var {x} is not there"); }

            }

            if (resx  && resy == false)
            {
                if (var_list.Exists(e => e.varname == y))
                {
                    int i = var_list.FindIndex(e => e.varname == y);
                    int yf = var_list[i].varvalue;

                    if (oper == "+")
                    {
                        r = Int32.Parse(x) + yf;
                        if (r < 0)
                        {
                            Console.WriteLine("the first value should be greater than the second value");
                        }
                    }
                    else if (oper == "-")
                    {
                        r = Int32.Parse(x)-yf ;
                        if (r < 0)
                        {
                            Console.WriteLine("the first value should be greater than the second value");
                        }
                    }
                    else if (oper == "*")
                    {
                        r = Int32.Parse(x)*yf;
                        if (r < 0)
                        {
                            Console.WriteLine("both values should be positive");
                        }
                    }
                    else if (oper == "/")
                    {
                        if (Int32.Parse(y) == 0)
                        {
                            Console.WriteLine("this operation cannot be performed");
                        }
                        else
                        {
                            r = Int32.Parse(x)/yf;
                            if (r < 0)
                            {
                                Console.WriteLine("both values should be positive");
                            }
                        }

                    }
                }
                else { Console.WriteLine($"var {y} is not there"); }

            }

            if (resx==false && resy == false)
            {
                if (var_list.Exists(e => e.varname == y))
                {
                    if(var_list.Exists(e => e.varname == y))
                    {
                        int i = var_list.FindIndex(e => e.varname == y);
                        int yf = var_list[i].varvalue;
                        int j = var_list.FindIndex(e => e.varname == x);
                        int xf = var_list[j].varvalue;

                        if (oper == "+")
                        {
                            r = xf + yf;
                            if (r < 0)
                            {
                                Console.WriteLine("the first value should be greater than the second value");
                            }
                        }
                        else if (oper == "-")
                        {
                            r = xf - yf;
                            if (r < 0)
                            {
                                Console.WriteLine("the first value should be greater than the second value");
                            }
                        }
                        else if (oper == "*")
                        {
                            r = xf*yf;
                            if (r < 0)
                            {
                                Console.WriteLine("both values should be positive");
                            }
                        }
                        else if (oper == "/")
                        {
                            if (yf == 0)
                            {
                                Console.WriteLine("this operation cannot be performed");
                            }
                            else
                            {
                                r = xf/yf;
                                if (r < 0)
                                {
                                    Console.WriteLine("both values should be positive");
                                }
                            }

                        }

                    }
                    else { Console.WriteLine($" var {y} not declared yet"); }
                }
                else { Console.WriteLine($"var {x} not declared yet"); }

            }

            Variables varibale = new Variables(v, r);
            Assign_var(v, r);
            Console.WriteLine($"variable {v} calculated,res {r}");
            //if (var_list.Exists(e => e.varname == x))
            //{
            //    int i = var_list.FindIndex(e => e.varname == x);
            //    int value_found = var_list[i].varvalue;
            //    Console.WriteLine(" var is there in " + i + " " + $"{value_found}");
            //    Console.WriteLine($" var {v} will take its value");
            //    Assign_var(v, value_found);


            //    var_list.Add(varibale);
            //}
        }
    }
}
        
        
		
		
        
     

    


