using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBusiness : IAddressBusiness
    {
		private readonly IAddressRepo addressRepo;
		public AddressBusiness(IAddressRepo addressRepo)
		{
			this.addressRepo = addressRepo;
		}
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
