using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Models
{
    public class AppUser
    {
        public string refreshToken { get; set; }
        public DateTime refreshTokenExpirationDate { get; set; }
    }
}
