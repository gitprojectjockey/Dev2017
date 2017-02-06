using System;
using System.Collections.Generic;
using EDataLayer.Core.Domain.Abstract;

namespace EDataLayer.Core.Domain
{
    public class Company : Identity
    {
        public Company()
        {
            Products = new List<Product>();
        }
        public Guid CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string State { get; set; }

        public virtual  ICollection<Product> Products{ get; set; }
    }
}
