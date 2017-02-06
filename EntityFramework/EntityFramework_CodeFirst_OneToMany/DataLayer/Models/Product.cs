namespace DataLayer.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Catagory { get; set; }

        public decimal Price { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
