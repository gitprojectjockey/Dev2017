using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DesignPatternEngine.StategyPattern.SalesTaxCalculator.Entities;
using DesignPatternEngine.StategyPattern.SalesTaxCalculator.Concrete;
using System.Diagnostics;

namespace DesignPatternTests
{
    [TestClass]
    public class StrategyPattern_SalesTaxCalculatorTests
    {
        private static List<Product> _products;
        private  readonly SalesTaxCalculator _taxCalculator;
        public StrategyPattern_SalesTaxCalculatorTests()
        {
            _taxCalculator = new SalesTaxCalculator();
            _products = new List<Product>()
           {
               new Product {ProductId=1,Price = 10000,Name = "Camping Tent", Category="Sportsware", Description="Nice Product" },
               new Product {ProductId=2,Price = 10500.99,Name = "Used Car", Category="Auto", Description="Nice Product" },
               new Product {ProductId=3,Price = 100000.11,Name = "New Camper Bus", Category="Auto", Description="Nice Product" },
               new Product {ProductId=4,Price = 1000000,Name = "New House", Category="Housing", Description="Nice Product" },
               new Product {ProductId=5,Price = 1000.56,Name = "Game Console", Category="Entertainment", Description="Nice Product" },
               new Product {ProductId=6,Price = 1500.22,Name = "New Computer", Category="Electronics", Description="Nice Product" },
               new Product {ProductId=7,Price = 5000,Name = "New Couch", Category="Home funishing", Description="Nice Product" },
               new Product {ProductId=8,Price = 33000,Name = "New Pickup Truck", Category="Auto", Description="Nice Product" },
               new Product {ProductId=9,Price = 150000,Name = "Fancy Sports Car", Category="Auto", Description="Nice Product" },
               new Product {ProductId=10,Price = 200.79,Name = "Real crappy car", Category="Auto", Description="Nice Product" }
           };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SalesTaxCalculator_CalculateSalesTax_Throws_InvalidArgumentExeption_Product_Null()
        {
            // Arrange 
            // Act 
            // Assert
            var salesTax = _taxCalculator.CalculateSalesTax(null, new TaxOnOneHundredThousandOrBelow());

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SalesTaxCalculator_CalculateSalesTax_Throws_InvalidArgumentExeption_TaxMethod_Null()
        {
            // Arrange 
            // Act 
            // Assert
            var salesTax = _taxCalculator.CalculateSalesTax(null, null);

        }

        [TestMethod]
        public void SalesTaxCalculator_CalculateSalesTax_TaxOnTenThousandOrBelow_ReturnsCorrectValue()
        {
            // Arrange 
            // Act 
            // Assert
            var salesTax = _taxCalculator.CalculateSalesTax(_products.Find(p => p.ProductId == 1), new TaxOnTenThousandOrBelow());
            Assert.AreEqual(salesTax, 500);
        }

        [TestMethod]
        public void SalesTaxCalculator_CalculateSalesTax_TaxOnOneHundredThousandOrBelow_ReturnsCorrectValue()
        {
            // Arrange 
            // Act 
            // Assert
            var salesTax = _taxCalculator.CalculateSalesTax(_products.Find(p => p.ProductId == 8), new TaxOnOneHundredThousandOrBelow());
            Assert.AreEqual(salesTax, 2640.00);
        }

        [TestMethod]
        public void SalesTaxCalculator_CalculateSalesTax_TaxAboveOneHundredThousand_ReturnsCorrectValue()
        {
            // Arrange 
            // Act 
            // Assert
            var salesTax = _taxCalculator.CalculateSalesTax(_products.Find(p => p.ProductId == 9), new TaxAboveOneHundredThousand());
            Assert.AreEqual(salesTax, 12750.00);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SalesTaxCalculator_CalculateSalesTax_Throws_InvalidArgumentExeption_PriceOutSideOrRangeForChosenTaxMethod()
        {
            // Arrange 
            // Act 
            // Assert
            var salesTax = _taxCalculator.CalculateSalesTax(_products.Find(p => p.ProductId == 5), new TaxAboveOneHundredThousand());
        }

        [TestMethod]
        public void SalesTaxCalculator_CalculateSalesTax_TestAll()
        {
            // Arrange 
            // Act 
            // Assert
            double tax = 0;
            List<string> taxes = new List<string>() { "500", "840.08", "8500.01", "85000", "50.03", "75.01", "250", "2640", "12750", "10.04" };
            foreach (var product in _products)
            {
                double price = product.Price;
                if (price <= 10000 && price > 0)
                {
                    tax = _taxCalculator.CalculateSalesTax(product, new TaxOnTenThousandOrBelow());
                   
                }
                else if (price <= 100000 && price > 10000) 
                {
                    tax = _taxCalculator.CalculateSalesTax(product, new TaxOnOneHundredThousandOrBelow());
                   
                }
                else
                {
                    tax = _taxCalculator.CalculateSalesTax(product, new TaxAboveOneHundredThousand());
                }
                Debug.WriteLine(tax);
                CollectionAssert.Contains(taxes, tax.ToString());
            }
        }
    }
}
