using System;
using Tracker.Models.Enums;

namespace Tracker.Models.ViewModel
{
    public class OrderViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string CustomerId { get; set; }

        public int Quantity { get; set; }

        public DateTime? InvoiceDate { get; set; } = DateTime.Now;

        public StatusType Status { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
