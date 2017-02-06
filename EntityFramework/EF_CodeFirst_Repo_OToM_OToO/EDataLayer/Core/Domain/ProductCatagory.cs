
using System;
using System.Collections.Generic;
using EDataLayer.Core.Domain.Abstract;

namespace EDataLayer.Core.Domain
{
    public class ProductCatagory : Identity
    {
        public ProductCatagory()
        {
            Products = new List<Product>();
        }
        public Guid ProductCatagoryId { get; set; }

        public string CatagoryName { get; set; }

        public virtual ICollection <Product>  Products { get; set; }
    }
}
