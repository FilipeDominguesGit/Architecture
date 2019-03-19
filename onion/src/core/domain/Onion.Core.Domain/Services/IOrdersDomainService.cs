using Onion.Core.Domain.Models;

namespace Onion.Core.Domain.Services
{
    public interface IOrdersDomainService
    {
        void AddProductToOrder(Product product, Order order);
    }
}
