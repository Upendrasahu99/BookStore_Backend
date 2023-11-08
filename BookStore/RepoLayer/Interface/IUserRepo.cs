using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRepo
    {
        public Users RegisterUser(AdminUserRegisterModel model, string role);
        public string UserLogin(UserLoginModel model);
    }
}
