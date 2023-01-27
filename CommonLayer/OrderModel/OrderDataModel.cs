using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.OrderModel
{
    public class OrderDataModel
    {
       
        [Required]
        public int AddressId { get; set; }

        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

    }
}
