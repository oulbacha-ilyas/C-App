using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using AseProgramingLanguage1;
using AseProgramingLanguage1;

namespace ProgramingLanguage1Tests
{
    [TestClass]
    public class SynthaxCommand_test
    {
        [TestMethod]
        public void Synthax_CommandNoparameter_Test() // testing commands with no parameters
        {
            
            string line = "run ";
            string exp_command = "run";
            SynthaxCommand synthax_test = new SynthaxCommand(line);
            //ACT
            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "this command has no paramters");
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }

        public void Synthax_commandOneParameter_test()
        {

            string line = "Circle 70";
            string exp_command = "circle";
            SynthaxCommand synthax_test = new SynthaxCommand(line);
            //ParseCommand parse_test = new ParseCommand(line);//SynthaxCheck doesn't return anything,we need to parse the paramaters for test purposes.
            //string act_command = parse_test.command;

            //ACT
            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "this command has no paramters");
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
    }
}

