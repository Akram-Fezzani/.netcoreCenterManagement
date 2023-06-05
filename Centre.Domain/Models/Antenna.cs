using System;
using System.Collections.Generic;
using System.Text;

namespace Centre.Domain.Models
{
   public class Antenna
    {
        public Guid AntennaId { get; set; }
        public int AntennaCode { get; set; }

        public String AntennaLabel { get; set; }
        public virtual IList<Center> Centers { get; set; }

    }
}
