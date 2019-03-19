using System.Collections.Generic;
using Onion.Core.Domain.Models;

namespace Onion.Core.Domain.Repositories
{
    public interface IOrdersRepository : IRepository<Order>
    {
        IEnumerable<Order> GetUserOrders(int userId);
    }
}
