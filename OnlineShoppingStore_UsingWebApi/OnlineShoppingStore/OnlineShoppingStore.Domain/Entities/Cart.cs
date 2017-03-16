using System.Collections.Generic;
using System.Linq;

namespace OnlineShoppingStore.Domain.Entities
{
    public class Cart
    {
        public List<CartItem> _cartItems = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            CartItem cartItem = _cartItems.Where(ci => ci.Product.ProductId == product.ProductId).FirstOrDefault();
            if (cartItem == null)
            {
                _cartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
            }
        }

        public void RemoveCartItem(Product product)
        {
            _cartItems.RemoveAll(ci => ci.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalPrice()
        {
            return _cartItems.Sum(ci => ci.Quantity * ci.Product.Price);
        }

        public IEnumerable<CartItem> CartItems
        {
            get { return _cartItems; }
        }
       
        public void ClearCartItems()
        {
            _cartItems.Clear();
        }
    }
}
