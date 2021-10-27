using System;
using System.Collections.Generic;
using System.Text;
using Tracker.Repository.CosmosSqlModel;

namespace Tracker.Repository
{
    public class OrderContext : CosmosBaseRepository<Order>
    {
        public OrderContext(string endPoint, string key, string databaseName, string collectionName) : base(endPoint, key, databaseName, collectionName)
        {
            CreateCollectionIfNotExists(collectionName, "productId");
        }
    }
}
