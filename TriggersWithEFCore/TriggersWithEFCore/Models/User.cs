using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriggersWithEFCore.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
    }
}
