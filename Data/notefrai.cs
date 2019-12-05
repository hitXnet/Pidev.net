namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.notefrais")]
    public partial class notefrai
    {
        [Key]
        public int idfrais { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int? etat { get; set; }

        [StringLength(255)]
        public string facture { get; set; }

        public float montantfrais { get; set; }

        public int? naturefrais { get; set; }

        public int? frais_idFrais { get; set; }

        public virtual frai frai { get; set; }
    }
}
