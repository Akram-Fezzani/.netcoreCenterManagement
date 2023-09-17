using System;
using System.Collections.Generic;
using System.Text;

namespace Centre.Domain.Models
{
    public class CenterByAntenna
    {
        public IList<String> Antennas { get; set; }
        public IList<int> Centers { get; set; }
    }
}
