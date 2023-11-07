using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class AdminUserRegisterModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public string MobileNum { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
