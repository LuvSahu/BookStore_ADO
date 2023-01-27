﻿using CommonLayer.WishListModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IWishListBL
    {
        public bool AddTOWishList(int UserId, WishListDataModel listPostModel);
        public List<GetWishListModel> GetAllWishList(int UserId);
        public bool DeleteWishListItem(int UserId, int WishListId);
        public GetWishListModel GetByWishListId(int WishListId, int UserId);
    }
}
