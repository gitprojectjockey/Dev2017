using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OnlineShoppingStore.Domain.Entities
{
    public class User
    {
        [Required(ErrorMessage = "User Email is a required field.")]
        [EmailAddress(ErrorMessage = "Email does not contain a valid address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Password is a required field.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 20 characters in length")]
        public string Password { get; set; }
    }
}
