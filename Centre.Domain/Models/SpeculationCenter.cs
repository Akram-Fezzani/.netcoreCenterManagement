using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Centre.Domain.Models
{
    public class SpeculationCenter
    {
        public Guid SpeculationCenterId { get; set; }

        [ForeignKey("fk_Center")]
        public virtual Guid CenterId { get; set; }

        [ForeignKey("fk_Speculation")]
        public virtual Guid SpeculationId { get; set; }
        public int SpeculationCenterCode { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Boolean IsActive { get; set; }
        public String SpeculationCenterLabel { get; set; }



    }
}
