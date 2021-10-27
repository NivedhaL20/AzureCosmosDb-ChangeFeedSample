using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracker.Repository.CosmosSqlModel;

namespace Tracker.Repository.Interface
{
    public interface IProductRepository
    {
        Task<Product> AddOrUpdateAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
    }
}
