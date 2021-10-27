using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker.Models.ViewModel
{
    public class ProductViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
       
        public string Name { get; set; }
        
        public string ModelNumber { get; set; }
        
        public int AvailableQuantity { get; set; }
        
        public decimal Price { get; set; }
        
        public string Brand { get; set; }
    }
}
