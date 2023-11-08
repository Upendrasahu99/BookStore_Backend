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
    public class UserRepo : IUserRepo
    {
        private readonly BookStoreContext context;

        public UserRepo(BookStoreContext context)
        {
            this.context = context;
        }

        public Users RegisterUser(AdminUserRegisterModel model)
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
                users.Role = model.Role;
                context.Users.Add(users);
                context.SaveChanges();
                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Users UserLogin(UserLoginModel model)
        {
            try
            {
                Users user = context.Users.SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if(user != null)
                {
                    return user;
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


    }
}
