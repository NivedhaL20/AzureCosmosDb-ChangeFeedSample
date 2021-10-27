using AutoMapper;
using Tracker.Models.ViewModel;
using Tracker.Repository.CosmosSqlModel;

namespace Tracker.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
