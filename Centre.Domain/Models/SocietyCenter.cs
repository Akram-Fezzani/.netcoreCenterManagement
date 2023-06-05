using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Centre.Domain.Models
{
    public class SocietyCenter
    {
        public Guid SocietyCenterId { get; set; }

        [ForeignKey("FK_Society")]
        public virtual Guid SocietyId { get; set; }


        [ForeignKey("fk_Center")]
        public virtual Guid CenterId { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


    }
}
