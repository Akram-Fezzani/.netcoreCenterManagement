using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Centre.Domain.Models
{
   public class Center
    {
        public Guid CenterId { get; set; }
        public string CenterLabel { get; set; }
        public int RotationActuelle { get; set; }
        public int CodeSpecification { get; set; }
        public int UsefulSurface { get; set; }
        public int BuildingNumber { get; set; }
        public Boolean IsActive { get; set; }
        public int CenterCode { get; set; }
        public String SocialReason { get; set; }
        public int BlPrefixNumber { get; set; }

        public IList<Building> Buildings { get; set; }

        public Guid AntennaId { get; set; }


        public virtual ChefCenter ChefCenter { get; set; }

        public virtual IList<Collector> Collectors { get; set; }

        public virtual IList<SpeculationCenter> SpeculationCenters { get; set; }

        public virtual IList<SocietyCenter> SocietyCenters { get; set; }

        public virtual IList<Veterinaire> Veterinaires { get; set; }

    }
}
