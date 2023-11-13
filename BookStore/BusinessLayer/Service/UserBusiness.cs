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
    /// Implement IUserBusiness
    /// </summary>
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepo userRepo;
        public UserBusiness(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        /// <summary>
        /// Implement register user method
        /// </summary>
        /// <param name="model">Enter user data</param>
        /// <param name="role">Claim role admin from jwt token</param>
        /// <returns>return users detail after registration</returns>
        public UserDetailReturn RegisterUser(AdminUserRegisterModel model, string role)
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

        /// <summary>
        /// Implement UserLogin method for  user and admin login
        /// </summary>
        /// <param name="model">enter email and password</param>
        /// <returns>return token</returns>
        public UserAdminLoginReturn UserAdminLogin(UserLoginModel model)
        {
            try
            {
                return userRepo.UserAdminLogin(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Implement Forgot password functionality for user and admin
        /// </summary>
        /// <param name="email">user email for check user in database or not</param>
        /// <returns>return  jwt token</returns>
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

        /// <summary>
        /// Implement Reset password functionality for user and admin
        /// </summary>
        /// <param name="email">email for check user is valid or not</param>
        /// <param name="newPassword">new password</param>
        /// <param name="confirmPassword">for confirm enter password</param>
        /// <returns>return user detail</returns>
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
