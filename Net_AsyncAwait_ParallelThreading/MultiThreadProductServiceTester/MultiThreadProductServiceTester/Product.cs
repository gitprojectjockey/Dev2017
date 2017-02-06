

using System;

namespace MultiThreadProductServiceTester
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public System.Guid ProductCatagoryId { get; set; }

        public virtual ProductCatagory ProductCatagory { get; set; }
    }
}

 