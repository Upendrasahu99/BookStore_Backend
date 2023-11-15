using CommonLayer.Model;
using CommonLayer.ReturnModel;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAddressBusiness
    {
        /// <summary>
        /// Functionality for add address for user and admin both
        /// </summary>
        /// <param name="addressModel">Enter the address detail</param>
        /// <param name="userId">claim from Jwt token when user login</param>
        /// <returns>return the detail of Address which added</returns>
        public Address AddAddress(AddAddressModel addressModel, int userId);

        /// <summary>
        /// Functionality for get address.
        /// </summary>
        /// <param name="userId">for access particular user</param>
        /// <param name="addressId">for particular access particular address of user</param>
        /// <returns>return address detail</returna>
        public AddressDetail GetAddress(int userId, int addressId);

        /// <summary>
        /// Functionality for get all .
        /// </summary>
        /// <param name="userId">for chose particular user</param>
        /// <returns>Return all the address</returns>
        public List<AddressDetail> GetAllAddress(int userId);
    }
}
