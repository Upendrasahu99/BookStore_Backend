using CommonLayer.Model;
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

        public Users RegisterUser(AdminUserRegisterModel model, string role)
        {
            try
            {
                Users users = new Users();
                users.FirstName = model.FirstName;
                users.LastName = model.LastName;
                users.Gender = model.Gender;
                users.MobileNum = model.MobileNum;
                users.Email = model.Email;
                users.Password = model.Password;
                users.Role = role;
                context.Users.Add(users);
                context.SaveChanges();
                return users;
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
                Users user = context.Users.SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if(user != null)
                {
                    return GenerateToken(user.Email, user.UserId, user.Role);
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


        public Users ResetPassword(string email, string newPassword, string confirmPassword)
        {
            try
            {
                Users user = context.Users.SingleOrDefault(u => u.Email == email);
                if(user != null && newPassword == confirmPassword)
                {
                   user.Password = newPassword;
                   context.SaveChanges();
                   return user;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

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
