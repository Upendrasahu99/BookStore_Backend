﻿using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IAddressRepo
    {
        public Address AddAddress(AddAddressModel addressModel, int userId);
    }
}