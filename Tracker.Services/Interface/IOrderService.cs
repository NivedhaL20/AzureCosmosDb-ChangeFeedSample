using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracker.Models.ViewModel;

namespace Tracker.Services.Interface
{
    public interface IOrderService
    {
        Task<OrderViewModel> AddOrUpdateAsync(OrderViewModel order);
        Task<List<OrderViewModel>> GetAllAsync();
        Task<OrderViewModel> GetByIdAsync(string id);
    }
}
