using System;
using System.Collections.Generic;


namespace ProductOutlook.WebUI.Models
{
    public class Company 
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
