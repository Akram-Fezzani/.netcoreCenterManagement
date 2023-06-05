using System;
using System.Collections.Generic;
using System.Text;

namespace Centre.Domain.Models
{
   public class Society
    {
        public Guid SocietyId { get; set; }
        public int CodeSociétés { get; set; }

        public String RaisonSocial { get; set; }

        public int CapitalSocial { get; set; }

        public String Adresse { get; set; }

        public int tel { get; set; }
        public Domaines Domaines { get; set; }

        public virtual IList<SocietyCenter> SocietyCenters { get; set; }





    }
}
