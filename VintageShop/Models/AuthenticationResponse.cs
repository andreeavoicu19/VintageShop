using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VintageShop.Models
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }
        public string Token { get; set; }
    }
}
