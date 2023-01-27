using BusinessLayer.Interfaces;
using CommonLayer.WishListModel;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class WishListBL : IWishListBL
    {
        private readonly IWishListRL wishListRL;
        public WishListBL(IWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }
        public bool AddTOWishList(int UserId, WishListDataModel listPostModel)
        {
            try
            {
                return this.wishListRL.AddTOWishList(UserId, listPostModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<GetWishListModel> GetAllWishList(int UserId)
        {
            try
            {
                return this.wishListRL.GetAllWishList(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteWishListItem(int UserId, int WishListId)
        {
            try
            {
                return this.wishListRL.DeleteWishListItem(UserId, WishListId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GetWishListModel GetByWishListId(int WishListId, int UserId)
        {
            try
            {
                return this.wishListRL.GetByWishListId(UserId, WishListId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
