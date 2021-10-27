using System;

namespace Tracker.Models.ViewModel
{
    public class CustomerViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public int Pincode { get; set; }
        
        public string EmailId { get; set; }
        
        public string MobileNumber { get; set; }
    }
}
