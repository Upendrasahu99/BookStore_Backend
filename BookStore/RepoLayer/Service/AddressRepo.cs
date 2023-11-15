using CommonLayer.Model;
using CommonLayer.ReturnModel;
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

        /// <summary>
        /// Method Implement AddAddress method where it add the the address of user and admin in Address table using Address and BookStore Context class.
        /// </summary>
        /// <param name="addressModel">Address detail</param>
        /// <param name="userId">We claim from token for add address for particular user</param>
        /// <returns>Address Model after successfully register</returns>
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

        /// <summary>
        /// This method implement get address where it check by addressId and userId is address is in the address table or not. 
        /// </summary>
        /// <param name="userId">for access particular user</param>
        /// <param name="addressId">for particular access particular address of user</param>
        /// <returns>return address detail</returns>
        public AddressDetail GetAddress(int userId, int addressId) 
        {
            try
            {
                Address address = context.Address.SingleOrDefault(u => u.AddressId == addressId && u.UserId == userId);
                if(address != null)
                {
                    AddressDetail addressDetail = new AddressDetail();
                    addressDetail.AddressId = addressId;
                    addressDetail.UserId = userId;
                    addressDetail.FullAddress = address.FullAddress;
                    addressDetail.City = address.City;
                    addressDetail.PinCode = address.PinCode;
                    addressDetail.State = address.State;
                    address.Country = address.Country;
                    return addressDetail;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// This method is Implemented GetAllAddress functionality where it access and return all the address of particular user.
        /// </summary>
        /// <param name="userId">for chose particular user</param>
        /// <returns>Return all the address</returns>
        public List<AddressDetail> GetAllAddress(int userId)
        {
            try
            {
                List<AddressDetail> addressDetailsList = new List<AddressDetail>();
                List<Address> allAddress = context.Address.Where(u => u.UserId == userId).ToList();
                if(allAddress != null)
                {
                    foreach(Address address in allAddress)
                    {
                        addressDetailsList.Add(GetAddress(userId, address.AddressId));
                    }
                    return addressDetailsList;
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
