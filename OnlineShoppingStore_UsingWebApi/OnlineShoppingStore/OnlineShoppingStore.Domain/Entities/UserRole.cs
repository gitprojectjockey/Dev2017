using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.Domain.Entities
{
    public class UserRole
    {
        [Required(ErrorMessage = "Role is a required field.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "UserId is a required field.")]
        public string UserId { get; set; }
    }
}