using Centre.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Centre.Domain.Models
{
    public class Building
    {
        public Guid BuildingId { get; set; }

        public int BuildingCode { get; set; }
        public int BuildingLabel { get; set; }
        public int BuildingArea { get; set; }
        public int BuildingAdress { get; set; }
        public int Couvoir { get; set; }
        public string Souche { get; set; }
        public int Age { get; set; }
        public int rotation { get; set; }

        public Center Center { get; set; }


    }
}
