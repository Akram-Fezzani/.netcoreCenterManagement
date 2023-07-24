using System;
using System.Collections.Generic;
using System.Text;

namespace Centre.Domain.Models
{
    public class DemandeVeto
    {
        public Guid DemandeVetoId { get; set; }
        public Building Building { get; set; }
        public int Couvoir { get; set; }
        public string Souche { get; set; }
        public int Age { get; set; }
        public int rotation { get; set; }

        public String sujet { get; set; }






    }
}
