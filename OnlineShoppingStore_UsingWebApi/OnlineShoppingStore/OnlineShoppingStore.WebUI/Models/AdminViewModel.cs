
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Models
{
    public class AdminViewModel
    {
        public Domain.Entities.Product Product { get; set; }
       
        public List<string> Catagories { get; set; }
    }
}