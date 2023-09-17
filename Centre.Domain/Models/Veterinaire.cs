using System;
using System.Collections.Generic;
using System.Text;

namespace Centre.Domain.Models
{
   public class Veterinaire
    {
        public Guid VeterinaireId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public int Phone { get; set; }
        public Boolean state { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public Guid CenterId { get; set; }

        public virtual IList<FicheMedicale> FicheMedicales { get; set; }

    }
}
