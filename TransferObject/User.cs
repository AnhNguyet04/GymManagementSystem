using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address {get; set;}
        public string Role { get; set;}

    }
}
