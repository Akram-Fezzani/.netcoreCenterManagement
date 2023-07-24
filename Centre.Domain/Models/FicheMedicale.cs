using System;
using System.Collections.Generic;
using System.Text;

namespace Centre.Domain.Models
{
  public  class FicheMedicale
    {
        public Guid FicheMedicaleId { get; set; }
        public Veterinaire Veterinaire { get; set; }
      
        public int Couvoir { get; set; }
        public string Souche { get; set; }
        public int Age { get; set; }
        public int rotation { get; set; }
        public String Rapport { get; set; }
    }
}
