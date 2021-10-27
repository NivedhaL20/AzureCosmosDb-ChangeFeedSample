using Microsoft.Extensions.DependencyInjection;
using Tracker.Services.Implementation;
using Tracker.Services.Interface;

namespace Tracker.Services
{
    public class ServiceModule
    {
        public ServiceModule(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
