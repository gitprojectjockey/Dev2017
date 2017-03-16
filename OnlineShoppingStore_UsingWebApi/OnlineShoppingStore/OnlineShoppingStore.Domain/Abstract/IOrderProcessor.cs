namespace OnlineShoppingStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Entities.Cart cart, Entities.ShippingDetails shippingDetails);
    }
}
