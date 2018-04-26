using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lesson2;

namespace Project.Test
{
    [TestClass]
    public class ProjectTest
    {

        [TestMethod]
        public void Arguments_WithValidFormat()
        {
            //arrange
            string[] arguments = new string[4];
            double expectedTotal = 26.61;

            arguments[0] = "-added";
            arguments[1] = "1.5,2,3.5,4,66.60";
            arguments[2] = "-subtracted";
            arguments[3] = "1,2,5.9,42.09";

            //act
            Arguments arguments = new Arguments(argArray);
            double actualValue = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualValue);
        }

        [TestMethod]
        public void Arguments_WithInvalidFormat()
        {
            //arrange
            string[] argArray = new string[4];

            argArray[0] = "added";
            argArray[1] = "1,2,3,4,5";
            argArray[2] = "subtracted";
            argArray[3] = "6,7,8,9,10";

            //act
            Arguments arguments = new Arguments(argArray);

            //assert
            Assert.IsFalse(arguments.IsCommandLineValid);
        }

        [TestMethod]
        public void Arguments_WithNoArguments()
        {
            //arrange
            string[] argArray = Array.Empty<string>();

            //act
            Arguments arguments = new Arguments(argArray);

            //assert
            Assert.IsFalse(arguments.IsCommandLineValid);
        }

        [TestMethod]
        public void Arguments_WithNonNumericValues()
        {
            //arrange
            string[] arguments = new string[4];
            double expectedTotal = 3.25;

            arguments[0] = "-added";
            arguments[1] = "1,2,3.5,b,c,d";
            arguments[2] = "-subtracted";
            arguments[3] = "1.25,2.0,e,f,g,i";

            //act
            Arguments arguments = new Arguments(argArray);
            double actualValue = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualValue);
        }

        [TestMethod]
        public void CommandLineArguments_SingleArgument_Added()
        {
            //arrange
            string[] arguments = new string[2];
            double expectedTotal = 6.50;

            arguments[0] = "-added";
            arguments[1] = "1,2,3.5";

            //act
            Arguments arguments = new Arguments(argArray);
            double actualValue = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualValue);
        }

        [TestMethod]
        public void CommandLineArguments_SingleArgument_Subtracted()
        {
            //arrange
            string[] arguments = new string[2];
            double expectedTotal = -6.50;

            arguments[0] = "-subtracted";
            arguments[1] = "1,2,3.5";

            //act
            Arguments arguments = new Arguments(argArray);
            double actualValue = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualValue);
        }

    }
}
