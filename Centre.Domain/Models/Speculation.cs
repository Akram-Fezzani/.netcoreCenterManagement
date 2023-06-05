using System;
using System.Collections.Generic;
using System.Text;

namespace Centre.Domain.Models
{
    public class Speculation
    {
        public Guid SpeculationId { get; set; }

        public int SpeculationCode { get; set; }

        public virtual IList<SpeculationCenter> SpeculationCenters { get; set; }

    }
}
