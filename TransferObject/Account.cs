using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int User_id { get; set; }

        public string Role { get; set; }
        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public Account(string username, string password, string role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }
        public Account(string username, string password, string role, int userID)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.User_id = userID;
        }
    }
}
