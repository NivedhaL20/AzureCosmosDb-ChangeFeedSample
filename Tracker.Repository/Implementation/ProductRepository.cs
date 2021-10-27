using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracker.Repository.CosmosHelper;
using Tracker.Repository.CosmosSqlModel;
using Tracker.Repository.Interface;

namespace Tracker.Repository.Implementation
{
    public class ProductRepository: IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Product> AddOrUpdateAsync(Product order)
        {
            return await _productContext.AddOrUpdateAsync(order);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productContext.Where(k => true).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _productContext.FirstOrDefaultAsync(k => k.Id == id);
        }
    }
}
