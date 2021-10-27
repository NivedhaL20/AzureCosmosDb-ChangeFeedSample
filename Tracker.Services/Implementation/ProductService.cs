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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var orders = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductViewModel>>(orders);
        }

        public async Task<ProductViewModel> AddOrUpdateAsync(ProductViewModel orderModel)
        {
            var data = _mapper.Map<Product>(orderModel);
            var upsertedData = await _productRepository.AddOrUpdateAsync(data);
            return _mapper.Map<ProductViewModel>(upsertedData);
        }

        public async Task<ProductViewModel> GetByIdAsync(string id)
        {
            var order = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductViewModel>(order);
        }
    }
}
