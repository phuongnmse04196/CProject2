using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.BO
{    
    public class Account
    {
        public string username { get; set; }
        public bool role { get; set; }
        public string password { get; set; }

        public Account(string username, string password, bool role)
        {
            this.username = username;
            this.role = role;
            this.password = password;
        }
        
    }
}