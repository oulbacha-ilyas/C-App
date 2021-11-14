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
            
            string line = "run 40";
            SynthaxCommand synthax_test = new SynthaxCommand(line);
            //ACT
            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.Command_withNoParameters);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }

        [TestMethod]
        public void CircleWithNoParameter_test() //test if there is a parameter or not,and this parameter if of type int
        {

            string line = "circle";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.CircleShouldHaveRadius);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void CircleRadius_test() //test if there is a parameter or not,and this parameter if of type int
        {

            string line = "Circle x";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message,SynthaxCommand.RadiusShouldBeInt);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
    }
}

