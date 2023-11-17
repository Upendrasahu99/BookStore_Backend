using CommonLayer.Model;
using CommonLayer.ReturnModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepoLayer.Service
{
    public class UserRepo : IUserRepo
    {
        private readonly BookStoreContext context;
        private readonly IConfiguration configuration;
        public UserRepo(BookStoreContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// Implement functionality for RegisterUser where it register the user and admin detail.
        /// </summary>
        /// <param name="model">Enter user data</param>
        /// <param name="role">Claim role admin from jwt token</param>
        /// <returns>return users detail after registration</returns>
        public UserDetailReturn RegisterUser(AdminUserRegisterModel model, string role)
        {
            try
            { 
                Users users = new Users();
                users.FullName = model.FullName;
                users.MobileNum = model.MobileNum;
                users.Email = model.Email;
                users.Password = model.Password;
                users.Role = role;
                context.Users.Add(users);
                context.SaveChanges();
                return UserAdminDetail(users.UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Implement user login functionality where it check user detail which enter by user with  database data.
        /// </summary>
        /// <param name="model">enter email and password</param>
        /// <returns>return token</returns>
        public UserAdminLoginReturn UserAdminLogin(UserLoginModel model)
        {
            try
            {
                Users user = context.Users.SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if(user != null)
                {
                    UserAdminLoginReturn userAdminLoginReturn = new UserAdminLoginReturn();
                    userAdminLoginReturn.UserDetailReturn = UserAdminDetail(user.UserId);//From UserAdminDetail method get detail
                    userAdminLoginReturn.Token = GenerateToken(user.Email, user.UserId, user.Role);
                    return userAdminLoginReturn;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Implement forgot password functionality where it check mail which enter by user with database table user table email column.
        /// </summary>
        /// <param name="email">user email for check user in database or not</param>
        /// <returns>return  jwt token</returns>
        public string ForgotPassword(string email)
        {
            try
            {
                Users user = context.Users.SingleOrDefault(u => u.Email == email);
                if(user != null)
                {
                    return GenerateToken(user.Email, user.UserId, user.Role);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Implement reset password functionality for user where it take email from jwt token match with database data than add new password.
        /// </summary>
        /// <param name="email">email for check user is valid or not</param>
        /// <param name="newPassword">new password</param>
        /// <param name="confirmPassword">for confirm enter password</param>
        /// <returns>return user detail</returns>
        public UserDetailReturn ResetPassword(string email, string newPassword, string confirmPassword)
        {
            try
            {
                Users user = context.Users.SingleOrDefault(u => u.Email == email);
                if(user != null && newPassword == confirmPassword)
                {
                   user.Password = newPassword;
                   context.SaveChanges();
                   return UserAdminDetail(user.UserId);//Get detail of user
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Method for get user detail from database
        /// </summary>
        /// <param name="userId">for select particular user</param>
        /// <returns>user detail</returns>
        public UserDetailReturn UserAdminDetail(int userId)
        {
            try
            {
                Users user = context.Users.SingleOrDefault(u => u.UserId == userId);
                if(user != null)
                {
                    UserDetailReturn userDetailReturn = new UserDetailReturn();
                    userDetailReturn.FullName = user.FullName;
                    userDetailReturn.MobileNum = user.MobileNum;
                    userDetailReturn.Password = user.Password;
                    return userDetailReturn;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Method Generate JWt Token 
        /// </summary>
        /// <param name="email">In claim add email</param>
        /// <param name="userId">In claim add userId</param>
        /// <param name="role">In claim add role</param>
        /// <returns>return jwt token in string format</returns>
        public string GenerateToken(string email, int userId, string role)
        {
            List<Claim> claimData = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, email),
                new Claim("UserId", userId.ToString()),
                new Claim(ClaimTypes.Role, role),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:SecretKey"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: configuration["JwtSetting:Issuer"],
                audience: configuration["JwtSetting:Audience"],
                claims: claimData,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
