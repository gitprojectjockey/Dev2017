using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatternEngine.StategyPattern.AveragingCalculator.Concrete;

namespace DesignPatternTests
{

    [TestClass]
    public class StrategyPattern_AveragingCalculatorTests
    {
        private readonly Calculator _calculator;
        private static List<double> _testValues;
        public StrategyPattern_AveragingCalculatorTests()
        {
           _calculator = new Calculator();
           _testValues = new List<double>() { 10, 5, 7,15,13,12,8,7,4,2,9 };
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        //--------------------Average by Mean Tests------------------------------------------------------
        [TestMethod]
        public void Calculator_AverageByMean_Returns_A_Non_Null()
        {
            // Arrange 
            // Act 
            // Assert
            var meanAverage = _calculator.CalculateAverageFor(_testValues, new AverageByMean());
            Assert.IsNotNull(meanAverage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculator_AverageByMean_Throws_InvalidArgumentExeption_ValuesListParm_Empty()
        {
            // Arrange 
            // Act 
            // Assert
            var meanAverage = _calculator.CalculateAverageFor(new List<double>(), new AverageByMean());
           
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculator_AverageByMean_Throws_InvalidArgumentExeption_ValuesListParm_Null()
        {
            // Arrange 
            // Act 
            // Assert
            var meanAverage = _calculator.CalculateAverageFor(null, new AverageByMean());
            Assert.IsNotNull(meanAverage);
        }

        [TestMethod]
        public void Calculator_AverageByMean_Returns_CorrectValue()
        {
            // Arrange 
            // Act 
            // Assert
            var meanAverage = _calculator.CalculateAverageFor(_testValues, new AverageByMean());
            var expectedResult = 8.363636;
            Assert.IsTrue(ResultsAreCloseEnough(meanAverage , expectedResult));
        }

        //--------------------Average by Median Tests------------------------------------------------------

        [TestMethod]
        public void Calculator_AverageByMedian_Returns_A_Non_Null()
        {
            // Arrange 
            // Act 
            // Assert
            var medianAverage = _calculator.CalculateAverageFor(_testValues, new AverageByMedian());
            Assert.IsNotNull(medianAverage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculator_AverageByMedian_Throws_InvalidArgumentExeption_ValuesListParm_Empty()
        {
            // Arrange 
            // Act 
            // Assert
            var medianAverage = _calculator.CalculateAverageFor(new List<double>(), new AverageByMedian());

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculator_AverageByMedian_Throws_InvalidArgumentExeption_ValuesListParm_Null()
        {
            // Arrange 
            // Act 
            // Assert
            var medianAverage = _calculator.CalculateAverageFor(null, new AverageByMedian());
            Assert.IsNotNull(medianAverage);
        }

        [TestMethod]
        public void Calculator_AverageByMedian_Returns_CorrectValue()
        {
            // Arrange 
            // Act 
            // Assert
            var medianAverage = _calculator.CalculateAverageFor(_testValues, new AverageByMedian());
            var expectedResult = 8;
            Assert.IsTrue(ResultsAreCloseEnough(medianAverage, expectedResult));
        }


        // Helper---------------------------------------------------------------------------------------------------
        private bool ResultsAreCloseEnough(double expectedResult, double calculatedResult)
        {
            var difference = Math.Abs(expectedResult - calculatedResult);
            return difference < .000001;
        }

    }
}
