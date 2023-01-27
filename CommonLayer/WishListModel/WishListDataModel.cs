using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.WishListModel
{
    public class WishListDataModel
    {
        [Required]
        public int BookId { get; set; }
    }
}
