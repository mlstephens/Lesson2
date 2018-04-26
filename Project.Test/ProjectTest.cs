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
            string[] argArray = new string[4];
            double expectedTotal = 26.61;

            argArray[0] = "-added";
            argArray[1] = "1.5,2,3.5,4,66.60";
            argArray[2] = "-subtracted";
            argArray[3] = "1,2,5.9,42.09";

            //act
            Arguments arguments = new Arguments(argArray);
            double actualValue = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualValue);
        }

        [TestMethod]
        public void CommandLineArguments_InvalidArgumentFormat()
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
        public void CommandLineArguments_NoArguments()
        {
            //arrange
            string[] argArray = Array.Empty<string>();

            //act
            Arguments arguments = new Arguments(argArray);

            //assert
            Assert.IsFalse(arguments.IsCommandLineValid);
        }

        [TestMethod]
        public void CommandLineArguments_NonNumericArgumentValues()
        {
            //arrange
            string[] argArray = new string[4];
            double expectedTotal = 3.25;

            argArray[0] = "-added";
            argArray[1] = "1,2,3.5,b,c,d";
            argArray[2] = "-subtracted";
            argArray[3] = "1.25,2.0,e,f,g,i";

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
            string[] argArray = new string[2];
            double expectedTotal = 6.50;

            argArray[0] = "-added";
            argArray[1] = "1,2,3.5";

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
            string[] argArray = new string[2];
            double expectedTotal = -6.50;

            argArray[0] = "-subtracted";
            argArray[1] = "1,2,3.5";

            //act
            Arguments arguments = new Arguments(argArray);
            double actualValue = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualValue);
        }

        #endregion
    }
}
