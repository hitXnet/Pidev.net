namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.employe")]
    public partial class employe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employe()
        {
            frais = new HashSet<frai>();
            missions = new HashSet<mission>();
        }

        [Key]
        public int emp_id { get; set; }

        [StringLength(255)]
        public string bio { get; set; }

        [StringLength(255)]
        public string cv { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        [StringLength(255)]
        public string Nom { get; set; }

        [StringLength(255)]
        public string prenom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<frai> frais { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mission> missions { get; set; }
    }
}
