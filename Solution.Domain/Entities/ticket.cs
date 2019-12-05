namespace Solution.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("last.ticket")]
    public partial class ticket
    {
        public int id { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        public int flextime { get; set; }

        [StringLength(255)]
        public string tache { get; set; }
    }
}
