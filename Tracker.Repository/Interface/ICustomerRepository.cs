using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracker.Repository.CosmosSqlModel;

namespace Tracker.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer> AddOrUpdateAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(string id);
    }
}
