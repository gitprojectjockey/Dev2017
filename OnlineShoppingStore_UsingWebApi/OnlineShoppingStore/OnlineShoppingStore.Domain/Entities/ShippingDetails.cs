using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Address Line 1 is Required.")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "City is Required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is Required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip is Required.")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Country is Required.")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
