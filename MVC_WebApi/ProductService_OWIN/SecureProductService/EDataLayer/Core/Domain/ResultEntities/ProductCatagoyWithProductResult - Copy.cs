using System;

namespace EDataLayer.Core.Domain.ResultEntities
{
    public class ProductCatagoryWithProductResult
    {
        public string ProductName { get; set; }

        public Guid ProductId{ get; set; }

        public decimal Price { get; set; }

        public string ProductDescription { get; set; }

        public string ProductCatagoryName { get; set; }

        public Guid ProductCatagoryId { get; set; }
    }
}
