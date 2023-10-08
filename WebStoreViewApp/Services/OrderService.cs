using WebStoreViewApp.Domain;
using WebStoreViewApp.Services.Interfaces;

namespace WebStoreViewApp.Services
{
    public sealed class OrderService : IOrderService
    {
        public Order CreateOrder(List<Product> products, decimal discount)
        {
            if (discount < 0)
            {
                throw new ArgumentException("Invalid discount value");
            }

            var order = new Order()
            {
                Product = products,
                Discount = discount
            };

            return order;
        }
    }
}