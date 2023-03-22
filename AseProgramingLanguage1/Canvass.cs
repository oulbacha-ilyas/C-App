﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        List<Circles> Loop_Circles = new List<Circles>();

        List<Rectangles> Rectangles = new List<Rectangles>();
        List<Triangles> Triangles = new List<Triangles>();
        List<Lines> Lines = new List<Lines>();

        List<Variables> var_list = new List<Variables>(); // variables list
        Variables default_loop = new Variables("default", 0, "off");
        Variables default_statement = new Variables("default", 0, "off");
        List<Variables> counters = new List<Variables>(); //while counters list
        List<Variables> ifstatements = new List<Variables>(); //if counters list



        //variables setting
        public string S { get; }

        public const string Var_value = "The value assigned to the variable should be positive.";
        public const string Var_dec = "The value assigned to the variable should be a number or a declared variable.";
        public const string counter_var = "To end up  a while,use the while counter that has been used at the opening.";
        public const string iterations_var = "Iterations should be a digit or a declared variable.";
        public const string counter_dec = "A loop with the same counter already exist,use another one.";
        public const string values_comp = "The differenece between the two parameters should be positive.";
        public const string calc_result = "The operation cannot be performed.";
        public const string var_dec = "At least one of the variables is not declared.";
        public const string if_var2 = "The second parameter is not declared yet.";
        public const string if_dec = "An If statement with the same name already exist,use another one.";
        public const string if_var1 = "The first parameter is not declared yet.";
        public const string loop_ended = "This loop is already closed.";
        public const string if_var_list = "One of the parameters is not properly declared.";
        public const string if_name_check = "To end up an if statement,use the while counter that has been used at the opening.";






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
            myBrush = new SolidBrush(Color.FromArgb(0, 0, 0));
            redBrush = new SolidBrush(Color.Red);
            greenBrush = new SolidBrush(Color.Green);
            blueBrush = new SolidBrush(Color.Blue);
            counters.Add(default_loop);
            ifstatements.Add(default_statement);
        }
        public Canvass()
        {

        }
        public Canvass(string s)
        {
            this.S = s;
        }
        public void ChangeFill(string Fill) // 
        {
            // outline or fill off is the default value of drawing,but this method should be called before DrawRectangle
            fillOnOff = new Turtle(Fill);
        }

        // drawing a line between tow points:the starting point (0,0) and another point defined by the user

        //drawto methods
        public void Mother_drawTo(string end_x, string end_y)
        {
            //int[] para = Get_Whith_height(w,h);
            int end = counters.Count;
            if (counters[end - 1].status == "on")
            {
                Console.WriteLine("flag On waiting");
            }
            else            //if the command is outside a loop
            {
                Console.WriteLine("flag on go");
                drawTo(end_x, end_y);
                Console.WriteLine($"1 rectangle out of loop :w {end_x} h {end_y}");
            }
        }
        public void drawTo(string end_x, string end_y)
        {
            int[] para = Get_Whith_height(end_x, end_y);

            int l = Lines.Count;
            //g.DrawLine(myPen, Lines[l - 1].X1, Lines[l - 1].Y1, Lines[l - 1].X2, Lines[l - 1].Y2); //drawing a line first,
            //start_x = Lines[l - 1].X2;
            //start_y = Lines[l - 1].Y2;
            //string x = Lines[l - 1].X2.ToString();
            //string y = Lines[l - 1].X2.ToString();
            //moveTo(x, end_yy);//then moving the turtle to the last point of the drawn line

            g.DrawLine(myPen, para[0], para[1], start_x, start_y); //drawing a line first,
            Lines line = new Lines(para[0], para[1], start_x, start_y, Pen.R, Pen.G, Pen.B);
            Lines.Add(line);
            //start_x = para[0];
            //start_y = para[1];
            //moveTo(para[0].ToString(), para[1].ToString());
            //string x = Lines[l - 1].X2.ToString();
            //string y = Lines[l - 1].X2.ToString();

        }

        // rectangles
        public void Mother_DrawRectangle(string w, string h)
        {
            //int[] para = Get_Whith_height(w,h);
            int end = counters.Count;
            if (counters[end - 1].status == "on")
            {
            }
            else            //if the command is outside a loop
            {
                DrawRectangle(w, h);
            }
        }
        public void DrawRectangle(string width, string heigth)
        {
            int[] para = Get_Whith_height(width, heigth);
            if (fillOnOff.Fill.Equals("off") == true)
            {
                Rectangles rectangle = new Rectangles(start_x, start_y, para[0], para[1], fillOnOff.Fill, Pen.R, Pen.G, Pen.B);
                Rectangles.Add(rectangle);
                g.DrawRectangle(myPen, start_x, start_y, para[0], para[1]);

            }
            else if (fillOnOff.Fill.Equals("on") == true)
            {
                Rectangles rectangle = new Rectangles(start_x, start_y, para[0], para[1], fillOnOff.Fill, Brush.R, Brush.G, Brush.B);
                Rectangles.Add(rectangle);
                g.FillRectangle(myBrush, start_x, start_y, para[0], para[1]);
            }
        }

        //moveto 
        public void Mother_moveTo(string end_x, string end_y)
        {
            //int[] para = Get_Whith_height(end_x,end_y);
            int end = counters.Count;
            if (counters[end - 1].status == "on")
            {
                Console.WriteLine("flag On waiting");
            }
            else            //if the command is outside a loop
            {
                Console.WriteLine("flag on go");
                moveTo(end_x, end_y);
                Console.WriteLine($"1 rectangle out of loop :w {end_x} h {end_y}");
            }
        }
        public void moveTo(string end_x, string end_y)
        {
            int[] para = Get_Whith_height(end_x, end_y);
            Turtle turtle = new Turtle(para[0], para[1]);
            turtles.Add(turtle);
            int l = turtles.Count;
            start_x = para[0];
            start_y = para[0];
            g.DrawEllipse(turtlePen, turtles[l - 1].X, turtles[l - 1].Y, 1, 1);

            for (int i = 0; i < Lines.Count; i++)
            {
                Pen line_pen = new Pen(Color.FromArgb(Lines[i].R, Lines[i].G, Lines[i].B));
                g.DrawLine(line_pen, Lines[i].X1, Lines[i].Y1, Lines[i].X2, Lines[i].Y2);

            }
            for (int i = 0; i < Circles.Count; i++)
            {
                if (Circles[i].Fill == "off")
                {
                    Pen circle_pen = new Pen(Color.FromArgb(Circles[i].R, Circles[i].G, Circles[i].B));
                    g.DrawEllipse(circle_pen, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);
                }
                else if (Circles[i].Fill == "on")
                {
                    SolidBrush circle_brush = new SolidBrush(Color.FromArgb(Circles[i].R, Circles[i].G, Circles[i].B));
                    g.FillEllipse(circle_brush, Circles[i].X - Circles[i].Radius, Circles[i].Y - Circles[i].Radius, Circles[i].Radius * 2, Circles[i].Radius * 2);
                }
            }
            for (int i = 0; i < Rectangles.Count; i++)
            {
                if (Rectangles[i].Fill == "off")
                {
                    Pen rectangle_pen = new Pen(Color.FromArgb(Rectangles[i].R, Rectangles[i].G, Rectangles[i].B));
                    g.DrawRectangle(rectangle_pen, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth);

                }
                else if (Rectangles[i].Fill == "on")
                {
                    SolidBrush rectangle_brush = new SolidBrush(Color.FromArgb(Rectangles[i].R, Rectangles[i].G, Rectangles[i].B));
                    g.FillRectangle(rectangle_brush, Rectangles[i].X, Rectangles[i].Y, Rectangles[i].Width, Rectangles[i].Heigth);

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
                    Pen triangle_pen = new Pen(Color.FromArgb(Triangles[i].R, Triangles[i].G, Triangles[i].B));
                    g.DrawPolygon(triangle_pen, TPoints);
                }
                else if (Triangles[i].Fill == "on")
                {
                    SolidBrush triangle_brush = new SolidBrush(Color.FromArgb(Triangles[i].R, Triangles[i].G, Triangles[i].B));
                    g.FillPolygon(triangle_brush, TPoints);
                }
            }
        }

        //circle
        public void Mother_DrawCircle(string radius)
        {
            ////if the command is inside a loop
            int end = counters.Count;
            if (counters[end - 1].status == "on")
            {
                Console.WriteLine("flag On waiting");
            }
            else            //if the command is outside a loop
            {
                Console.WriteLine("flag on go");
                DrawCircle(radius);
                Console.WriteLine("1 circle out of loop");
            }
        }
        public int Get_Radius(string r)
        {
            int rad = 0;
            bool resRad = int.TryParse(r, out int rx);
            if (resRad)
            {
                rad = Int32.Parse(r);
            }
            else
            {
                if (var_list.Exists(e => e.varname == r))
                {
                    int i = var_list.FindIndex(e => e.varname == r);
                    int value_found = var_list[i].varvalue;
                    rad = value_found;

                }
                else { throw new System.ArgumentOutOfRangeException("a greater than b", r, var_dec); }
            }

            return rad;
        }
        public void DrawCircle(string radius) // the circle is not drawn from the last position of moveTo,but the center is shifted
        {
            int rad = Get_Radius(radius);
            float width;
            float higth;
            width = higth = rad * 2;
            //Circles circle = new Circles(start_x, start_y, rad, fillOnOff.Fill, Pen.R,Pen.G,Pen.B);
            //circle.Radius_Type(rad);
            //Circles.Add(circle);

            //g.DrawEllipse(myPen,start_x-(radius/2),start_y-(radius/2),width*2,higth*2);
            if (fillOnOff.Fill.Equals("off") == true)
            {
                Circles circle = new Circles(start_x, start_y, rad, fillOnOff.Fill, Pen.R, Pen.G, Pen.B);
                Circles.Add(circle);
                g.DrawEllipse(myPen, start_x - rad, start_y - rad, width, higth);
            }
            else if (fillOnOff.Fill.Equals("on") == true)
            {
                Circles circle = new Circles(start_x, start_y, rad, fillOnOff.Fill, Brush.R, Brush.G, Brush.B);
                Circles.Add(circle);
                g.FillEllipse(myBrush, start_x - rad, start_y - rad, width, higth);
            }
            else throw new ArgumentOutOfRangeException("You need to choose fill on or fill off for the shape drawing method");

        }

        // triangle
        public void Mother_DrawTriangle(string point1x, string point1y, string point2x, string point2y)
        {
            ////if the command is inside a loop
            int end = counters.Count;
            if (counters[end - 1].status == "on")
            {
            }
            else            //if the command is outside a loop
            {
                DrawTriangle(point1x, point1y, point2x, point2y);
            }
        }
        public void DrawTriangle(string point1x, string point1y, string point2x, string point2y)
        {
            int[] para = Get_Points(point1x, point1y, point2x, point2y);

            PointF[] TPoints = new PointF[]
        { new PointF { X = start_x,Y=start_y },
              new PointF {X= para[0] , Y=para[1]},
              new PointF {X=para[2], Y=para[3]}
        };
            if (fillOnOff.Fill.Equals("off") == true)
            {
                Triangles triangle = new Triangles(start_x, start_y, para[0], para[1], para[2], para[3], fillOnOff.Fill, Pen.R, Pen.G, Pen.B);
                Triangles.Add(triangle);
                g.DrawPolygon(myPen, TPoints);

            }
            else if (fillOnOff.Fill.Equals("on") == true)
            {
                Triangles triangle = new Triangles(start_x, start_y, para[0], para[1], para[2], para[3], fillOnOff.Fill, Brush.R, Brush.G, Brush.B);
                Triangles.Add(triangle);
                g.FillPolygon(myBrush, TPoints);
            }
        }
        public void Mother_DrawColor(string r, string g, string b)
        {
            int end = counters.Count;
            if (counters[end - 1].status == "on")
            {
            }
            else
            {
                DrawColor(r, g, b);
            }
        }

        public void DrawColor(string r, string g, string b)
        {

            int[] rgb = Get_rgb(r, g, b);
            Pen = new Turtle(rgb[0], rgb[1], rgb[2]);

            myPen = new Pen(Color.FromArgb(rgb[0], rgb[1], rgb[2]));

        }

        public void Mother_FillColor(string r, string g, string b)
        {
            int end = counters.Count;
            if (counters[end - 1].status == "on")
            {
            }
            else
            {
                FillColor(r, g, b);
            }
        }

        public void FillColor(string r, string g, string b)
        {
            int[] rgb = Get_rgb(r, g, b);
            Brush = new Turtle(rgb[0], rgb[1], rgb[2]);
            myBrush = new SolidBrush(Color.FromArgb(rgb[0], rgb[1], rgb[2]));

        }

        public void drawline()
        {
            g.DrawLine(myPen, 10, 10, 150, 150);

        }
        public void Reset()
        {
            start_x = 0;
            start_y = 0;
            Circles.Clear();
            Triangles.Clear();
            Rectangles.Clear();
            g.DrawEllipse(turtlePen, start_x, start_y, 1, 1);
        }
        public void Clear()
        {
            int l = turtles.Count;
            g.DrawEllipse(turtlePen, turtles[l - 1].X, turtles[l - 1].Y, 1, 1);
            Circles.Clear();
            Triangles.Clear();
            Rectangles.Clear();
        }



        //mother mehtod
        public void Mother_Calcul_var(string v, string x, string oper, string y)
        {
            int end = counters.Count;
            if (counters[end - 1].status == "on")
            {
                Console.WriteLine(" Flag on waiting");
            }
            else
            {
                Calcul_var(v, x, oper, y);
            }
        }
        public void Mother_Compare(string if_name, string var1, string var2, string oper)
        {
            int end = counters.Count;
            if (counters[end - 1].status == "on")
            {
                Console.WriteLine(" Flag on waiting");
            }
            else
            {
                Compare(if_name, var1, var2, oper);
            }
        }
        //get parameters for loop and operations

        public int Get_iterations(string v)
        {
            int it = 0;
            bool resit = int.TryParse(v, out int rit);
            if (resit)
            {
                it = Int32.Parse(v);
            }
            else
            if (var_list.Exists(e => e.varname == v))
            {
                int i = var_list.FindIndex(e => e.varname == v);
                it = var_list[i].varvalue;
            }
            else { throw new System.ArgumentOutOfRangeException("a greater than b", v, iterations_var); }
            return it;
        }
        public int[] Get_Whith_height(string w, string h)
        {
            int[] rec_params = { 0, 0 };
            int w_val = 0;
            int h_val = 0;
            bool resw = int.TryParse(w, out int rw);
            bool reh = int.TryParse(h, out int rh);
            if (resw && reh)
            {
                w_val = Int32.Parse(w);
                h_val = Int32.Parse(h);
                rec_params[0] = w_val;
                rec_params[1] = h_val;
            }
            if (resw && reh == false)
            {
                if (var_list.Exists(e => e.varname == h))
                {
                    int i = var_list.FindIndex(e => e.varname == h);
                    int h_found = var_list[i].varvalue;
                    rec_params[0] = Int32.Parse(w);
                    rec_params[1] = h_found;
                }
                else { throw new System.ArgumentOutOfRangeException("a greater than b", h, var_dec); }
            }
            if (resw == false && reh)
            {
                if (var_list.Exists(e => e.varname == w))
                {
                    int i = var_list.FindIndex(e => e.varname == w);
                    int w_found = var_list[i].varvalue;
                    rec_params[0] = w_found;
                    rec_params[1] = Int32.Parse(h);

                }
                else { throw new System.ArgumentOutOfRangeException("a greater than b", w, var_dec); }
            }
            if (resw == false && reh == false)
            {
                if (var_list.Exists(e => e.varname == w) && var_list.Exists(e => e.varname == h))
                {
                    int i = var_list.FindIndex(e => e.varname == w);
                    int w_found = var_list[i].varvalue;
                    int j = var_list.FindIndex(e => e.varname == h);
                    int h_found = var_list[j].varvalue;
                    rec_params[0] = w_found;
                    rec_params[1] = h_found;
                }
                else { throw new System.ArgumentOutOfRangeException("a greater than b", h, var_dec); }
            }
            return rec_params;
        }
        public void Check_Var(string v, string y)
        {
            if (var_list.Exists(e => e.varname == y))
            {
                int i = var_list.FindIndex(e => e.varname == y);
                int value_found = var_list[i].varvalue;
                Assign_var(v, value_found);
            }
            else { throw new System.ArgumentOutOfRangeException("a greater than b", y, Var_dec); }

        }
        public void Assign_var(string v, int x)
        {
            Variables varibale = new Variables(v, x);
            if (var_list.Exists(e => e.varname == v))
            {
                var_list.Where(w => w.varname == v).ToList().ForEach(s => s.varvalue = x);
            }
            else
            {
                var_list.Add(varibale);
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
            else { throw new System.ArgumentOutOfRangeException("a greater than b", v, var_dec); }
        }


        public int[] Get_Points(string a, string b, string c, string d)
        {
            string[] pars = { a, b, c, d };
            int[] rec_params = { 0, 0, 0, 0 };

            for (int i = 0; i <= 3; i++)
            {
                bool ress = int.TryParse(pars[i], out int rs);
                if (ress)
                {
                    rec_params[i] = int.Parse(pars[i]);
                }
                else if (var_list.Exists(e => e.varname == pars[i]))
                {
                    int j = var_list.FindIndex(e => e.varname == pars[i]);
                    int s_found = var_list[j].varvalue;
                    rec_params[i] = s_found;

                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("a greater than b", rec_params, var_dec);
                }
            }
            return rec_params;
        }
        public int[] Get_rgb(string r, string g, string b)
        {
            string[] pars = { r, g, b };
            int[] rec_params = { 0, 0, 0 };

            for (int i = 0; i < 3; i++)
            {
                bool ress = int.TryParse(pars[i], out int rs);
                if (ress)
                {
                    rec_params[i] = int.Parse(pars[i]);
                }
                else if (var_list.Exists(e => e.varname == pars[i]))
                {
                    int j = var_list.FindIndex(e => e.varname == pars[i]);
                    int s_found = var_list[j].varvalue;
                    rec_params[i] = s_found;

                }
                else
                {
                    throw new System.ArgumentOutOfRangeException("a greater than b", rec_params, var_dec);
                }
            }
            return rec_params;
        }
        public void Calcul_var(string v, string x, string oper, string y)
        {
            int r = 0;
            bool resx = int.TryParse(x, out int rx);
            bool resy = int.TryParse(y, out int ry);
            if (resx && resy)
            {
                if (oper == "+")
                {
                    r = Int32.Parse(x) + Int32.Parse(y);
                    if (r < 0)
                    {
                        throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                    }
                }
                else if (oper == "-")
                {
                    r = Int32.Parse(x) - Int32.Parse(y);
                    if (r < 0)
                    {
                        throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                    }
                }
                else if (oper == "*")
                {
                    r = Int32.Parse(x) * Int32.Parse(y);
                    if (r < 0)
                    {
                        throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                    }
                }
                else if (oper == "/")
                {
                    if (Int32.Parse(y) == 0)
                    {
                        throw new System.ArgumentOutOfRangeException("a greater than b", r, calc_result);
                    }
                    else
                    {
                        r = Int32.Parse(x) / Int32.Parse(y);
                        if (r < 0)
                        {
                            throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                        }
                    }

                }

            }
            if (resx == false && resy)
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
                            throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                        }
                    }
                    else if (oper == "-")
                    {
                        r = xf - Int32.Parse(y);
                        if (r < 0)
                        {
                            throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                        }
                    }
                    else if (oper == "*")
                    {
                        r = xf * Int32.Parse(y);
                        if (r < 0)
                        {
                            throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                        }
                    }
                    else if (oper == "/")
                    {
                        if (Int32.Parse(y) == 0)
                        {
                            throw new System.ArgumentOutOfRangeException("a greater than b", r, calc_result);
                        }
                        else
                        {
                            r = xf / Int32.Parse(y);
                            if (r < 0)
                            {
                                throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                            }
                        }

                    }
                }
                else { throw new System.ArgumentOutOfRangeException("a greater than b", x, var_dec); }

            }

            if (resx && resy == false)
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
                            throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                        }
                    }
                    else if (oper == "-")
                    {
                        r = Int32.Parse(x) - yf;
                        if (r < 0)
                        {
                            throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                        }
                    }
                    else if (oper == "*")
                    {
                        r = Int32.Parse(x) * yf;
                        if (r < 0)
                        {
                            throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                        }
                    }
                    else if (oper == "/")
                    {
                        if (Int32.Parse(y) == 0)
                        {
                            throw new System.ArgumentOutOfRangeException("a greater than b", r, calc_result);
                        }
                        else
                        {
                            r = Int32.Parse(x) / yf;
                            if (r < 0)
                            {
                                throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                            }
                        }

                    }
                }
                else { throw new System.ArgumentOutOfRangeException("variable dec", y, var_dec); }

            }

            if (resx == false && resy == false)
            {
                if (var_list.Exists(e => e.varname == y))
                {
                    if (var_list.Exists(e => e.varname == y))
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
                                throw new System.ArgumentOutOfRangeException("a greater than b", r, values_comp);
                            }
                        }
                        else if (oper == "-")
                        {
                            r = xf - yf;
                            if (r < 0)
                            {
                                throw new System.ArgumentOutOfRangeException("variable dec", r, values_comp); ;
                            }
                        }
                        else if (oper == "*")
                        {
                            r = xf * yf;
                            if (r < 0)
                            {
                                throw new System.ArgumentOutOfRangeException("result", r, calc_result);
                            }
                        }
                        else if (oper == "/")
                        {
                            if (yf == 0)
                            {
                                throw new System.ArgumentOutOfRangeException("variable dec", r, calc_result);
                            }
                            else
                            {
                                r = xf / yf;
                                if (r < 0)
                                {
                                    throw new System.ArgumentOutOfRangeException("variable dec", r, calc_result);
                                }
                            }

                        }

                    }
                    else { throw new System.ArgumentOutOfRangeException("variable dec", y, var_dec); }
                }
                else { throw new System.ArgumentOutOfRangeException("variable dec", x, var_dec); }

            }

            Variables varibale = new Variables(v, r);
            Assign_var(v, r);
        }


        //while loop methods

        public void Create_while(string c, string l) // Flag on
        {
            bool resl = int.TryParse(l, out int rl);
            string s = "on";

            if (counters.Exists(e => e.counter == c))
            {
                throw new System.ArgumentOutOfRangeException("counter", c, counter_dec);
            }
            else if (resl == true)
            {
                int l_parsed = Int32.Parse(l);
                Variables loop = new Variables(c, l_parsed, s);
                counters.Add(loop);
            }
            else if (var_list.Exists(e => e.varname == l))
            {
                int i = var_list.FindIndex(e => e.varname == l);
                int value_found = var_list[i].varvalue;
                Variables loop = new Variables(c, value_found, s);
                counters.Add(loop);
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("iterations ", l, iterations_var);
            }
        }

        //
        public void End_while(string counter)
        {
            if (counters.Exists(e => e.counter == counter))
            {
                int i = counters.FindIndex(e => e.counter == counter);
                string s_found = counters[i].status;
                if (s_found == "off")
                {
                    Console.WriteLine($"loop {counter} is already ended ");
                    throw new System.ArgumentOutOfRangeException("iterations ", counter, loop_ended);
                }
                else { counters.Where(w => w.counter == counter).ToList().ForEach(s => s.status = "off"); }


            }
            else
            {
                throw new System.ArgumentOutOfRangeException("end while ", counter, counter_var);
            }
        }


        //if statement

        public void Create_if(string if_name, string var1, string var2, string oper) // Flag on
        {

            //chech if it exist
            //check if the parameters are true
            //check if the condition is true
            //then draw
            Compare(if_name, var1, var2, oper);
        }




        //
        public void End_ofif(string if_name)
        {
            if (ifstatements.Exists(e => e.ifname == if_name))
            {
                int i = ifstatements.FindIndex(e => e.ifname == if_name);
                string s_found = ifstatements[i].status;
                if (s_found == "off")
                {
                    Console.WriteLine($"loop {if_name} is already ended ");
                }
                else { ifstatements.Where(w => w.ifname == if_name).ToList().ForEach(s => s.status = "off"); }


            }
            else
            {
                throw new System.ArgumentOutOfRangeException("end while ", if_name, if_name_check);
            }
        }

        public void Compare(string if_name, string var1, string var2, string oper)
        {
            bool resl = int.TryParse(if_name, out int rl);
            bool v1_cond = int.TryParse(var1, out int v1);
            bool v2_cond = int.TryParse(var2, out int v2);
            string name;
            int a;
            int b;
            string o;
            int c;
            string s = "on";

            if (ifstatements.Exists(e => e.ifname == if_name))
            {
                throw new System.ArgumentOutOfRangeException("statement", var1, if_dec);
            }
            else if (v1_cond == true)
            {
                if (v2_cond == true)
                {
                     c = CompareValues(v1, v2, oper);
                     Variables statement = new Variables(if_name,v1, v2, oper, c,s);
                     ifstatements.Add(statement); 
                }
                else
                {
                    if (var_list.Exists(e => e.varname == var2))
                    {

                        int i = var_list.FindIndex(e => e.varname == var2);
                        int value_found = var_list[i].varvalue;
                        c = CompareValues(v1, value_found, oper);
                        c = CompareValues(v1, v2, oper);
                        Variables statement = new Variables(if_name, v1, value_found, oper,c, s);
                        ifstatements.Add(statement);
                    }
                    else
                    {
                        throw new System.ArgumentOutOfRangeException("iterations ", var2, if_var2);
                    }
                }
            }
            else
            {
                if (v2_cond == true)
                {
                    if (var_list.Exists(e => e.varname == var1))
                    {
                        int i = var_list.FindIndex(e => e.varname == var1);
                        int value_found = var_list[i].varvalue;
                        c = CompareValues(v1, v2, oper);

                        Variables statement = new Variables(if_name, value_found, v2, oper,c,s);
                        ifstatements.Add(statement);
                        
                    }
                    else
                    {
                        throw new System.ArgumentOutOfRangeException("iterations ", var2, if_var1);
                    }
                }
                else
                {
                    if (var_list.Exists(e => e.varname == var1))
                    {
                        if (var_list.Exists(f => f.varname == var2))
                        {
                            int i = var_list.FindIndex(e => e.varname == var1);
                            int j = var_list.FindIndex(f => f.varname == var2);
                            int value1_found = var_list[i].varvalue;
                            int value2_found = var_list[j].varvalue;
                            c = CompareValues(v1, v2, oper);

                            Variables statement = new Variables(if_name, value1_found, value2_found, oper,c,s);
                            ifstatements.Add(statement);
                        }
                        else
                        {
                            throw new System.ArgumentOutOfRangeException("iterations ", var2, if_var2);
                        }
                    }
                    else
                    {
                        throw new System.ArgumentOutOfRangeException("iterations ", var2, if_var1);
                    }
                }
            }
        }

        public int CompareValues(int value1, int value2, string oper)
        {
            int result;
            switch (oper)
            {
                case "==":
                    result = (value1 == value2) ? 1 : 0;
                    break;
                case "!=":
                    result = (value1 != value2) ? 1 : 0;
                    break;
                case "<":
                    result = (value1 < value2) ? 1 : 0;
                    break;
                case ">":
                    result = (value1 > value2) ? 1 : 0;
                    break;
                case "<=":
                    result = (value1 <= value2) ? 1 : 0;
                    break;
                case ">=":
                    result = (value1 >= value2) ? 1 : 0;
                    break;
                default:
                    throw new ArgumentException("Invalid operator", nameof(oper));
            }
            return result;
        }


    }
}
  
        
		
		
        
     

    


