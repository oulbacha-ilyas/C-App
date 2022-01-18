using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    
    class Circles
    {
        public int X { get; }
        public int Y { get; }
        public int R { get; }
        public int G { get; }
        public int B { get; }
        public int Radius { get; }
        public string Fill{ get; }
        public string Pencolor {get; }
        public string Fillcolor {get; }

        public const string RadiusType = "Radius should be a positive number";

        public Circles(int x,int y,int ra,string fill/*,string Pencolor *//*,string Fillcolor*/,int r,int g,int b)
        {
            this.X = x;
            this.Y = y;
            this.Radius = ra;
            this.Fill = fill;
            this.R = r;
            this.G = g;
            this.B = b;
            //this.Pencolor=Pencolor;
            //this.Fillcolor=Fillcolor;
        }
        public void Radius_Type(int r)
        {
            
        }
    }
}
