﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Identity_Cookie_Auth.Models
{
    public class RegistrationModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Country { get; set; }
    }
}