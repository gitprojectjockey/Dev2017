using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;


namespace JsonArrayBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            var companyIds = new List<Guid>();
            companyIds.Add(new Guid("48c73eb8-54c2-e611-82d2-74da381146fa"));
            companyIds.Add(new Guid("49c73eb8-54c2-e611-82d2-74da381146fa"));
            companyIds.Add(new Guid("4ac73eb8-54c2-e611-82d2-74da381146fa"));
            companyIds.Add(new Guid("4bc73eb8-54c2-e611-82d2-74da381146fa"));

            var catagoryIds = new List<Guid>();
            catagoryIds.Add(new Guid("4cc73eb8-54c2-e611-82d2-74da381146fa"));
            catagoryIds.Add(new Guid("4dc73eb8-54c2-e611-82d2-74da381146fa"));
            catagoryIds.Add(new Guid("4ec73eb8-54c2-e611-82d2-74da381146fa"));

            var productNames = new List<string>();
            productNames.Add("Crate of Flarp");
            productNames.Add("Case of Slarm");
            productNames.Add("Crate of Flipfops");
            productNames.Add("Crate of Felder Garb");
            productNames.Add("Box of Flapson Opel");
            productNames.Add("Cart of BoglPuss Elite");
            productNames.Add("Crate of DomplToast Responder");
            productNames.Add("Crate of Stuggle Tubing");
            productNames.Add("Case of Zampoly Tocken");
            productNames.Add("Crate of Fliper fin");
            productNames.Add("Crate of Doppy Tail Slam");
            productNames.Add("Box of White Opel Taxipost");
            productNames.Add("Cart of Bog Yellow Elite");
            productNames.Add("Crate of Xeron Phobia");
            productNames.Add("Crate of Zondo Flarp");
            productNames.Add("Case of Slarmx Pocket");
            productNames.Add("Crate of FlipTopsoid");
            productNames.Add("Crate of Felder Garbo");
            productNames.Add("Box of Flapsonite Opel Black");
            productNames.Add("Cart of BoglPusston Elite");
            productNames.Add("Crate of Responder Xenphobe");
            productNames.Add("Crate of Stukkle tast");
            productNames.Add("Case of Zampoly Tocken Opo");
            productNames.Add("Crate of Fliper Black fin");
            productNames.Add("Crate of Doppy Tail Slammer");
            productNames.Add("Box of White Opel Taxi Zempa Post");
            productNames.Add("Cart of Bog Purple Elite Tux");
            productNames.Add("Crate of Xeron Tappestry");

            int counter = 1;
            var listOfRandomProducts = new List<Models.Product>();
            for (int i = 4; i < 500; i++)
            {
                counter += i + rnd.Next(1, 1000);

                int ci = rnd.Next(0, companyIds.Count);
                var companyGuid = companyIds[ci];

                int ct = rnd.Next(1, catagoryIds.Count);
                var catatoryGuid = catagoryIds[ct];

                int n = rnd.Next(1, productNames.Count);
                var name = $"{productNames[n]}_{rnd.Next(1, 1000)}";

                var price = rnd.Next(500, 100000);

                var product = new Models.Product();

                product.CompanyId = companyGuid;
                product.ProductCatagoryId = catatoryGuid;
                product.ProductName = name;
                product.Price = price;
                product.Description = $"A {name} is an excellent product with an excellent price.";

                listOfRandomProducts.Add(product);
            }



            var serialized = JsonConvert.SerializeObject(listOfRandomProducts, Formatting.Indented);
            WriteLine(serialized);

            Debug.WriteLine(serialized);
            ReadKey();
        }
    }

}
