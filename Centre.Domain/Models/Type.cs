using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Centre.Domain.Models
{
    public class Type
    {
        public Guid TypeId { get; set; }

        public String LibSouche { get; set; }
        public int CodeSouche { get; set; }

        public virtual IList<Center> Centers { get; set; }


    }
}
