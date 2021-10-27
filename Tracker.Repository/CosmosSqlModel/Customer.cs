using Newtonsoft.Json;

namespace Tracker.Repository.CosmosSqlModel
{
    public class Customer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("pincode")]
        public int Pincode { get; set; }

        [JsonProperty("emailId")]
        public string EmailId { get; set; }

        [JsonProperty("MobileNumber")]
        public string MobileNumber { get; set; }
    }
}
