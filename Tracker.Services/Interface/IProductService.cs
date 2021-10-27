using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracker.Models.ViewModel;

namespace Tracker.Services.Interface
{
    public interface IProductService
    {
        Task<ProductViewModel> AddOrUpdateAsync(ProductViewModel inputModel);       
        Task<List<ProductViewModel>> GetAllAsync();
        Task<ProductViewModel> GetByIdAsync(string id);
    }
}
