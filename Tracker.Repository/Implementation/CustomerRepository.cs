using System.Collections.Generic;
using System.Threading.Tasks;
using Tracker.Repository.CosmosHelper;
using Tracker.Repository.CosmosSqlModel;
using Tracker.Repository.Interface;

namespace Tracker.Repository.Implementation
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerContext _customerContext;

        public CustomerRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public async Task<Customer> AddOrUpdateAsync(Customer customer)
        {
            return await _customerContext.AddOrUpdateAsync(customer);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerContext.Where(k => true).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await _customerContext.FirstOrDefaultAsync(k => k.Id == id);
        }
    }
}
