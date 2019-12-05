using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Data
{
  public   class forums
    {
        [Key]
        public int forums_id { get; set; }

        [StringLength(255)]
        public string sujets { get; set; }
        public int vue { get; set; }
       
    }
}
