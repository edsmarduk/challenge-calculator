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
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestBlankInput()
        {
            NullLogger logger = new NullLogger();
            Calculator calculator = new Calculator(logger);

            //test for blank, should fail
            calculator.Add("");
            
        }

        /// <summary>
        /// Test to make sure only 2 or less inputs provided. Expected to throw an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTooManyInput()
        {
            NullLogger logger = new NullLogger();
            Calculator calculator = new Calculator(logger);

            //test for more than 2 inputs, should fail
            calculator.Add("12,145,75");

        }

        /// <summary>
        /// Test the add method
        /// </summary>
        [TestMethod]
        public void TestAddition()
        {
            NullLogger logger = new NullLogger();
            Calculator calculator = new Calculator(logger);

            Assert.AreEqual(20, calculator.Add("20"));
            Assert.AreEqual(5001, calculator.Add("1,5000"));
            Assert.AreEqual(1, calculator.Add("4,-3"));
            Assert.AreEqual(5, calculator.Add("5,tytyt"));

        }
    }
}
