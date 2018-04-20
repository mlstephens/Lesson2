using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lesson2;

namespace Project.Test
{
    [TestClass]
    public class ProjectTest
    {
        [TestMethod]
        public void CommandLineArguments_ValidFormat_UsingIntegerNumericValues()
        {
            //arrange
            string[] arguments = new string[2];
            double expectedTotal = -25;

            arguments[0] = "added=1,2,3,4,5";
            arguments[1] = "subtracted=6,7,8,9,10";

            //act
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);
            double actualValue = Math.Round(argumentClass.GetTotal(), 4);

            //assert
            Assert.AreEqual(expectedTotal, actualValue, "CommandLine Argument Valid Integer Numeric Values.");
        }

        [TestMethod]
        public void CommandLineArguments_ValidFormat_UsingDoubleNumericValues()
        {
            //arrange
            string[] arguments = new string[2];
            double expectedTotal = 0.8801;

            arguments[0] = "added=1.5876,2.587,3.51";
            arguments[1] = "subtracted=1.1255,2.489,3.19";

            //act
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);
            double actualValue = Math.Round(argumentClass.GetTotal(), 4);

            //assert
            Assert.AreEqual(expectedTotal, actualValue, "CommandLine Argument Valid Double Numeric Values.");
        }

        [TestMethod]
        public void CommandLineArguments_ValidFormat_UsingMixedNumericValues()
        {
            //arrange
            string[] arguments = new string[2];
            double expectedTotal = 26.61;

            arguments[0] = "added=1.5,2,3.5,4,66.60";
            arguments[1] = "subtracted=1,2,5.9,42.09";

            //act
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);
            double actualValue = Math.Round(argumentClass.GetTotal(),4);

            //assert
            Assert.AreEqual(expectedTotal, actualValue, "CommandLine Argument Valid Mixed Numeric Values.");
        }

        [TestMethod]
        public void CommandLineArguments_InValidFormat()
        {
            //arrange
            string[] arguments = new string[2];

            arguments[0] = "added=1,2,3,4,5";
            arguments[1] = "subtracted:6,7,8,9,10";

            //act
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);

            //assert
            Assert.IsFalse(argumentClass.IsCommandLineValid, "CommandLine Argument Invalid Format.");
        }

        [TestMethod]
        public void CommandLineArguments_ArgumentsMissing()
        {
            //arrange
            string[] arguments = Array.Empty<string>();

            //act
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);

            //assert
            Assert.IsFalse(argumentClass.IsCommandLineValid, "CommandLine Argument Missing.");
        }

        [TestMethod]
        public void CommandLineArguments_InvalidArgumentValueTypes()
        {
            //arrange
            string[] arguments = new string[2];
            double expectedTotal = 0;

            arguments[0] = "added=a,b,c,d";
            arguments[1] = "subtracted=e,f,g,i";

            //act
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);
            double actualValue = Math.Round(argumentClass.GetTotal(), 4);

            //assert
            Assert.AreEqual(expectedTotal, actualValue, "CommandLine Arguments Invalid Value Types.");
        }
    }
}
