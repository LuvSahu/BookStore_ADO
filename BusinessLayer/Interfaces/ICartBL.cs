using CommonLayer.CartModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ICartBL
    {
        public bool AddBookTOCart(int UserId, CartDataModel postModel);
        public List<GetCartModel> GetAllBooksInCart(int UserId);
        public bool UpdateCartItem(int UserId, CartUpdateModel cartUpdateModel);
        public bool DeleteCartItembyBookId(int UserId, int CartId);
        public GetCartModel GetCartItemByCartId(int CartId, int UserId);
    }
}
