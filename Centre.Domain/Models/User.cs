using System;
using System.Collections.Generic;
using System.Text;

namespace Centre.Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
