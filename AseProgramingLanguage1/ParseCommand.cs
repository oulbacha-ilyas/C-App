using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseProgramingLanguage1
{
    class ParseCommand
    {
        public string line { get; }
        public string command { get; }
        public int param1 { get; }
        public int param2 { get; }

        // create an object with 3 attributes:command,params
        public ParseCommand(string line)
        {
            this.line = line;
            string[] split;
            string[] parameters;
            line = line.ToLower().Trim();
            split = line.Split(' ');
            parameters = split[1].Split(',');
            string parameter1 = parameters[0];
            string parameter2 = parameters[1];

            this.param1 = Int32.Parse(parameter1);
            this.param2 = Int32.Parse(parameter2);
            this.command = split[0];
        }
    }
}
