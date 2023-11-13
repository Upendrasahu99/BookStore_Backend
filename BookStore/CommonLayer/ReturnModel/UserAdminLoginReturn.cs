using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.ReturnModel
{
    public class UserAdminLoginReturn
    {
        public UserDetailReturn UserDetailReturn { get; set; }
        public string Token { get; set; }
    }
}
