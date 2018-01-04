using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WOW.SavesTool.WebApp.Models
{
    public class HomeModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Account number is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Account number must be numeric only")]
        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }
    }
}