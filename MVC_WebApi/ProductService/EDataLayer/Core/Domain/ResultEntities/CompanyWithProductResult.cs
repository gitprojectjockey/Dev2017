using System;

namespace EDataLayer.Core.Domain.ResultEntities
{
    public class CompanyWithProductResult
    {
        public string ProductName { get; set; }

        public Guid ProductId{ get; set; }

        public decimal Price { get; set; }

        public string ProductDescription { get; set; }

        public string CompanyName { get; set; }

        public Guid CompanyId { get; set; }
    }
}
