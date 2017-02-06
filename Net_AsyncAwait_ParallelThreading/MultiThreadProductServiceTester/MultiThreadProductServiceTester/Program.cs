using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace MultiThreadProductServiceTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri _uri = new Uri("http://localhost:8081/async/api/products");
            HttpClient _httpClient = new HttpClient();

            var t1 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach(var p in products )
                             Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t1.Start();


            var t2 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t2.Start();

            var t3 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t3.Start();

            var t4 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t4.Start();


            var t5 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t5.Start();


            var t6 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t6.Start();

            var t7 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t7.Start();


            var t8 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t8.Start();

            var t9 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t9.Start();

            var t10 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t10.Start();


            var t11 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t11.Start();


            var t12 = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    var response = _httpClient.GetAsync(_uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        // by calling .Result you are synchronously reading the result
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                        foreach (var p in products)
                            Console.WriteLine(p.ProductName);
                    }
                    System.Threading.Thread.Sleep(30);
                }
            });
            t12.Start();

            Console.WriteLine("press any key to quit");
            Console.ReadKey();
        }
}
}
