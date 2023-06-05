using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Centre.Domain.Models
{
    public class Collector
    {
        public Guid CollecteurId { get; set; }
        public int CodeCollecteur { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int Telephone { get; set; }

        [JsonIgnore]
        public Center Center { get; set; }


    }
}
