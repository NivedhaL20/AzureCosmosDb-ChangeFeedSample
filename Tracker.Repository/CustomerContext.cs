using Tracker.Repository.CosmosSqlModel;

namespace Tracker.Repository
{
    public class CustomerContext : CosmosBaseRepository<Customer>
    {
        public CustomerContext(string endPoint, string key, string databaseName, string collectionName) : base(endPoint, key, databaseName, collectionName)
        {
            CreateCollectionIfNotExists(collectionName, "pincode");
        }
    }
}
