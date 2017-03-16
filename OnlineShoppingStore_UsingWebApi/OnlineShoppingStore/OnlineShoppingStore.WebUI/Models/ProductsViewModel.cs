using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.WebUI.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Domain.Entities.Product>  Products { get; set; }
        public Models.PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}