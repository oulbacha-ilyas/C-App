using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using AseProgramingLanguage1;
using AseProgramingLanguage1;

namespace ProgramingLanguage1Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SynthaxCheck_Test()
        {
            
            string line = "run";
            string exp_command = "run";
            //int exp_param1 = 60;
            
            SynthaxCommand synthax_test = new SynthaxCommand(line);
            //ACT
            synthax_test.SynthaxCheck(line);
            ParseCommand parse_test = new ParseCommand(line);//SynthaxCheck doesn't return anything,we need to parse the paramaters for test purposes.

            string act_command = parse_test.command;
            //int act_param1 = parse_test.param1;
            //
            Assert.AreEqual(exp_command, act_command);
           //Assert.AreEqual(exp_param1, act_param1);
            
        }

    }
}
