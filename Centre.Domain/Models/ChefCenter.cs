using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Centre.Domain.Models
{
    public class ChefCenter
    {
        public Guid ChefCenterId { get; set; }
        public Guid UserId { get; set; }
        public int ChefCenterCin { get; set; }
        public DateTime ModificationDate { get; set; }
        public int ModificationCin { get; set; }


        [ForeignKey("fk_Center")]
        public virtual Guid CenterId { get; set; }
        public Center Center { get; set; }

    }
}
