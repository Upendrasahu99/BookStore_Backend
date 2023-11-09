using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class AddressRepo : IAddressRepo
    {
        private readonly BookStoreContext context;
        public AddressRepo(BookStoreContext context)
        {
            this.context = context;
        }
        public Address AddAddress(AddAddressModel addressModel, int userId)
        {
            try
            {
                Users user = context.Users.SingleOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    Address address = new Address();
                    address.UserId = userId;
                    address.FullAddress = addressModel.FullAddress;
                    address.City = addressModel.City;
                    address.PinCode = addressModel.PinCode;
                    address.State = addressModel.State;
                    address.Country = addressModel.Country;
                    context.Address.Add(address);
                    context.SaveChanges();
                    return address;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
