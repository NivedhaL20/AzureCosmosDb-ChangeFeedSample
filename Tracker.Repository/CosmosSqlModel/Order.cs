using Newtonsoft.Json;
using System;
using Tracker.Models.Enums;

namespace Tracker.Repository.CosmosSqlModel
{
    public class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("invoiceDate")]
        public DateTime? InvoiceDate { get; set; }

        [JsonProperty("status")]
        public StatusType Status { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }
    }
}
