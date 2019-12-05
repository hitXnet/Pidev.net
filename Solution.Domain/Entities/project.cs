namespace Solution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("last.project")]
    public partial class project
    {
        public int id { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [StringLength(255)]
        public string projectName { get; set; }
    }
}
