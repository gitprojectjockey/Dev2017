
using System.Collections.Generic;


namespace DataLayer.Models
{
    public class Company
    {
        public Company()
        {
            Products = new List<Product>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public virtual ICollection<Product>Products { get; set; }
    }
}
