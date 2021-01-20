using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VintageShop.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Type { get; set; }

    }
}
