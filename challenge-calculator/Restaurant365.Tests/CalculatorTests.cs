using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant365.Core;
using System;

namespace Restaurant365.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        /// <summary>
        /// Testing blank input. Should throw an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNegativeInput()
        {
            NullLogger logger = new NullLogger();
            Calculator calculator = new Calculator(logger);

            calculator.DenyNegativeNumber = true;
            calculator.Delimiters.Add(",");
            calculator.Delimiters.Add("\n");
            calculator.Delimiters.Add("abc");

            //test for blank, should fail
            calculator.Add("10,-5,100");

        }

        /// <summary>
        /// Testing blank input. Should throw an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestBlankInput()
        {
            NullLogger logger = new NullLogger();
            Calculator calculator = new Calculator(logger);

            //test for blank, should fail
            calculator.Add("");
            
        }

        /// <summary>
        /// Testing blank delimiter. Should throw an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestBlankDelimiter()
        {
            NullLogger logger = new NullLogger();
            Calculator calculator = new Calculator(logger);

            //test for blank delimiter, should fail
            Assert.AreEqual(20, calculator.Add("20"));

        }

        /// <summary>
        /// Test the add method
        /// </summary>
        [TestMethod]
        public void TestAddition()
        {
            NullLogger logger = new NullLogger();
            Calculator calculator = new Calculator(logger);

            //custom delimiters
            Assert.AreEqual(66, calculator.Add("//[***]\n11***22***33"));
            Assert.AreEqual(7, calculator.Add("//#\n2#5"));
            Assert.AreEqual(102, calculator.Add("//,\n2,ff,100"));

            calculator.Delimiters.Clear();

            calculator.Delimiters.Add(",");
            calculator.Delimiters.Add("\n");
            calculator.Delimiters.Add("abc");

            Assert.AreEqual(20, calculator.Add("20"));
            Assert.AreEqual(5001, calculator.Add("1,5000"));
            Assert.AreEqual(1, calculator.Add("4,-3"));
            Assert.AreEqual(5, calculator.Add("5,tytyt"));
            Assert.AreEqual(78, calculator.Add("1,2,3,4,5,6,7,8,9,10,11,12"));
            Assert.AreEqual(6, calculator.Add("1\n2,3"));
            Assert.AreEqual(6, calculator.Add("1abc2,3"));

            calculator.UpperLimit = 1000;
            Assert.AreEqual(8, calculator.Add("2,1001,6"));


        }
    }
}
