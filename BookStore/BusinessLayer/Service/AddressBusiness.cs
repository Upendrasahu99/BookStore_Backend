using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.ReturnModel;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
	/// <summary>
	/// Implement IAddAddress Interface
	/// </summary>
    public class AddressBusiness : IAddressBusiness
    {
		private readonly IAddressRepo addressRepo;
		public AddressBusiness(IAddressRepo addressRepo)
		{
			this.addressRepo = addressRepo;
		}

		/// <summary>
		/// Implement AddAddress method and call repolayer addAddress Method
		/// </summary>
		/// <param name="addressModel"></param>
		/// <param name="userId"></param>
		/// <returns></returns>
        public Address AddAddress(AddAddressModel addressModel, int userId)
        {
			try
			{
				return addressRepo.AddAddress(addressModel, userId);
			}
			catch (Exception)
			{

				throw;
			}
        }


        /// <summary>
        /// This method implement get address of particular user using particular addressId.
        /// </summary>
        /// <param name="userId">for access particular user</param>
        /// <param name="addressId">for particular access particular address of user</param>
        /// <returns>return address detail</returns>
        public AddressDetail GetAddress(int userId, int addressId)
		{
			try
			{
				return addressRepo.GetAddress(userId, addressId);
			}
			catch (Exception)
			{

				throw;
			}
		}


        /// <summary>
        /// This method is Implemented GetAllAddress functionality particular user.
        /// </summary>
        /// <param name="userId">for chose particular user</param>
        /// <returns>Return all the address</returns>
        public List<AddressDetail> GetAllAddress(int userId)
		{
			try
			{
				return addressRepo.GetAllAddress(userId);
			}
			catch (Exception)
			{

				throw;
			}
		}
    }
}
