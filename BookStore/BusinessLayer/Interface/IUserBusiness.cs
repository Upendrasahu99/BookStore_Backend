using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBusiness
    {
        public Users RegisterUser(AdminUserRegisterModel model, string role);
        public string UserLogin(UserLoginModel model);
        public string ForgotPassword(string email);
    }
}
