using Sushi.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sushi.Data.Interfaces
{
    public interface IOrders
    {
        void CreateOrder(Order order);
        Task<Order> GetOrder(string email);
        Task<IEnumerable<Order>> GetOrders();
        Task DeleteOrder(int id);
        void Save();
    }
}
