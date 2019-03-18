using Onion.Core.Domain.Models;

namespace Onion.Core.Domain.Services
{
    public interface IOrderDomainService
    {
        void AddProductToOrder(Product product, Order order);
    }
}
