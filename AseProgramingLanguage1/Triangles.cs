using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    class Triangles
    {
        public int X1 { get; }
        public int Y1 { get; }
        public int X2 { get; }
        public int Y2 { get; }
        public int X3 { get; }
        public int Y3 { get; }
        public string Fill { get; }
        public string Pencolor { get; }
        public string Fillcolor { get; }
        public const string TrianglePointsTypes = "X and Y for each point should be greater then 0";

        public Triangles(int x1, int y1, int x2, int y2, int x3, int y3, string fill, string Pencolor, string Fillcolor)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            this.X3 = x3;
            this.Y3 = y3;
            this.Fill = fill;
            this.Pencolor = Pencolor;
            this.Fillcolor = Fillcolor;
        }
        public void Tpoint1_TPoint2_Types(int x2, int y2, int x3, int y3)
        {
            if (x2 <= 0 || y2 <= 0 || x3 <= 0 || y3 <= 0)
            {
                throw new ArgumentOutOfRangeException("Width  type", TrianglePointsTypes);
            }

        }
    }
}
