using WebStoreViewApp.Domain;

namespace WebStoreViewApp.Services.Interfaces;

public interface IOrderService
{
    public Order CreateOrder(List<Product> products, decimal discount);
}