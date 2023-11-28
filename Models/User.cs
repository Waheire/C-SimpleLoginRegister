using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_Registration.Models
{
    internal class User
    {
        private static int counter = 0;
        public int Id { get; set; }
        public string username { get; set; }= string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string? role { get; set; }

        public User(string username, string email, string password) 
        {
            this.Id = ++counter; 
            this.email = email;
            this.username = username;
            this.password = password;
            this.role =  "admin";
        }   
    }
}
