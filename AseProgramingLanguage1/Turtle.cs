using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    class Turtle
    {
        public string Fill { get; }
        public int X { get; }
        public int Y { get; }
        //public string Pencolor { get;}
        public int R { get; }
        public int G { get; }
        public int B { get; }

        public Turtle(string fill)
        {
            //Fill.Equals(fill);
            this.Fill=fill ;
            
        }
        public Turtle(int x,int y/*,string pencolor*/)
        {
            this.X = x;
            this.Y = y;
            //this.Pencolor=pencolor;

        }
        public Turtle(int r, int g,int b/*,string pencolor*/)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            //this.Pencolor=pencolor;

        }
    }
}
