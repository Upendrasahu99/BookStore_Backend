using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IAddressRepo
    {

        /// <summary>
        /// Functionality for add address for user and admin both
        /// </summary>
        /// <param name="addressModel">Enter the address detail</param>
        /// <param name="userId">claim from Jwt token when user login</param>
        /// <returns>return the detail of Address which added</returns>
        public Address AddAddress(AddAddressModel addressModel, int userId);
    }
}
