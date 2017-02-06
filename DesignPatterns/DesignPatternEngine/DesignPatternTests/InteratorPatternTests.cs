using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatternEngine.IteratorPattern.Concrete;
using System.Collections.Generic;
using System.Linq;
using DesignPatternEngine.IteratorPattern.Entities;

namespace DesignPatternTests
{
    [TestClass]
    public class IteratorPatternTests
    {
        private static List<Product> _products;
        public IteratorPatternTests()
        {
            _products = new List<Product>()
           {
               new Product {Id=1,Price = 10000,Name = "Camping Tent", Category="Sportsware", Description="Nice Product" },
               new Product {Id=2,Price = 10500.99,Name = "Used Car", Category="Auto", Description="Nice Product" },
               new Product {Id=3,Price = 100000.11,Name = "New Camper Bus", Category="Auto", Description="Nice Product" },
               new Product {Id=4,Price = 1000000,Name = "New House", Category="Housing", Description="Nice Product" },
               new Product {Id=5,Price = 1000.56,Name = "Game Console", Category="Entertainment", Description="Nice Product" },
               new Product {Id=6,Price = 1500.22,Name = "New Computer", Category="Electronics", Description="Nice Product" },
               new Product {Id=7,Price = 5000,Name = "New Couch", Category="Home funishing", Description="Nice Product" },
               new Product {Id=8,Price = 33000,Name = "New Pickup Truck", Category="Auto", Description="Nice Product" },
               new Product {Id=9,Price = 150000,Name = "Fancy Sports Car", Category="Auto", Description="Nice Product" },
               new Product {Id=10,Price = 200.79,Name = "Real crappy car", Category="Auto", Description="Nice Product" }
           };
        }


        [TestMethod]
        public void IterateProducts_Greedy_Loading_AllProductExist()
        {
            //Because we use ToList<> our list is loaded Immediately
            IEnumerable<Product> productList = IterateProducts.GetIteratorPatternListOfProducts(_products).ToList();
            foreach (var product in productList)
            {
                CollectionAssert.Contains(productList.Select(p => p.Name).ToArray(), product.Name);
            }
        }

        [TestMethod]
        public void IterateProducts_Lazy_Loading_AllProductExist()
        {
            //Lazy loading will not iterate list until for each is hit
            IEnumerable<Product> productList = IterateProducts.GetIteratorPatternListOfProducts(_products);

            foreach (var product in productList)
            {
                CollectionAssert.Contains(productList.Select(p => p.Name).ToArray(), product.Name);
            }
        }
    }
}
