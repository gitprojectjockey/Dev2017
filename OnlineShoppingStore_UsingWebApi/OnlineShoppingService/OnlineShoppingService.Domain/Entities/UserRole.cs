using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingService.Domain.Entities
{
    public class UserRole
    {
        [Required(ErrorMessage = "Role is a required field.")]
        public string Role { get; set; }

        [Required(ErrorMessage = "IsInRole is a required field.")]
       
        [Key]
        public string UserId { get; set; }
    }
}
