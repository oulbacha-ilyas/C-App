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
        public int Radius { get; }
        public string Fill{ get; }
        public string Pencolor {get; }
        public string Fillcolor {get; }

        public const string RadiusType = "Radius should be a positive number";

        public Circles(int x,int y,int r,string fill,string Pencolor ,string Fillcolor)
        {
            this.X = x;
            this.Y = y;
            this.Radius = r;
            this.Fill = fill;
            this.Pencolor=Pencolor;
            this.Fillcolor=Fillcolor;
        }
        public void Radius_Type(int r)
        {
            if (r<=0)
            {
                throw new ArgumentOutOfRangeException("Radius type", r,RadiusType);
            }
        }
    }
}
