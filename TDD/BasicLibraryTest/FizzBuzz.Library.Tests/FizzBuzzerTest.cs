using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Library.Tests
{
    [TestClass]
    public class FizzBuzzerTest
    {
        int[] defaultInputParamters;
        string[] defaultOutputParamters;

        int[] inputParametersDivBy3;

        int[] inputParametersDivBy5;

        [TestInitialize]
        public void TestInitialize()
        {
            defaultInputParamters= new int[] { 1, 2, 4, 7, 8, 11, 13, 16 };
            defaultOutputParamters = new string[] { "1", "2", "4", "7", "8", "11", "13", "16" };

            inputParametersDivBy3 = new int[] { 3, 6, 9, 12, 15 };

            inputParametersDivBy5 = new int[] { 5, 10, 20 };
        }

        [TestMethod]
        public void Fizz_Buzzer_Negative_Interface_Method_Not_Implemented()
        {
            Exception expectedException = new Exception();
            //Arrange
            IFizzBuzzer fb = new FizzBuzzer() as IFizzBuzzer;

            //Act
            try
            {
                int input = 1;
                string output = fb.GetValue(input);
            }
            catch (NotImplementedException ex)
            {
                expectedException = ex;
            }

            //Asert
            Assert.IsFalse(expectedException.GetType() == typeof(NotImplementedException));
        }

        [TestMethod]
        public void Fizz_Buzzer_Interface_Method__Implemented()
        {
            //Arrange
            IFizzBuzzer fb = new FizzBuzzer() as IFizzBuzzer;
            //Act
            int input = 1;
            string output = fb.GetValue(input);
            //Asert
            Assert.AreEqual(output, "1");
        }

        [TestMethod]
        public void FizzBuzzer_WhenDefault__Returns_Input()
        {
            //Arrange
            IFizzBuzzer fb = new FizzBuzzer() as IFizzBuzzer;
            //Act
            int input = 2;
            string output = fb.GetValue(input);
            //Asert
            Assert.AreEqual(output, "2");
        }

        [TestMethod]
        public void FizzBuzzer__When_All_Default_Return_All_Input()
        {
            //Arrange
            IFizzBuzzer fb = new FizzBuzzer() as IFizzBuzzer;
            var outputArrayForAssert = new string[defaultInputParamters.Length];

            //Act
            for (int i = 0; i < defaultInputParamters.Length; i++)
            {
                string output = fb.GetValue(defaultInputParamters[i]);
                outputArrayForAssert[i] = output;
            }

            //Asert
            CollectionAssert.AreEqual(outputArrayForAssert, defaultOutputParamters);
        }

        [TestMethod]
        public void FizzBuzzer_When3__Returns_Fizz()
        {
            //Arrange
            IFizzBuzzer fb = new FizzBuzzer() as IFizzBuzzer;
            //Act
            int input = 3;
            string output = fb.GetValue(input);
            //Asert
            Assert.AreEqual(output, "Fizz");
        }

        [TestMethod]
        public void FizzBuzzer_WhenDiv5_Returns_Buzz()
        {
            //Arrange
            IFizzBuzzer fb = new FizzBuzzer() as IFizzBuzzer;
            //Act
            int input = 5;
            string output = fb.GetValue(input);
            //Asert
            Assert.AreEqual(output, "Buzz");
        }

        [TestMethod]
        public void FizzBuzzer__When_ALL_DivBy3_Return_Fizz_Or_FizzBuzz()
        {
            //Arrange
            int input = 0;
            IFizzBuzzer fb = new FizzBuzzer() as IFizzBuzzer;

            //Act
            string output = fb.GetValue(input);
            foreach (var v in inputParametersDivBy3)
            {
                //Asert
                Assert.IsTrue(output == "Fizz" || output == "FizzBuzz");
            }
        }

        [TestMethod]
        public void FizzBuzzer__When_ALL_DivBy5_Return_FizzBuzz()
        {
            //Arrange
            int input = 0;
            IFizzBuzzer fb = new FizzBuzzer() as IFizzBuzzer;

            //Act
            string output = fb.GetValue(input);
            foreach (var v in inputParametersDivBy3)
            {
                //Asert
                Assert.AreEqual(output,"FizzBuzz");
            }
        }

    }
}
