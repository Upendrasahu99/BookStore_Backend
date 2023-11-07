using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepo adminRepo;
        public UserBusiness(IUserRepo adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public Users RegisterUser(AdminUserRegisterModel model)
        {
            try
            {
                return adminRepo.RegisterUser(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
