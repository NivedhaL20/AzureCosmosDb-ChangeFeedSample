using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracker.Models.ViewModel;
using Tracker.Repository.CosmosSqlModel;
using Tracker.Repository.Interface;
using Tracker.Services.Interface;

namespace Tracker.Services.Implementation
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerViewModel>> GetAllAsync()
        {
            var orders = await _customerRepository.GetAllAsync();
            return _mapper.Map<List<CustomerViewModel>>(orders);
        }

        public async Task<CustomerViewModel> AddOrUpdateAsync(CustomerViewModel model)
        {
            var data = _mapper.Map<Customer>(model);
            var upsertedData = await _customerRepository.AddOrUpdateAsync(data);
            return _mapper.Map<CustomerViewModel>(upsertedData);
        }

        public async Task<CustomerViewModel> GetByIdAsync(string id)
        {
            var order = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<CustomerViewModel>(order);
        }
    }
}
