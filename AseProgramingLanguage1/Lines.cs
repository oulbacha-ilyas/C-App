using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    class Lines
    {
        public const string LinePointType = "X and Y should be grater than 0";
        public string Pencolor { get; }
        public int X1 { get; }
        public int X2 { get; }
        public int Y1 { get; }
        public int Y2 { get; }
        public int R { get; }
        public int G { get; }
        public int B { get; }
        public Lines(int x1, int y1, int x2, int y2,int r,int g,int b)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            this.R = r;
            this.G = g;
            this.B = b;

        }

        public void LinePoint_Type(int x, int y)
        {
            //if (x <=0 || y<=0)
            //{
            //    throw new ArgumentOutOfRangeException("Radius type", x, LinePointType);
            //}
        }

    }
}

