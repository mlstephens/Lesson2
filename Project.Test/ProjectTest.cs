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
            string[] argArray = new string[4];
            double expectedTotal = 55.983;

            argArray[0] = "-added";
            argArray[1] = "25.983,15.09,9,33.7838";
            argArray[2] = "-subtracted";
            argArray[3] = "10,15.78383,2.09";

            //act
            ArgumentsPartialClass arguments = new ArgumentsPartialClass(argArray);
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
            ArgumentsPartialClass arguments = new ArgumentsPartialClass(argArray);

            //assert
            Assert.IsFalse(arguments.IsCommandLineValid);
        }

        [TestMethod]
        public void Arguments_WithNoArguments()
        {
            //arrange
            string[] argArray = Array.Empty<string>();

            //act
            ArgumentsPartialClass arguments = new ArgumentsPartialClass(argArray);

            //assert
            Assert.IsFalse(arguments.IsCommandLineValid);
        }

        [TestMethod]
        public void Arguments_WithNonNumericValues()
        {
            //arrange
            string[] argArray = new string[4];
            double expectedTotal = 77.44;

            argArray[0] = "-added";
            argArray[1] = "65.38,49.99,A,d";
            argArray[2] = "-subtracted";
            argArray[3] = "15.00003,22.93,Z";

            //act
            ArgumentsPartialClass arguments = new ArgumentsPartialClass(argArray);
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
            double expectedTotal = 179.0231;

            argArray[0] = "-added";
            argArray[1] = "103.9838,75.0393";

            //act
            ArgumentsPartialClass arguments = new ArgumentsPartialClass(argArray);
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
            double expectedTotal = -329.4021;

            argArray[0] = "-subtracted";
            argArray[1] = "364.993,1.009,-2.5,-34.0999";

            //act
            ArgumentsPartialClass arguments = new ArgumentsPartialClass(argArray);
            double actualValue = arguments.GetTotal();

            //assert
            Assert.IsTrue(arguments.IsCommandLineValid);
            Assert.AreEqual(expectedTotal, actualValue);
        }

    }
}
