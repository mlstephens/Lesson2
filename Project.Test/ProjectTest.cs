using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lesson2;

namespace Project.Test
{
    [TestClass]
    public class ProjectTest
    {
        #region  ' Class Tests '

        [TestMethod]
        public void CommandLineArguments_ValidArgumentFormat()
        {
            //arrange
            string[] arguments = new string[4];
            double expectedTotal = 26.61;

            arguments[0] = "-added";
            arguments[1] = "1.5,2,3.5,4,66.60";
            arguments[2] = "-subtracted";
            arguments[3] = "1,2,5.9,42.09";

            //act
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);
            double actualValue = argumentClass.GetTotal();

            //assert
            Assert.AreEqual(expectedTotal, actualValue);
        }

        [TestMethod]
        public void CommandLineArguments_InvalidArgumentFormat()
        {
            //arrange
            string[] arguments = new string[4];

            arguments[0] = "added";
            arguments[1] = "1,2,3,4,5";
            arguments[2] = "subtracted";
            arguments[3] = "6,7,8,9,10";

            //act
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);

            //assert
            Assert.IsFalse(argumentClass.IsCommandLineValid);
        }

        [TestMethod]
        public void CommandLineArguments_NoArguments()
        {
            //arrange
            string[] arguments = Array.Empty<string>();

            //act
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);

            //assert
            Assert.IsFalse(argumentClass.IsCommandLineValid);
        }

        [TestMethod]
        public void CommandLineArguments_NonNumericArgumentValues()
        {
            //arrange
            string[] arguments = new string[4];
            double expectedTotal = 3.25;

            arguments[0] = "-added";
            arguments[1] = "1,2,3.5,b,c,d";
            arguments[2] = "-subtracted";
            arguments[3] = "1.25,2.0,e,f,g,i";

            //act
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);
            double actualValue = argumentClass.GetTotal();

            //assert
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
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);
            double actualValue = argumentClass.GetTotal();

            //assert
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
            ArgumentsClass argumentClass = new ArgumentsClass(arguments);
            double actualValue = argumentClass.GetTotal();

            //assert
            Assert.AreEqual(expectedTotal, actualValue);
        }

        #endregion
    }
}
