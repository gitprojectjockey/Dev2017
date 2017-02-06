using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Concrete;
using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Entities;
using System;

namespace DesignPatternTests
{
    [TestClass]
    public class FactoryPattern_EntityValidatorFactoryTests
    {
        class UnsuportedEntityType
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }
        public FactoryPattern_EntityValidatorFactoryTests()
        {

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

        [TestMethod]
        public void EntityValidatorFactory_Returns_Correct_Validator_Type()
        {
            var pev = EntityValidatorFactory<Product>.CreateEntityValidator();
            Assert.IsInstanceOfType(pev, typeof(ProductEntityValidator));

            var eev = EntityValidatorFactory<Employee>.CreateEntityValidator();
            Assert.IsInstanceOfType(eev, typeof(EmployeeEntityValidator));

            var cev = EntityValidatorFactory<Company>.CreateEntityValidator();
            Assert.IsInstanceOfType(cev, typeof(CompanyEntityValidator));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EntityValidatorFactory_Throws_For_Unsupported_Entity_Type()
        {
            var pev = EntityValidatorFactory<UnsuportedEntityType>.CreateEntityValidator();
            Assert.IsInstanceOfType(pev, typeof(ProductEntityValidator));
        }

        [TestMethod]
        public void Return_ProductEntityValidator_IsEntityValidMethod_Returns_True()
        {
            var pev = EntityValidatorFactory<Product>.CreateEntityValidator();
            bool value = pev.IsEntityValid();
            Assert.AreEqual(value, true);
        }

        [TestMethod]
        public void Return_EmployeeEntityValidator_IsEntityValidMethod_Returns_True()
        {
            var eev = EntityValidatorFactory<Employee>.CreateEntityValidator();
            bool value = eev.IsEntityValid();
            Assert.AreEqual(value, true);
        }

        [TestMethod]
        public void Return_CompanyEntityValidator_IsEntityValidMethod_Returns_True()
        {
            var cev = EntityValidatorFactory<Company>.CreateEntityValidator();
            bool value = cev.IsEntityValid();
            Assert.AreEqual(value, true);
        }
    }
}
