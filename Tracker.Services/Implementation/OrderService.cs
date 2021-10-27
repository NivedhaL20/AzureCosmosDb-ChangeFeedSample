using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tracker.Models.ViewModel;
using Tracker.Repository.CosmosSqlModel;
using Tracker.Repository.Interface;
using Tracker.Services.Interface;

namespace Tracker.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderViewModel>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public async Task<OrderViewModel> AddOrUpdateAsync(OrderViewModel orderModel)
        {
            var data = _mapper.Map<Order>(orderModel);
            var upsertedData = await _orderRepository.AddOrUpdateAsync(data);
            return _mapper.Map<OrderViewModel>(upsertedData);
        }

        public async Task<OrderViewModel> GetByIdAsync(string id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderViewModel>(order);
        }
    }
}
