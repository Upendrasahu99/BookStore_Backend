using BusinessLayer.Interface;
using CommonLayer.Model;
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
    }
}
