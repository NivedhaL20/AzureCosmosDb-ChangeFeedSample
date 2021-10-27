using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tracker.Models.ViewModel;

namespace Tracker.Services.Interface
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> AddOrUpdateAsync(CustomerViewModel customer);
        Task<List<CustomerViewModel>> GetAllAsync();
        Task<CustomerViewModel> GetByIdAsync(string id);
    }
}
