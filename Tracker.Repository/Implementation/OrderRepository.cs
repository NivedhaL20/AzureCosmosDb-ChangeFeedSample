using System.Collections.Generic;
using System.Threading.Tasks;
using Tracker.Repository.CosmosHelper;
using Tracker.Repository.CosmosSqlModel;
using Tracker.Repository.Interface;

namespace Tracker.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task<Order> AddOrUpdateAsync(Order order)
        {
            return await _orderContext.AddOrUpdateAsync(order);            
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderContext.Where(k => true).ToListAsync();            
        }

        public async Task<Order> GetByIdAsync(string id)
        {
            return await _orderContext.FirstOrDefaultAsync(k => k.Id == id);            
        }
    }
}
