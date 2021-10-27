using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Tracker.Repository.CosmosHelper;

namespace Tracker.Repository
{
    public abstract class CosmosBaseRepository<T> where T : class
    {
        public readonly DocumentClient Client;
        private readonly Uri CollectionUri;
        private readonly string _databaseName;
        private readonly string _collectionName;
        private static ConnectionPolicy ConnectionPolicy = new ConnectionPolicy
        {
            ConnectionMode = ConnectionMode.Direct,
            ConnectionProtocol = Protocol.Tcp
        };


        // Set to true for this sample since it deals with different kinds of queries.
        private static readonly FeedOptions DefaultOptions = new FeedOptions { EnableCrossPartitionQuery = true };

        protected CosmosBaseRepository(string endPoint, string key, string databaseName, string collectionName)
        {
            _databaseName = databaseName;
            _collectionName = collectionName;
            Client = new DocumentClient(new Uri(endPoint), key, ConnectionPolicy);
            CollectionUri = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);
        }

        public void CreateCollectionIfNotExists(string collectionName, string partitionKey)
        {
            // Create a document collection
            var collection = new DocumentCollection { Id = collectionName, PartitionKey = new PartitionKeyDefinition() { Paths = new Collection<string> { $"/{partitionKey}" } } };

            var indexingPolicy = new IndexingPolicy();

            indexingPolicy.IncludedPaths.Add(new IncludedPath
            {
                Path = "/*"
            });

            // Now assign the policy to the document collection
            collection.IndexingPolicy = indexingPolicy;

            Client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(_databaseName),
                collection,
                new RequestOptions { OfferThroughput = 400 }
            ).Wait();
        }

        public async Task CreateCollectionIfNotExistsAsync(string collectionName, string partitionKey)
        {
            // Create a document collection
            var collection = new DocumentCollection { Id = collectionName, PartitionKey = new PartitionKeyDefinition() { Paths = new Collection<string> { $"/{partitionKey}" } } };

            var indexingPolicy = new IndexingPolicy();

            indexingPolicy.IncludedPaths.Add(new IncludedPath
            {
                Path = "/*"
            });

            // Now assign the policy to the document collection
            collection.IndexingPolicy = indexingPolicy;

            await Client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(_databaseName),
                collection,
                new RequestOptions { OfferThroughput = 400 }
            );
        }

        public async Task CreateDatabaseIfNotExistsAsync()
        {
            await Client.CreateDatabaseIfNotExistsAsync(new Database { Id = _databaseName });
        }

        public async Task<T> InsertAsync(T data)
        {
            var response = await Client.CreateDocumentAsync(CollectionUri, data);
            return data;

        }

        public async Task<T> AddOrUpdateAsync(T data)
        {
            var response = await Client.UpsertDocumentAsync(CollectionUri, data);
            return data;

        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool queryCrossPartition = false, int maxItemCount = -1)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = maxItemCount, EnableCrossPartitionQuery = queryCrossPartition };

            var result = Client.CreateDocumentQuery<T>(CollectionUri, queryOptions).Where(predicate);

            return result;
        }

        public IQueryable<K> Query<K>(string query, bool queryCrossPartition = false, int maxItemCount = -1)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = maxItemCount, EnableCrossPartitionQuery = queryCrossPartition };

            var result = Client.CreateDocumentQuery<K>(CollectionUri, query, queryOptions);

            return result;
        }      

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null, bool queryCrossPartition = false, int maxItemCount = 1)
        {

            FeedOptions queryOptions = new FeedOptions { MaxItemCount = maxItemCount, EnableCrossPartitionQuery = queryCrossPartition };

            return predicate != null
                ? await Client.CreateDocumentQuery<T>(CollectionUri, queryOptions).Where(predicate)
                    .FirstOrDefaultAsync()
                : await Client.CreateDocumentQuery<T>(CollectionUri, queryOptions)
                    .FirstOrDefaultAsync();
        }      
    }
}
