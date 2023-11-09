﻿using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAddressBusiness
    {
        public Address AddAddress(AddAddressModel addressModel, int userId);
    }
}
