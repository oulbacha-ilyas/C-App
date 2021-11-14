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
        public void Synthax_CommandNoparameter_Test() // testing commands with no parameters,if any paramters is entered it throws an exception
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
        public void CircleWithNoParameter_test() //if circle command is not followed by any parameter,an exception is thrown
        {

            string line = "Circle";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.Command_WithParameter);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void CircleRadiusInt_test() //if the parameter cannot be parsed,an exception is thrown
        {

            string line = "Circle 100x";
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

        //===============Tests for rectangle command=======
        [TestMethod]
        public void RectangleleWithNoParameter_test() //if rectangle command is not followed by any parameter,an exception is thrown
        {

            string line = "rectangle";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.Command_WithParameter);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void RectangleWidthInt_test() //if the width cannot be parsed,an exception is thrown
        {

            string line = "rectangle x,100";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.WidtInt);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void RectangleHeigthInt_test() //if the heigth cannot be parsed,an exception is thrown
        {

            string line = "rectangle 100,x";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.HeigthInt);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
    }
}

