using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    class Turtle
    {
        public int a { get; }
        public int b { get; }
    public Turtle()
        {
            ParseCommand turtles = new ParseCommand();
            a = turtles.param1;
            b = turtles.param2;
            
        }
    }
}
