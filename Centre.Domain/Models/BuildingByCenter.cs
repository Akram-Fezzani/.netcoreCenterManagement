using System;
using System.Collections.Generic;
using System.Text;

namespace Centre.Domain.Models
{
  public  class BuildingByCenter
    {
        public IList<String> Centers { get; set; }
        public IList<int> Buildings { get; set; }
    }
}
