using BusinessLayer.Interfaces;
using CommonLayer.CartModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CartBL : ICartBL
    {
        private readonly ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public bool AddBookTOCart(int UserId, CartDataModel postModel)
        {
            try
            {
                return this.cartRL.AddBookTOCart(UserId, postModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GetCartModel> GetAllBooksInCart(int UserId)
        {
            try
            {
                return this.cartRL.GetAllBooksInCart(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateCartItem(int UserId, CartUpdateModel cartUpdateModel)
        {
            try
            {
                return this.cartRL.UpdateCartItem(UserId, cartUpdateModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteCartItembyBookId(int UserId, int CartId)
        {
            try
            {
                return this.cartRL.DeleteCartItembyBookId(UserId, CartId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetCartModel GetCartItemByCartId(int CartId, int UserId)
        {
            try
            {
                return this.cartRL.GetCartItemByCartId(CartId, UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
