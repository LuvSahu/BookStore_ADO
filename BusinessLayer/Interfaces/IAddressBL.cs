using CommonLayer.AddressModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IAddressBL
    {
        public bool AddAddress(int UserId, AddressDataModel postModel);
        public List<GetAddressModel> GetAllAddress(int UserId);
        public bool DeleteAddressByAddressId(int AddressId, int UserId);
        public bool UpdateAddressbyId(int UserId, AddressPutModel postModel);
        public GetAddressModel GetAddressById(int AddressId, int UserId);
    }
}
