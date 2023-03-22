﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void UnkownCommand_Test() // if an unkown command,if any paramters is entered it throws an exception
        {

            string line = "got"; //two indefinite letters  could be an initiation to a variable
            SynthaxCommand synthax_test = new SynthaxCommand(line);
            //ACT
            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.UnkownCommand);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
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
                StringAssert.Contains(e.Message, SynthaxCommand.UnkownCommand);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }

        //=========circle=======

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
        public void CircleWithIndefiniteParameter_test() //if circle command is not followed by any parameter,an exception is thrown
        {

            string line = "Circle q%"; //or q,d or q, or % .....
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.Var_name);
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
        public void RectangleleParameterNumber_test() //if rectangle command is not followed by any parameter,an exception is thrown
        {

            string line = "rectangle 30,30,50";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.RectangleParametersNumber);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
         
      
        [TestMethod]
        public void RectangleIndefiniteParameters_test() //if the heigth cannot be parsed,an exception is thrown
        {

            string line = "rectangle 100,100;10"; // all exceptions handled
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.Var_name);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }

        //==============Test methods for triangle=======================
        [TestMethod]
        public void TriangleWithNoParameter_test() //if rectangle command is not followed by any parameter,an exception is thrown
        {

            string line = "triangle";
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
        public void TriangleParametersNumber_test() //if the number of parameters is not exactly as required for triangle command,an exception is thrown
        {

            string line = "triangle 100";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.TriangleParametersNumber);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void TrianglePointsParse_test() //if one of the trinagle parameters cannot be parsed,an exception is thrown
        {

            string line = "triangle c,100,130,x§";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.Var_name);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }

        //===========Tests for position commands=====
        //=========moveto command======
        [TestMethod]
        public void MoveToWithNoParameter_test() //if moveto command is not followed by any parameter,an exception is thrown
        {

            string line = "moveto";
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
        public void MoveToParmetersNumber_test() //if the number of parameters is not as required for the command,an exception is thrown
        {

            string line = "moveto 100";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.PositionsParameters);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void MoveToPointsParse_test() //if the parameters cannot be parsed,an exception is thrown
        {

            string line = "moveto x,100%";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.Var_name);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }

        //======drawto command
        //=========drawto command======
        [TestMethod]
        public void DrawToWithNoParameter_test() //if drawto command is not followed by any parameter,an exception is thrown
        {

            string line = "drawto";
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
        public void DrawToParmetersNumber_test() //if the number of parameters is not as required for the command,an exception is thrown
        {

            string line = "drawto 100";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.PositionsParameters);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void DrawToPointsParse_test() //if the parameters cannot be parsed,an exception is thrown
        {

            string line = "drawto 50,%";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.Var_name);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }


        //=============Tests for color methods=============
        //=========drawcolor command======
        [TestMethod]
        public void DrawColorNoParameter_test() //if drawcolor command is not followed by any parameter,an exception is thrown
        {

            string line = "drawcolor";
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
        public void DrawColorParmetersNumber_test() //if the number of parameters is not as required for the command,an exception is thrown
        {

            string line = "drawcolor blue,red";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.RGBcode_length);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void DrawColorParmetersType_test() //if the  parameters does not match an existing color,an exception is thrown
        {

            string line = "drawcolor %,100,30";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.RGBcode_values);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }

        //========Tests for FillColor method=====
        //=========drawcolor command======
        [TestMethod]
        public void FillColorNoParameter_test() //if fillcolor command is not followed by any parameter,an exception is thrown
        {

            string line = "fillcolor";
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
        public void FillColorParametersNumber_test() //if the parameters cannot be parsed,an exception is thrown
        {

            string line = "fillcolor x,s";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.RGBcode_length);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void FillColorParmeterType_test() //if the  parameters does not match an existing color,an exception is thrown
        {

            string line = "fillcolor r,100,#";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.RGBcode_values);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }

        //=======Tests for fill command====
        [TestMethod]
        public void FillNoParmeters_test() //if the command choice (on/off) is not specified,an exception is thrown
        {

            string line = "fill";
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
        public void FillParmetersMatch_test() //if the  parameters does not match an existing color,an exception is thrown
        {

            string line = "fill r";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.FillParametersMatch);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }

        //=======Tests for part 2==========
        //variables declaration loop tests
        //test for invalid name
        [TestMethod]
        public void  Var_dec_invalid_name_test() //if the  parameters does not match an existing color,an exception is thrown
        {

            string line = "a/ = 0";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.Var_dec_name2);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void Var_value_Ivalid_test() //if the  parameters does not match an existing color,an exception is thrown
        {

            string line = "a = x";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.Var_dec);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }

        [TestMethod]
        public void loop_
            () //if the  parameters does not match an existing color,an exception is thrown
        {

            string line = "while 1 < 10";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.loop_counter);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }


        [TestMethod]
        public void loop_operator() //if the  parameters does not match an existing color,an exception is thrown
        {

            string line = "while i = 10";
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.loop_operator);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }
        [TestMethod]
        public void loop_end() //if the  parameters does not match an existing color,an exception is thrown
        {

            string line = "endwhile ";   //x is not 
            SynthaxCommand synthax_test = new SynthaxCommand(line);

            try
            {
                synthax_test.SynthaxCheck(line);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, SynthaxCommand.end_while);
                return;
            }
            Assert.Fail("the expected exception was not thrown");
        }







        //variable declaration tests

    }

}


