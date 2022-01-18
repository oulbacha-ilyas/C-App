using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    class Rectangles
    {

        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Heigth { get; }
        public int R { get; }
        public int G { get; }
        public int B { get; }
        public string Fill { get; }
        public const string WidthType = "Width should be a positive number";
        public const string HeigthType = "Heigth should be a positive number";

        public Rectangles(int x, int y, int width,int heigth, string fill, int r,int g,int b)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Heigth = heigth;
            this.Fill = fill;
            this.R = r;
            this.G = g;
            this.B = b;

        }
        public void Width_Heigth_Types(int width,int heigth)
        {
            if (width<= 0 )
            {
                throw new ArgumentOutOfRangeException("Width  type", width, WidthType);
            }
            if ( heigth <= 0)
            {
                throw new ArgumentOutOfRangeException("Heigth  type", width, HeigthType);
            }
        }
    }
}
