namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.frais")]
    public partial class frai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public frai()
        {
            notefrais = new HashSet<notefrai>();
        }

        [Key]
        public int idFrais { get; set; }

        [Column(TypeName = "bit")]
        public bool terminer { get; set; }

        public int? employe_emp_id { get; set; }

        public int? mission_idMission { get; set; }

        public virtual employe employe { get; set; }

        public virtual mission mission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notefrai> notefrais { get; set; }
    }
}
