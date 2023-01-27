using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.WishListModel
{
    public class GetWishListModel
    {
        public int WishListId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string BookImg { get; set; }
    }
}
