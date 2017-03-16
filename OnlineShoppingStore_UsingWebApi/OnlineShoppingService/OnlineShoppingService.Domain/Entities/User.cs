using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineShoppingService.Domain.Entities
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "User Password is a required field.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "User Email is a required field.")]
        public string Email { get; set; }
    }
}
