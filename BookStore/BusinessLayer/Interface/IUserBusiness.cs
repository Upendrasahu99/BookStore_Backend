using CommonLayer.Model;
using CommonLayer.ReturnModel;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBusiness
    {

        /// <summary>
        /// Functionality for register user
        /// </summary>
        /// <param name="model">Enter user data</param>
        /// <param name="role">Claim role admin from jwt token</param>
        /// <returns>return users detail after registration</returns>
        public UserDetailReturn RegisterUser(AdminUserRegisterModel model, string role);

        /// <summary>
        /// Functionality for user and admin login
        /// </summary>
        /// <param name="model">enter email and password</param>
        /// <returns>return token</returns>
        public string UserLogin(UserLoginModel model);

        /// <summary>
        /// Functionality for Forgot password
        /// </summary>
        /// <param name="email">user email for check user in database or not</param>
        /// <returns>return  jwt token</returns>
        public string ForgotPassword(string email);

        /// <summary>
        /// Functionality for Reset password
        /// </summary>
        /// <param name="email">email for check user is valid or not</param>
        /// <param name="newPassword">new password</param>
        /// <param name="confirmPassword">for confirm enter password</param>
        /// <returns>return user detail</returns>
        public Users ResetPassword(string email, string newPassword, string confirmPassword);
    }
}
