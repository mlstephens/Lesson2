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
            string[] argArray = new string[] { "-added", "25.983,15.09,9,33.7838", "-subtracted", "10,15.78383,2.09" };
            double expectedTotal = 55.983;

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
            Assert.AreEqual(expectedTotal, actualTotal);
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
            string[] argArray = new string[] { "-added", "65.38,49.99,A,d", "-subtracted", "15.00003,22.93,Z" };
            double expectedTotal = 77.44;

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
            string[] argArray = new string[] { "-added", "103.9838,75.0393" };
            double expectedTotal = 179.0231;

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
            string[] argArray = new string[] { "-subtracted", "364.993,1.009,-2.5,-34.0999" };
            double expectedTotal = -329.4021;

            //act
            Arguments arguments = new Arguments(argArray);
            double actualTotal = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualTotal);
        }

    }
}
