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
        private readonly IUserRepo userRepo;
        public UserBusiness(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public Users RegisterUser(AdminUserRegisterModel model, string role)
        {
            try
            {
                return userRepo.RegisterUser(model, role);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UserLogin(UserLoginModel model)
        {
            try
            {
                return userRepo.UserLogin(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string ForgotPassword(string email)
        {
            try
            {
                return userRepo.ForgotPassword(email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Users ResetPassword(string email, string newPassword, string confirmPassword)
        {
            try
            {
                return userRepo.ResetPassword(email, newPassword, confirmPassword);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
