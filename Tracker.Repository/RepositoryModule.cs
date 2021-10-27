using Microsoft.Extensions.DependencyInjection;
using System;
using Tracker.Repository.Implementation;
using Tracker.Repository.Interface;

namespace Tracker.Repository
{
    public class RepositoryModule
    {
        public RepositoryModule(IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
