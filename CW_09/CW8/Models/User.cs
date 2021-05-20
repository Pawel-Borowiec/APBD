using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExp { get; set; }
        public string  Email { get; set; }
        public string  Salt { get; set; }
    }
}
