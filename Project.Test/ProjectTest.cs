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
        public void Arguments_WithValidFormat()
        {
            //arrange
            string[] argArray = new string[4];
            double expectedTotal = 19.92;

            argArray[0] = "-added";
            argArray[1] = "1.5,2,3.5,4,43.55";
            argArray[2] = "-subtracted";
            argArray[3] = "1,2,5.9,25.73";

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
            string[] argArray = new string[4];
            double expectedTotal = 87.344;

            argArray[0] = "-added";
            argArray[1] = "55,75.8,A,d";
            argArray[2] = "-subtracted";
            argArray[3] = "12,31.456,Z";

            //act
            Arguments arguments = new Arguments(argArray);
            double actualValue = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualValue);
        }

        [TestMethod]
        public void Arguments_WithSingleArgument_Added()
        {
            //arrange
            string[] argArray = new string[2];
            double expectedTotal = 57.7726;

            argArray[0] = "-added";
            argArray[1] = "45.76756,10,2.005";

            //act
            Arguments arguments = new Arguments(argArray);
            double actualValue = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualValue);
        }

        [TestMethod]
        public void Arguments_WithSingleArgument_Subtracted()
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
    }
}
