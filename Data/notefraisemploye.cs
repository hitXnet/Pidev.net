namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.notefraisemploye")]
    public partial class notefraisemploye
    {
        [Key]
        public int idfraisem { get; set; }

        [StringLength(255)]
        public string descriptionem { get; set; }

        public float montantfraisem { get; set; }

        public string naturefraisem { get; set; }
    }
}
