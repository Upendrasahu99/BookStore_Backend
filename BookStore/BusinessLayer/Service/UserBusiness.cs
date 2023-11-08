﻿using BusinessLayer.Interface;
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

        public Users RegisterUser(AdminUserRegisterModel model)
        {
            try
            {
                return userRepo.RegisterUser(model);
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
                return userRepo.UserLogin(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
