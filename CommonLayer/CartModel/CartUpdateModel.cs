using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.CartModel
{
    public class CartUpdateModel
    {
        //[Required]
        public int CartId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        //[DefaultValue("1")]
        public int BookQuantity { get; set; }
    }
}
