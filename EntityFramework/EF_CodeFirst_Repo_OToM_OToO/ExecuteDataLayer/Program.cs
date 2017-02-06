using EDataLayer.Core.Domain;
using EDataLayer.Core.Domain.ResultEntities;
using EDataLayer.Core.EUnitOfWork.Abstract;
using EDataLayer.Core.EUnitOfWork.Concrete;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.ConsoleColor;

namespace ExecuteDataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IUnitOfWork unitOfWork = new UnitOfWork(new EDataLayer.Core.DataContext.EDataServeContext()))
            {
                // All companies and their products;
                ForegroundColor = Yellow;
                WriteLine("All companies and their products");
                ForegroundColor = White;
                List<CompanyWithProductResult> companiesWithProductsResult = unitOfWork.Companies.CompaniesWithProducts().ToList();
                foreach (var cp in companiesWithProductsResult)
                {
                    WriteLine($"Company {cp.CompanyName}: {cp.CompanyId} has Product...\n {cp.ProductId}: {cp.ProductName}: {cp.Price}");
                    WriteLine("--------------------------------------------------------------------------------------------------");
                }
                WriteLine("--------------------------------------------------------------------------------------------------");
                ReadKey();

                // Get company and it's products;
                ForegroundColor = Yellow;
                WriteLine("Get company and it's products");
                ForegroundColor = White;
                Company company = unitOfWork.Companies.SingleOrDefault(c => c.CompanyName == "XEROX");
                companiesWithProductsResult = unitOfWork.Companies.CompanyWithProducts(company).ToList();
                foreach (var cp in companiesWithProductsResult)
                {
                    WriteLine($"Company {cp.CompanyName}: {cp.CompanyId} has Product...\n {cp.ProductId}: {cp.ProductName}: {cp.Price}"); ;
                    WriteLine("--------------------------------------------------------------------------------------------------");
                }
                WriteLine("--------------------------------------------------------------------------------------------------");
                ReadKey();


                // All product catagories and their products;
                ForegroundColor = Yellow;
                WriteLine("All product catagories and their products");
                ForegroundColor = White;
                List<ProductCatagoryWithProductResult> productCatagoriesWithProductsResult = unitOfWork.ProductCatagories.ProductCatagoriesWithProducts().ToList();
                foreach (var pcp in productCatagoriesWithProductsResult)
                {
                    WriteLine($"Product Catagory {pcp.ProductCatagoryName}: {pcp.ProductCatagoryId} has Product...\n {pcp.ProductId}: {pcp.ProductName}: {pcp.Price}");
                    WriteLine("--------------------------------------------------------------------------------------------------");
                }
                WriteLine("--------------------------------------------------------------------------------------------------");
                ReadKey();


                //Get catagory and it's products;
                ForegroundColor = Yellow;
                WriteLine("Get catagory and it's products");
                ForegroundColor = White;
                ProductCatagory productCatagory = unitOfWork.ProductCatagories.SingleOrDefault(pc => pc.CatagoryName == "CULINARY");
                productCatagoriesWithProductsResult = unitOfWork.ProductCatagories.ProductCatagoryWithProducts(productCatagory).ToList();
                foreach (var pcp in productCatagoriesWithProductsResult)
                {
                    WriteLine($"Product Catagory {pcp.ProductCatagoryName}: {pcp.ProductCatagoryId} has Product...\n {pcp.ProductId}: {pcp.ProductName}: {pcp.Price}");
                    WriteLine("--------------------------------------------------------------------------------------------------");
                }
                WriteLine("--------------------------------------------------------------------------------------------------");
                ReadKey();

                //Get products by company and product catagory;
                ForegroundColor = Yellow;
                WriteLine("Get products by company and product catagory");
                ForegroundColor = White;
                var companyId = unitOfWork.Companies.SingleOrDefault(c => c.CompanyName == "Supply All Inc.").CompanyId;
                var catagoryId = unitOfWork.ProductCatagories.SingleOrDefault(pc => pc.CatagoryName == "CULINARY").ProductCatagoryId;
                Company cmpny = unitOfWork.Companies.Get(companyId);
                ProductCatagory ctgry = unitOfWork.ProductCatagories.Get(catagoryId);
                List<Product> products = unitOfWork.Products.ProductsByCompanyAndProductCatagory(cmpny, ctgry).ToList();

                foreach (var p in products)
                {
                    WriteLine($"Product {p.ProductName}: {p.ProductId}: {p.Price}");
                    WriteLine("--------------------------------------------------------------------------------------------------");
                }
                WriteLine("--------------------------------------------------------------------------------------------------");
                ReadKey();

                ForegroundColor = Yellow;
                WriteLine("Now we will test Remove-Update-Delete-Add Concurrency using Unit Of Work\n");
                WriteLine("Adding two new medical product to E and V Midical Supplies via UnitOfWork.AddRange\n");

                ReadKey();
                var productsToAdd = new List<Product>() {
                     new Product()
                     {
                         ProductName = "TestProduct1",
                         Description = "Protective Mask For Medical Use",
                         CompanyId = unitOfWork.Companies.SingleOrDefault(c => c.CompanyName == "E and V Medical Suppies").CompanyId,
                         ProductCatagoryId = unitOfWork.ProductCatagories.SingleOrDefault(pc => pc.CatagoryName == "MEDICAL").ProductCatagoryId,
                         Price = 34.78m
                     },
                     new Product()
                     {

                         ProductName = "TestProduct2",
                         Description = "200 ft of high strength rubber tubing for IV use",
                         CompanyId = unitOfWork.Companies.SingleOrDefault(c => c.CompanyName == "E and V Medical Suppies").CompanyId,
                         ProductCatagoryId = unitOfWork.ProductCatagories.SingleOrDefault(pc => pc.CatagoryName== "MEDICAL").ProductCatagoryId,
                         Price = 109.00m
                     }
                };
                unitOfWork.Products.AddRange(productsToAdd);
                unitOfWork.Complete();

                WriteLine("Added Test Medical Product 1 and 2 and called complete on my Unit Of Work\n");
                ForegroundColor = White;

                //Because we enabled lazy loading in our context product collectin in company and companycatagory will only be loaded when we ask for them
                var cmp = unitOfWork.Companies.SingleOrDefault(c => c.CompanyName == "E and V Medical Suppies");
                var ctg = unitOfWork.ProductCatagories.SingleOrDefault(pc => pc.CatagoryName== "MEDICAL");
                var productByCompanyAndCatagory = unitOfWork.Products.ProductsByCompanyAndProductCatagory(cmp, ctg);
                foreach (var p in productByCompanyAndCatagory)
                {
                    Write($"Product Name = {p.ProductName}\n");
                }

               

                ForegroundColor = Yellow;
                WriteLine("--------------------------------------------------------------------------------------------------");
                WriteLine("Now we will update both price and product names\n");
                ReadKey();

                productByCompanyAndCatagory.FirstOrDefault(p => p.ProductName == "TestProduct1").Price = 7777.88m;
                productByCompanyAndCatagory.FirstOrDefault(p => p.ProductName == "TestProduct2").Price = 7777.88m;
                productByCompanyAndCatagory.FirstOrDefault(p => p.ProductName == "TestProduct1").ProductName = "UpdatedTestProduct1";
                productByCompanyAndCatagory.FirstOrDefault(p => p.ProductName == "TestProduct2").ProductName = "UpdatedTestProduct2";
                

                unitOfWork.Products.UpdateRange(productByCompanyAndCatagory);

                unitOfWork.Complete();

                WriteLine("--------------------------------------------------------------------------------------------------");
                WriteLine("Here is the  updated products\n");
                ForegroundColor =White;
                var updatedProductByCompanyAndCatagory = unitOfWork.Products.ProductsByCompanyAndProductCatagory(cmp, ctg);

                foreach (var p in productByCompanyAndCatagory)
                {
                    Write($"Product Name = {p.ProductName} : Product Price {p.Price}\n");
                }

                ReadKey();

                ForegroundColor = Yellow;
                WriteLine("--------------------------------------------------------------------------------------------------");
                WriteLine("Now we will update the price on every product by 10%, remove both UpdatedTestProduct1 and TestProduct2 all in one unit of work\n");
                ReadKey();

                List<Product> productsToUpdate = unitOfWork.Products.GetAll().ToList(); ;
                foreach (var p in productsToUpdate)
                {
                    p.Price = (p.Price*.1m) + p.Price;
                    unitOfWork.Products.Update(p);
                }

                foreach (var p in productByCompanyAndCatagory.Where(p => p.ProductName == "UpdatedTestProduct1" || p.ProductName == "UpdatedTestProduct2"))
                {
                    unitOfWork.Products.Remove(p);
                }

                ForegroundColor = Yellow;
                WriteLine("--------------------------------------------------------------------------------------------------");
                WriteLine("Done");

                unitOfWork.Complete();

                ReadKey();

            }
        }
    }
}
