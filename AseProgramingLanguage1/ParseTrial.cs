using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    class ParseTrial
    {

        public string command { get; }
        public int param1 { get; }
        public int param2 { get; }
        public ParseTrial(int a)
        {
            this.command = "drawto";
            
            //ParseCheck(a/2,a/2);
            this.param1 =
            this.param2 = a / 2;
        }
       
        public void ParseCheck(int x,int y)
        { }
    }
}

