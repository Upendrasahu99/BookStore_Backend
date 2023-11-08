using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBusiness
    {
        public Users RegisterUser(AdminUserRegisterModel model);
        public Users UserLogin(UserLoginModel model);
    }
}
