using System.Collections.Generic;
using System.Threading.Tasks;
using Tracker.Repository.CosmosSqlModel;

namespace Tracker.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<Order> AddOrUpdateAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(string id);        
    }
}
