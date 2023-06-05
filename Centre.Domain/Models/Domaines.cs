using System;
using System.Collections.Generic;
using System.Text;

namespace Centre.Domain.Models
{
   public class Domaines
    {

        public Guid DomaineId { get; set; }

        public string DomaineName { get; set; }

        public String RaisonSocial { get; set; }

        public int Code { get; set; }

        public int CapitalSocial { get; set; }

        public virtual IList<Society> Societys { get; set; }

    }
}
