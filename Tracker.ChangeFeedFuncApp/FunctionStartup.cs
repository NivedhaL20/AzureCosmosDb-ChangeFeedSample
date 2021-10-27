using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tracker.Repository;
using Tracker.Services;

[assembly: FunctionsStartup(typeof(Tracker.ChangeFeedFuncApp.FunctionStartup))]
namespace Tracker.ChangeFeedFuncApp
{
    public class FunctionStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            new ServiceModule(builder.Services);
            new RepositoryModule(builder.Services);
            builder.Services.AddAutoMapper(typeof(AutoMapping));

            builder.Services.AddSingleton<OrderContext>(k =>
            {
                var endPoint = builder.GetContext().Configuration["CosmosSql:CosmosEndpoint"];
                var key = builder.GetContext().Configuration["CosmosSql:CosmosKey"];
                var databaseName = builder.GetContext().Configuration["CosmosSql:CosmosDatabaseId"];
                var collectionName = builder.GetContext().Configuration["CosmosSql:CosmosOrderCollection"];

                return new OrderContext(endPoint, key, databaseName, collectionName);
            });

            builder.Services.AddSingleton<ProductContext>(k =>
            {
                var endPoint = builder.GetContext().Configuration["CosmosSql:CosmosEndpoint"];
                var key = builder.GetContext().Configuration["CosmosSql:CosmosKey"];
                var databaseName = builder.GetContext().Configuration["CosmosSql:CosmosDatabaseId"];
                var collectionName = builder.GetContext().Configuration["CosmosSql:CosmosProductCollection"];

                return new ProductContext(endPoint, key, databaseName, collectionName);
            });

            builder.Services.AddSingleton<CustomerContext>(k =>
            {
                var endPoint = builder.GetContext().Configuration["CosmosSql:CosmosEndpoint"];
                var key = builder.GetContext().Configuration["CosmosSql:CosmosKey"];
                var databaseName = builder.GetContext().Configuration["CosmosSql:CosmosDatabaseId"];
                var collectionName = builder.GetContext().Configuration["CosmosSql:CosmosCustomerCollection"];

                return new CustomerContext(endPoint, key, databaseName, collectionName);
            });
        }
    }
}
