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
            string[] argArray = new string[] { "-added", "1.5,2,3.5,4,43.55", "-subtracted", "1,2,5.9,25.73" };
            double expectedTotal = 19.92;

            //act
            Arguments arguments = new Arguments(argArray);
            double actualTotal = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Arguments_WithInvalidFormat()
        {
            //arrange
            string[] argArray = new string[] { "added", "1,2,3,4,5", "subtracted", "6,7,8,9,10" };

            //act
            Arguments arguments = new Arguments(argArray);

            //assert
            Assert.IsFalse(arguments.IsCommandLineValid);
        }

        [TestMethod]
        public void Arguments_WithValidFormatAndLastArgumentMissingNumericValues()
        {
            //arrange
            string[] argArray = new string[] { "-added", "1,2,3,4", "-subtracted" };
            double expectedTotal = 10;

            //act
            Arguments arguments = new Arguments(argArray);
            double actualTotal = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal,actualTotal);
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
        public void Arguments_WithToManyArguments()
        {
            //arrange
            string[] argArray = new string[] { "-added", "1,2,3,4", "-subtracted", "5,6,7,8", "-extra", "9,10,11,12" };
            double expectedTotal = -16;

            //act
            Arguments arguments = new Arguments(argArray);
            double actualTotal = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Arguments_WithNonNumericValues()
        {
            //arrange
            string[] argArray = new string[] { "-added", "55,75.8,A,d", "-subtracted", "12,31.456,Z" };
            double expectedTotal = 87.344;

            //act
            Arguments arguments = new Arguments(argArray);
            double actualTotal = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Arguments_WithSingleArgument_Added()
        {
            //arrange
            string[] argArray = new string[] { "-added", "45.76756,10,2.005" };
            double expectedTotal = 57.7726;

            //act
            Arguments arguments = new Arguments(argArray);
            double actualTotal = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Arguments_WithSingleArgument_Subtracted()
        {
            //arrange
            string[] argArray = new string[] {"-subtracted", "1,2,3.5" };
            double expectedTotal = -6.50;

            //act
            Arguments arguments = new Arguments(argArray);
            double actualTotal = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualTotal);
        }

    }
}
