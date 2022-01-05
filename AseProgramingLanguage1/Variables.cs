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
        public int varvalue { get; }
        public const string Var_value = "The value assigned to the variable should be positive.";
        public Variables(string v, int x)
        {
            this.varname = v;
            this.varvalue = x;
        }
        public void Check_Varvalue(int x)
        {
            if (x < 0)
            { throw new System.ArgumentOutOfRangeException("radius", x, Var_value); }

        }

    }
}
