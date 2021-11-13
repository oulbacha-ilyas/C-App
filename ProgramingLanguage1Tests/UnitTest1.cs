using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using AseProgramingLanguage1;

namespace ProgramingLanguage1Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       public void SynthaxCheck_Test()
        {
            /*
            string TestLine = "cir 100";
            string intended_command = "circle";
            Type intendedType = typeof(string);
            
            //act
            
            ParseCommand synthax0 = new ParseCommand( TestLine);
            synthax0.SynthaxCheck();
            //assert
            object[] VALUES = { synthax0.command };
            foreach(var VALUE in VALUES)
            {
                Type actual = VALUE.GetType();
                Assert.AreEqual(intendedType, actual);
            }
            
            */
        }
        public void StructureCheck_Test()
        {
            /*
            string line = "circle60";
            string exp_command = "command";
            int exp_int = 70;
            ParseCommand parse_test = new ParseCommand(line);
            //ACT
            parse_test.StructureCheck();
            string act_command = parse_test.line;
            int act_int = parse_test.param1;
            //
            Assert.AreEqual(exp_command, act_command,"is there an error");
            //Assert.AreEqual(exp_int, act_int);
            */
        }

    }
}
