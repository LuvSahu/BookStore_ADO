using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.AddressModel
{
    public class GetAddressModel
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public long MobileNumber { get; set; }
        public int AddressType { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
