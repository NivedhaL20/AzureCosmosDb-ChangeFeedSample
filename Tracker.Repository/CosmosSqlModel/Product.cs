using Newtonsoft.Json;

namespace Tracker.Repository.CosmosSqlModel
{
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("modelNumber")]
        public string ModelNumber { get; set; }

        [JsonProperty("availableQuantity")]
        public int AvailableQuantity { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }
    }
}
