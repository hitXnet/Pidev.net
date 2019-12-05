namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.fraisprevu")]
    public partial class fraisprevu
    {
        [Key]
        public int idFraisprev { get; set; }

        public float montantprev { get; set; }

        public int? natureprev { get; set; }

        public int? mission_idMission { get; set; }

        public virtual mission mission { get; set; }
    }
}
