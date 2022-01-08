using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    class Variables
    {
        public string varname { get; }
        public int varvalue { get; set; }
        public string varvar { get; }

        public string counter { get; }
        public string status { get; set; }
        public int limit { get; }

        public Variables (string v,int x)
        {
            this.varname = v;
            this.varvalue = x;
        }
        public Variables(string c, int l,string s)
        {
            this.counter = c;
            this.limit = l;
            this.status = s;
        }







    }
}
