
using System.ComponentModel.DataAnnotations;

namespace MvcAjaxDemo.Core.Domain
{

    public class Product
    {

        [Key]
        public int ProductId { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50, ErrorMessage = "Name is to long")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product Description")]
        [MaxLength(500, ErrorMessage = "Description is to long")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price is not in correct range")]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
